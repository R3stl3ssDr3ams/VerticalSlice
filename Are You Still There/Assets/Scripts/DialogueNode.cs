using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueNode", menuName = "Scriptable Objects/DialogueNode")]
public class DialogueNode : ScriptableObject
{
    public string npcName;
    public string[] _lines;
    public string[] _playerReplyOptions;
    public DialogueNode[] _npcReplies;
    public bool _behindDoor;
    public bool _dead;
    public bool _end;
    public bool _intro;
    public bool _final;
    public int _favor;
    public int _trigger;
    public int _requirement;
    public int _investigation;
    public int _execute;
    public int _tire;
    public string _name;
    public bool _skip;
    public Item _item;
}
