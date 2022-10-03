using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigo : MonoBehaviour
{
    [SerializeField]
    private float speed;
    
    public static inimigo instance;
    private Animator anin;
    [SerializeField]
    private float tempo;
    [SerializeField]
    private int vidaMaxima;
    [SerializeField]
    private int vidaAtual;


    void Start()
    {
        vidaAtual = vidaMaxima;
        instance = this;
        anin = GetComponent<Animator>();
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

     public void OnCollisionEnter2D(Collision2D collision)
     {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<VidaPersonagem>().Dano();
            playerplataform2d.abc.dano();
            Player2d.abc.dano();
        }
     }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("tiroPlayer"))
        {
            Morte();
        }
    }

    public void Morte()
    {

        Destroy(gameObject, tempo);
        anin.SetBool("morteC", true);
        
    }
}
