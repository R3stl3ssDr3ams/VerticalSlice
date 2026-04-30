using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _dialogueBox;
    [SerializeField] private TMP_Text _npcText;
    [SerializeField] private GameObject _playerOptions;
    [SerializeField] private Player _player;
    [SerializeField] private NPC _npc;
    [SerializeField] private TMP_Text _option1;
    [SerializeField] private TMP_Text _option2;
    [SerializeField] private TMP_Text _option3;
    
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
            if (_npc._currentNode._npcReplies[i]._trigger > _player._total)
            {
                if(_npc._currentNode._npcReplies[i] == _npc._currentNode._npcReplies[0])
                {
                    _option1.transform.parent.gameObject.SetActive(false);
                }
                else if (_npc._currentNode._npcReplies[i] == _npc._currentNode._npcReplies[1])
                {
                    _option2.transform.parent.gameObject.SetActive(false);
                }
                else if (_npc._currentNode._npcReplies[i] == _npc._currentNode._npcReplies[2])
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
