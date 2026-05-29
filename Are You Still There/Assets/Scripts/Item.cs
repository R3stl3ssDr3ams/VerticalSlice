using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item", menuName = "Scriptable Objects/Item")]

public class Item : ScriptableObject
{
    public string _description;
    public Texture _icon;
    public int _reAmp;
    public bool _cigarette;
}
