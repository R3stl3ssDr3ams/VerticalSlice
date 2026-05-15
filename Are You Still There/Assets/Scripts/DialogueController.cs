using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private UIController _dialogue;
    [SerializeField] public NPC _currentNPC;
    [SerializeField] public GameObject _NPC;
    [SerializeField] public GameObject _finalButton;
    [SerializeField] public TMP_Text _energy_text;
    public DialogueNode _currentNode;
    private DialogueNode _dialogueStartNode;
    private int _currentLine = 0;
    private bool _waitingForPlayerResponse;
    private bool _tookenergy = true;

    private void OnEnable()
    {
        _NPC = GameObject.FindGameObjectWithTag("NPC");
        _currentNPC = GameObject.FindGameObjectWithTag("NPC").GetComponent<NPC>();
    }
    public void AdvanceDialogue()
    {
        if (_currentLine < _currentNode._lines.Length)
        {
            _dialogue.ShowDialogue(_currentNode._lines[_currentLine]);
            _currentLine++;
            if (_tookenergy == false)
            {
                _tookenergy = true;
                _tookenergy = true;
            }
        }
        else if (_currentNode._playerReplyOptions != null && _currentNode._playerReplyOptions.Length > 0)
        {
            // show player dialogue choices
            _waitingForPlayerResponse = true;
            _dialogue.ShowPlayerOptions(_currentNode._playerReplyOptions);
            if (_currentNode._favor > 0)
            {
                Player.Instance._total += _currentNode._favor;
            }
            if (_currentNode._tire > 0 && _tookenergy == true)
            {
                Player.Instance._energy -= _currentNode._tire;
                if (Player.Instance._energy < 0)
                {
                    Player.Instance._energy = 0;
                }
                _tookenergy = false;
                _energy_text.text = "Energy: " + Player.Instance._energy;
            }
            if(_currentNode._investigation > 0)
            {
                Player.Instance._investigation += _currentNode._investigation;
            }
        }
        else
        {
            // ends talking state if there is nothing left to talk about 
            EndDialogue();
        }
    }
    public void SelectedOption(int option)
    {
        _currentLine = 0;
        _waitingForPlayerResponse = false;

        _currentNode = _currentNode._npcReplies[option];
        AdvanceDialogue();
    }

    protected virtual void EndDialogue()
    {
        if (_currentNode._dead == true)
        {
            Destroy(_NPC);
            Player.Instance._murderer = true;
        }
        if (_currentNode._item != null)
        {
            Player.Instance._inventory.Add(_currentNode._item);
            Player.Instance._inventoryarray = Player.Instance._inventory.ToArray();
        }
        if (_currentNode._end == true)
        {
            _dialogue._inventorybox.SetActive(true);
            for (int i = 0; i < Player.Instance._inventory.Count; i++)
            {
                if (Player.Instance._inventoryarray[i] != null)
                {
                    _dialogue._icons[i].SetActive(true);
                    _dialogue._icons[i].GetComponent<RawImage>().texture = Player.Instance._inventoryarray[i]._icon;
                }
            }
        }
        if (_currentNode._final == true)
        {
            _finalButton.SetActive(true);
        }
        Debug.Log("ended dialogue");
        _currentNPC._npcReaction = NPCSpeech.Idle;
        _currentNPC._dialoguebox.SetActive(false);
        _waitingForPlayerResponse = false;
        _currentNode = _dialogueStartNode;
        _currentLine = 0;
    }
}
