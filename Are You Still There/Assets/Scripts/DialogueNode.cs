using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueNode", menuName = "Scriptable Objects/NewScriptableObjectScript")]
public class DialogueNode : ScriptableObject
{
    public string npcName;
    public string[] _lines;
    public int _favor;
    public int _trigger;
    public string[] _playerReplyOptions;
    public DialogueNode[] _npcReplies;
    public bool _dead;
}
