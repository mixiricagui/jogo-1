using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2d : MonoBehaviour
{

    ///////------VARIAVEIS----//////

    ///////------VARIAVEIS PUBLICADS----//////
    public float speed;
    public float pulo;

    public bool ispulo;
    public bool puloduplo;

    [SerializeField]
    private float puloDano;

    public int vidaMaxima;
    public int vidaAtual;

    public GameObject finalfase;
    public GameObject pause;

    public static Player2d abc;
    ///////------VARIAVEIS PRIVADAS----//////
    [SerializeField]
    private GameObject bauF;
    [SerializeField]
    private GameObject bauA;
    [SerializeField]
    private Collider2D box;
    [SerializeField]
    private GameObject textoBau;

    private Animator anin;
    private Rigidbody2D rb;


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
        

        //Atack();
        Move();
        Pulo();

        Pause();

       

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
           transform.localScale = new Vector3(2, transform.localScale.y, transform.localScale.z);
        }
        if (Input.GetAxis("Horizontal") < 0f)
        {
            anin.SetBool("corendo", true);
            transform.localScale = new Vector3(-2, transform.localScale.y, transform.localScale.z);
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
            //anin.SetBool("pula", true);
        }
    }

   void Atack()
   {
        // if (Input.GetButton("atak"))
        // {
        //     anin.SetBool("atirando", true);
        // }
        // else
        // {
        // anin.SetBool("atirando", false);
        // }

        if (Input.GetButton("atak"))
        {
            bauA.SetActive(true);
            bauF.SetActive(false);

            Debug.Log("hiudf");
        }
   }


    void Pause()
    {
        if (Input.GetButton("pause"))
        {
            pause.SetActive(true);
        }
        
    }

    ///////------COLISAOES----//////

    void OnCollisionEnter2D(Collision2D collision)
    {
        //////////------PULO-------/////////

        if (collision.gameObject.layer == 6)
        {
            ispulo = false;
            anin.SetBool("pulo", false);
        }
        else
        {
            anin.SetBool("pulo", true);
        }

        //////////------TERMINO DE FASE-------/////////

        if (collision.gameObject.layer == 10)
        {
            finalfase.gameObject.SetActive(true);
        }

        //////////------BAU-------/////////
        
        if (collision.gameObject.CompareTag("ativar"))
        {
            textoBau.SetActive(true);
        }
        else
        {
            textoBau.SetActive(false);
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
        Destroy(gameObject,0.1f);
        anin.SetBool("dano", true);
    }
}
