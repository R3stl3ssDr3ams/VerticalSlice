using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private NPC _npc;
    public delegate void ObjectDelegate(GameObject o);
    public event ObjectDelegate Interacted;
    public List<Item> _inventory;
    public Item[] _inventoryarray;
    public List<string> _inventoryString;
    [SerializeField] public int _energy = 3;
    [SerializeField] public int _total = 0;
    [SerializeField] public int _investigation = 0;
    public bool _murderer = false;
    public static Player Instance { get; private set; }
    public Player _player { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }


        Instance = this;

        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
