using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerplataform2d : MonoBehaviour
{

    ///////------VARIAVEIS----//////

    ///////------VARIAVEIS PUBLICADS----//////
    public float speed;
    public float pulo;

    public bool ispulo;
    public bool puloduplo;

    public int vidaMaxima;
    public int vidaAtual;

    public GameObject finalfase;

    public static playerplataform2d abc;
    ///////------VARIAVEIS PRIVADAS----//////
    private Animator anin;
    private Rigidbody2D rb;
    [SerializeField]
    private float puloDano = 6;

    // Start is called before the first frame update
    void Start()
    {
        vidaAtual = vidaMaxima;

        abc = this;

        anin = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Atack();
        Move();
        Pulo();

        //GameControle.instance.Pause();

    }

    ///////------PRIVADAS----//////

    void Move()
    {
        Vector3 movimento = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movimento * Time.deltaTime * speed;

        if (Input.GetAxis("Horizontal") > 0f)
        {
            anin.SetBool("corendo", true);
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
        if (Input.GetAxis("Horizontal") < 0f)
        {
            anin.SetBool("corendo", true);
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }
        if (Input.GetAxis("Horizontal") == 0f)
        {
            anin.SetBool("corendo", false);
        }
    }

    void Pulo()
    {
        if (Input.GetButtonDown("Jump") && ispulo == false)
        {
            rb.AddForce(new Vector2(0f, pulo), ForceMode2D.Impulse);
            anin.SetBool("pulo", true);
        }
        else
        {
            anin.SetBool("pulo", false);
        }
    }

    void Atack()
    {
        if (Input.GetButton("atak"))
        {
            anin.SetBool("atirando", true);
        }
        else
        {
            anin.SetBool("atirando", false);
        }
    }

    ///////------COLISAOES----//////

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            ispulo = false;
            anin.SetBool("pular", false);
        }

        if (collision.gameObject.tag == "atacks")
        {
            //GameControle.instance.GamerOver();
            //Destroy(gameObject);
        }

        if (collision.gameObject.layer == 10)
        {
            finalfase.gameObject.SetActive(true);
        }

    }


    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            ispulo = true;
        }




    }

    ///////------PUBLICAS----//////
    public void dano()
    {
        rb.AddForce(new Vector2(0f, puloDano), ForceMode2D.Impulse);
        anin.SetBool("pular", true);
    }

    public void parar()
    {
        Destroy(gameObject, 1f);
        
        anin.SetBool("dano", true);
    }

    ///////------itens----//////
    
    public void Arma()
    {
        if (Input.GetButton("arma"))
        {

        }
    }

}

