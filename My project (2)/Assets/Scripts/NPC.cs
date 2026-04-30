using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NPCSpeech
{
    Idle, Talking
}

public enum InfectionState
{
    Stable, Infected, Critical
}

public abstract class NPC : MonoBehaviour
{
    public NPCSpeech _npcReaction;
    [SerializeField] private UIController _dialogue;
    [SerializeField] private GameObject _currentNPC;
    private DialogueNode _dialogueStartNode;
    public DialogueNode _currentNode;
    private int _currentLine = 0;
    private bool _waitingForPlayerResponse;
    public bool _appear = false;

    [SerializeField] public string _name;
    [SerializeField] private GameObject _dialoguebox;
    // all the areas the convo can start in 
    public DialogueNode[] _dialogueStartingNodes;
    private int _favorChange;

    private void Awake()
    {
         _currentNode = _dialogueStartingNodes[0];
    }

    private void Start()
    {
        if (_npcReaction == NPCSpeech.Idle) // if the NPC is in Idle then you can speak to them/ dialouge box shows up
        {
            _npcReaction = NPCSpeech.Talking;
            _dialoguebox.SetActive(true);
        }
    }

    void Update()
    {
        if (_npcReaction == NPCSpeech.Talking // lets NPC talk only when the player lets the speech advance with button presses
            && (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0)))
        {
            AdvanceDialogue();
        }
        Debug.Log("Player's total favor: " + Player.Instance._total);
    }

    public void AdvanceDialogue()
    {
        _favorChange = _currentNode._favor;
        Debug.Log("Favor change: " + _favorChange);
        if (_favorChange != 0)
        {
            Player.Instance._total = (Player.Instance._total + _favorChange);
        }
        if (_currentLine < _currentNode._lines.Length)
        {
            _dialogue.ShowDialogue(_currentNode._lines[_currentLine]);
            _currentLine++;
        }
        else if (_currentNode._playerReplyOptions != null && _currentNode._playerReplyOptions.Length > 0)
        {
            // show player dialogue choices
            _waitingForPlayerResponse = true;
            _dialogue.ShowPlayerOptions(_currentNode._playerReplyOptions);
        }
        else
        {
            // ends talking state if there is nothing left to talk about 
            EndDialogue();
        }
    }

    public void SelectedOption(int option)
    {
        _currentLine = 0;
        _waitingForPlayerResponse = false;

        _currentNode = _currentNode._npcReplies[option];
        AdvanceDialogue();
    }

    private void EndDialogue()
    {
        if (_currentNode._dead == true)
        {
            Destroy(_currentNPC);
        }
        Debug.Log("ended dialogue");
        _npcReaction = NPCSpeech.Idle;
        _dialoguebox.SetActive(false);
        _waitingForPlayerResponse = false;
        _currentNode = _dialogueStartNode;
        _currentLine = 0;
    }

    public NPC getNPC()
    {
       return this;
    }

    public string GetName()
    {
        return _name;
    }

    protected abstract void SetInfection();
}
