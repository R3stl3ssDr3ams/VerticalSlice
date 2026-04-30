using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private NPC _npc;
    public delegate void ObjectDelegate(GameObject o);
    public event ObjectDelegate Interacted;
    public List<GameObject> _inventory;
    public List<string> _inventoryString;
    public int _total = 0;
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
