using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private Player _player;
    private string _savedScene;
    public static SceneController Instance;
    private void Start()
    {
        Instance = this;
        _player = Player.Instance;
    }

    public void SenttoMain()
    {
        SceneManager.LoadScene("Main");
    }
    public void SendtoEnd()
    {
        SceneManager.LoadScene("End");
    }
    public void SendtoStart() 
    { 
        SceneManager.LoadScene("Start");
    }
}
