using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigopasaro : MonoBehaviour
{
    public float speed;
    public static inimigopasaro instance;
    public float raio;
    public Transform alvo;
    public Rigidbody2D rig;
    public BoxCollider2D col2d;
    public float speed2;
    public float tempo;
    public Transform player;

    

    [SerializeField]
    private LayerMask ariavisao;
    private Animator anim;
    void Start()
    {
        instance = this;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Procurar();
        if (this.alvo != null)
        {
            Moveratras();
            anim.SetBool("atack", true);
            
        }
        else
        {
            Move();
            anim.SetBool("atack", false);
        }
    }

    public void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        
    }



    public void Moveratras()
    {
       // Vector2 posicaoAlvo = this.alvo.position;
       // Vector2 posicaoAtual = this.transform.position;

       // Vector2 direcao = posicaoAlvo - posicaoAtual;
        //direcao = direcao.normalized;

        this.rig.gravityScale = 3;

        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, this.raio);
    }

    private void Procurar()
    {
        Collider2D colisor = Physics2D.OverlapCircle(this.transform.position, this.raio, this.ariavisao);
        
        if (colisor != null)
        {
            this.alvo = colisor.transform;
        }
        else
        {
            this.alvo = null;
        }
    }

     
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<VidaPersonagem>().Dano();
            Player2d.abc.dano();
        }

        if (collision.gameObject.tag.Equals("tiroPlayer"))
        {
            Destroy(gameObject, tempo);
            anim.SetBool("colide", true);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Destroy(gameObject, tempo);
            anim.SetBool("colide", true);
           
            this.GetComponent<BoxCollider2D>().isTrigger = true;
            this.rig.gravityScale = 0;
            
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<VidaPersonagem>().Dano();

            Destroy(gameObject, tempo);
            anim.SetBool("colide", true);
            
            this.GetComponent<BoxCollider2D>().isTrigger = true;
            this.rig.gravityScale = 0;
            
            Player2d.abc.dano();
        }

        if (collision.gameObject.CompareTag("inimigo"))
        {

            Destroy(gameObject, tempo);
            anim.SetBool("colide", true);
           
            this.GetComponent<BoxCollider2D>().isTrigger = true;
            this.rig.gravityScale = 0;
            
        }
    }

   
}
