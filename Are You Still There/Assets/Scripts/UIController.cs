using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using Unity.VisualScripting;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _dialogueBox;
    [SerializeField] private TMP_Text _npcText;
    [SerializeField] private GameObject _playerOptions;
    [SerializeField] private DialogueController _dialogueController;
    [SerializeField] public GameObject _inventorybox;
    [SerializeField] private TMP_Text _option1;
    [SerializeField] private TMP_Text _option2;
    [SerializeField] private TMP_Text _option3;
    [SerializeField] public GameObject[] _icons;
    [SerializeField] public GameObject _display;
    [SerializeField] private GameObject _use;
    [SerializeField] public TMP_Text _displayText;
    [SerializeField] private GameObject _oldLady;
    private int _currentOption;

    public void Continue()
    {
        _inventorybox.SetActive(false);
        _dialogueController._currentNPC = null;
        _dialogueController._NPC.SetActive(false);
        _oldLady.SetActive(true);
    }
    public void Click(int value)
    {
        _currentOption = value;
        _use.SetActive(true);
        _display.SetActive(true);
        _display.GetComponent<RawImage>().texture = Player.Instance._inventoryarray[value]._icon;
        _displayText.text = Player.Instance._inventory[value]._description;
    }
    public void Effect()
    {
        if (Player.Instance._inventory[_currentOption]._reAmp > 0)
        {
            Player.Instance._energy += Player.Instance._inventory[_currentOption]._reAmp;
            _dialogueController._energy_text.text = "Energy: " + Player.Instance._energy;
            if (Player.Instance._energy > 3)
            {
                Player.Instance._energy = 3;
            }
        }
        _displayText.text = "Empty...";
        _use.SetActive(false);
        _display.GetComponent<RawImage>().texture = null;
        _display.SetActive(false);
        _icons[_currentOption].GetComponent<RawImage>().texture = null;
        _icons[_currentOption].SetActive(false);
    }
    // dialogue logic
    public void ShowDialogue(string dialogue)
    {
        _dialogueBox.SetActive(true);

        _npcText.enabled = true;
        _playerOptions.SetActive(false);

        _npcText.text = dialogue;
    }

    // note: this only works for up to 3 dialogue options at a time currently
    // if you want to make more possible, you may have to get crafty with the UI... :)
    public void ShowPlayerOptions(string[] options)
    {
        _playerOptions.SetActive(true);

        _option1.text = options[0];

        if (options.Length >= 2)
        {
            _option2.transform.parent.gameObject.SetActive(true);
            _option2.text = options[1];
        }
        else
        {
            _option2.transform.parent.gameObject.SetActive(false);
        }

        if (options.Length >= 3)
        {
            _option3.transform.parent.gameObject.SetActive(true);
            _option3.text = options[2];
        }
        else
        {
            _option3.transform.parent.gameObject.SetActive(false);
        }
        for (int i = 0; i < options.Length; i++)
        {
            if (_dialogueController._currentNode._npcReplies[i]._trigger > Player.Instance._total)
            {
                if(_dialogueController._currentNode._npcReplies[i] == _dialogueController._currentNode._npcReplies[0])
                {
                    _option1.transform.parent.gameObject.SetActive(false);
                }
                else if (_dialogueController._currentNode._npcReplies[i] == _dialogueController._currentNode._npcReplies[1])
                {
                    _option2.transform.parent.gameObject.SetActive(false);
                }
                else if (_dialogueController._currentNode._npcReplies[i] == _dialogueController._currentNode._npcReplies[2])
                {
                    _option3.transform.parent.gameObject.SetActive(false);
                }
            }
            else if (_dialogueController._currentNode._npcReplies[i]._requirement > Player.Instance._energy)
            {
                if (_dialogueController._currentNode._npcReplies[i] == _dialogueController._currentNode._npcReplies[0])
                {
                    _option1.transform.parent.gameObject.SetActive(false);
                }
                else if (_dialogueController._currentNode._npcReplies[i] == _dialogueController._currentNode._npcReplies[1])
                {
                    _option2.transform.parent.gameObject.SetActive(false);
                }
                else if (_dialogueController._currentNode._npcReplies[i] == _dialogueController._currentNode._npcReplies[2])
                {
                    _option3.transform.parent.gameObject.SetActive(false);
                }
            }
            else if (_dialogueController._currentNode._npcReplies[i]._execute > Player.Instance._investigation)
            {
                if (_dialogueController._currentNode._npcReplies[i] == _dialogueController._currentNode._npcReplies[0])
                {
                    _option1.transform.parent.gameObject.SetActive(false);
                }
                else if (_dialogueController._currentNode._npcReplies[i] == _dialogueController._currentNode._npcReplies[1])
                {
                    _option2.transform.parent.gameObject.SetActive(false);
                }
                else if (_dialogueController._currentNode._npcReplies[i] == _dialogueController._currentNode._npcReplies[2])
                {
                    _option3.transform.parent.gameObject.SetActive(false);
                }
            }
        }
    }

    public void HideDialogue()
    {
        _dialogueBox.SetActive(false);
        _playerOptions.SetActive(false);
        _npcText.enabled = false;
    }
}
