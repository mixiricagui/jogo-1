using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    public GameObject aria;
    [SerializeField]
    private float tempoAttack;
    private bool Flip;


    void Rotacionar()
    {
        if (Flip)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col != null && !col.CompareTag("Player") && !col.CompareTag("chao")
            && !col.CompareTag("inimigo"))
        {
            Flip = !Flip;
        }

        Rotacionar();

        if (col.CompareTag("player"))
        {
            aria.SetActive(true);
            Tempo();
            aria.SetActive(false);

        }
    }

    private IEnumerator Tempo()
    {
        yield return new WaitForSeconds(tempoAttack);
    }
}
