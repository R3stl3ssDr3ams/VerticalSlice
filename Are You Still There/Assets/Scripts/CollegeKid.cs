using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollegeKid : NPC
{
    protected override void EndDialogue()
    {
        gameObject.GetComponent<ScriptMachine>();
        CustomEvent.Trigger(gameObject, "SetInfection", _player._total);
        //SetInfection();
        base.EndDialogue();
    }
    //protected override void SetInfection()
    //{
        //if (_player._total >= 10)
        //{
            //_infectionState = InfectionState.Stable;
        //}
        //else if (_player._total >= 5)
        //{
            //_infectionState = InfectionState.Infected;
        //}
         //else
        //{
            //_infectionState = InfectionState.Critical; ;
        //}
    //}
}
