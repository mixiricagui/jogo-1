using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bau : MonoBehaviour
{
    /// <summary>
    /// VARIAVEIS
    /// </summary>
    [SerializeField]
    private GameObject BauAberto;
    [SerializeField]
    private GameObject BauFechado;
    [SerializeField]
    private GameObject texto;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ativar"))
        {
            texto.SetActive(true);
        }
        else
        {
            texto.SetActive(false);
        }

        if (collision.gameObject.CompareTag("Player") && Input.GetButtonDown("interagir"))
        {
            BauFechado.SetActive(false);
            BauAberto.SetActive(true);
        }
    }
}
