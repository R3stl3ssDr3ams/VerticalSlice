using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hunter : NPC
{
    protected override void OnEnable()
    {
        _reset.text = "...";
        _dialogueController._NPC = gameObject;
        _dialogueController._currentNPC = gameObject.GetComponent<NPC>();
        GameObject playerObject = GameObject.FindWithTag("Player");
        _player = playerObject.GetComponent<Player>();
        if (_player._died.AsReadOnlyList().Contains("OldLady"))
        {
            _dialogueController._currentNode = _dialogueStartingNodes[1];
            if (_npcReaction == NPCSpeech.Idle)
            {
                _npcReaction = NPCSpeech.Talking;
                _dialoguebox.SetActive(true);
                _scene = SceneManager.GetActiveScene().name;
            }
        }
        else
        {
            base.OnEnable();
        }
    }
}
