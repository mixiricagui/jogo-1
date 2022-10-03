using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControle : MonoBehaviour
{
    public Text vidaTexto;
    public int vidas = 3;
    public int tempo;

    public GameObject gameover;
    public GameObject naofase;

    public static GameControle instance;

    public GameObject sumirvida;
    public GameObject transicao;
    public GameObject naotreino;


    void Start()
    {
        instance = this;
    }

    public void Setvida(int vida)
    {
        vidas += vida;
        atualizarVida();

        if (vidas <= 0)
        {
            sumirvida.SetActive(false);
            Debug.Log("adg");
            gameover.SetActive(true);
            Player2d.abc.parar();
            playerplataform2d.abc.parar();
            
        }
        else if (vidas > 0)
        {
            sumirvida.SetActive(true);
        }
    }

    public void Vidainimigo(int vida)
    {
        vidas += vida;

        if (vidas <= 0)
        {
            inimigo.instance.Morte();
        }
    }

    public void atualizarVida()
    {
        vidaTexto.text = vidas.ToString();
    }

    public void ProximaFase(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void naocomesar()
    {
        naofase.gameObject.SetActive(false);
    }

    public void naocomecartreino()
    {
        naotreino.gameObject.SetActive(false);
    }
}
