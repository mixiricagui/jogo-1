using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class velocidadeTiro : MonoBehaviour
{

    [SerializeField]
    private float velocidade;

    void Start()
    {
        var rb = GetComponent<Rigidbody2D>();

        rb.velocity = transform.right * velocidade;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            return;
        }

        Destroy(gameObject);
    }

}