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
            _endText.text = "You got rid of the infected and enjoyed a quiet night in the appartment. You are safe for now.";
        }
        else if (Player.Instance._total == 6 && Player.Instance._murderer == true)
        {
            _endText.text = "You formed a tight bond with Lee and got rid of the infected in the area. Now, go enjoy a couple beers with him!";
        }
        else
        {
            _endText.text = "The infected still roam the apartment. You are not safe.";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
