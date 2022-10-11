using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class butao : MonoBehaviour
{
    [SerializeField]
    private interagir interagir;
    [SerializeField]
    private UnityEvent botao;

    private bool executar;

    // Update is called once per frame
    void Update()
    {
        if (executar)
        {
            if (interagir.enteragir == true)
            {
                botao.Invoke();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        executar = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        executar = false;
    }
}
