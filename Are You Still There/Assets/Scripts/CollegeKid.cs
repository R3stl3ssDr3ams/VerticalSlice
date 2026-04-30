using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollegeKid : NPC
{
    protected override void EndDialogue()
    {
        SetInfection();
        base.EndDialogue();
    }
    protected override void SetInfection()
    {
        switch(_player._total)
        {
            case <= 0:
                _infectionState = InfectionState.Critical;
                break;
            case > 0 and <= 10:
                _infectionState = InfectionState.Infected;
                break;
            case > 10:
                _infectionState = InfectionState.Stable;
                break;
        }
    }
}
