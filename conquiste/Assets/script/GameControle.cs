using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControle : MonoBehaviour
{

    public int touscore;
    public Text scoretext;

    public GameObject gamerOver;
    public GameObject pause;
    public float speed;

    public static GameControle instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GamerOver()
    {
        gamerOver.SetActive(true);
    }

    public void restarte( string level)
    {
        SceneManager.LoadScene(level);
    }

     public void Menu()
     {
        SceneManager.LoadScene("menu");
     }

    public void Casa()
    {
        SceneManager.LoadScene("casa");
    }

    public void Pause()
    {
        if (Input.GetButton("pause"))
        {
            pause.SetActive(true);
        }
        
    }

    public void desPause()
    {
        pause.SetActive(false);
    }

}
