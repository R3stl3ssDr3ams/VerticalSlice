using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class End : MonoBehaviour
{
    [SerializeField] private TMP_Text _endText;
    void Start()
    {
        if (Player.Instance._murderer == true)
        {
            _endText.text = "The day is over. As hours pass you wonder if you made the right decisions. It doesn't matter. What's done is done, now all you can do is press on.";
        }
        else if (Player.Instance._total == 6 && Player.Instance._murderer == true)
        {
            _endText.text = "As the moonlight descends gently through your window, you are glad that you have found a good friend in Lee. Hopefully you can keep each other safe in the coming days.";
        }
        else
        {
            _endText.text = "The clock strikes twelve. As you fall asleep, you wonder just how many of your neighbors may already be infected...";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
