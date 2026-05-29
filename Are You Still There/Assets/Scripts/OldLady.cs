using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldLady : NPC
{
    protected override void OnEnable()
    {
        _reset.text = "...";
        _dialogueController._NPC = gameObject;
        _dialogueController._currentNPC = gameObject.GetComponent<NPC>();
        base.OnEnable();
    }
}
