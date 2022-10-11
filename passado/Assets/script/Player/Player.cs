using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //------VARIAVEIS PUBLICAS-----//

    public float speed;
    public float pulo;

    public bool ispulo;
    public bool puloduplo;

    public float NumeroScala;

    public static Player instance;

    //------ATIVAR-----//
    public GameObject pause;
    public GameObject inicio;

    public GameObject player;
    public GameObject parte2;
    public GameObject parte3;
    public GameObject cachorro;
    public GameObject cachorro1;
    public GameObject cachorro2;
    public GameObject cachorro3;
    public GameObject cachorro4;
    public GameObject cachorro5;
    public GameObject cachorro6;

    public GameObject EntrarMapa;
    public GameObject treino;
    
    //------PRIVATE-----//

    private Animator anin;
    private Rigidbody2D rb;




    [SerializeField]
    private List<string> ItemInventario = new List<string>();
    


    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        anin = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Pause();

        Move();
        Lado();
        Frente();

        if (Input.GetButtonDown("pause"))
        {
            pause.SetActive(true);
            Debug.Log("shjfdv");
        }
    }

    ////---MOVIMENTAÇAO----/////
    
    void Move()
    {
        Vector3 movimentox = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        Vector3 movimentoy = new Vector3(0f, Input.GetAxis("Vertical"), 0f);
        transform.position += movimentox * Time.deltaTime * speed;
        transform.position += movimentoy * Time.deltaTime * speed;

    }

    void Lado()
    {
        if (Input.GetAxis("Vertical") > 0f)
        {
            anin.SetBool("corendo fre", true);
        }
        if (Input.GetAxis("Vertical") < 0f)
        {
            anin.SetBool("corendo fre", true);
        }
        if (Input.GetAxis("Vertical") == 0f)
        {
            anin.SetBool("corendo fre", false);
        }
    }

    void Frente()
    {
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

    ////---INVENTARIO----/////

    public void AdicionarItem(string NomeItem)
    {
        ItemInventario.Add(NomeItem);
    }

    public bool TemItem(string nomeItem)
    {
        return ItemInventario.Contains(nomeItem);
    }

    ////---INTERAÇOES----/////
    
    public void Pause()
    {
        if (Input.GetButtonDown("pause"))
        {
            pause.SetActive(true);
            GetComponent<Rigidbody2D>().AddForce(Vector2.zero);
        }
        
    }

    ////---COLISOES----/////

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            inicio.SetActive(false);
            collision.gameObject.GetComponent<inimigopasaro>().Move();
            cachorro.SetActive(true);
            cachorro1.SetActive(true);
            
        }

        if (collision.gameObject.CompareTag("desbloquear2"))
        {
            parte2.SetActive(false);
            cachorro2.SetActive(true);
            cachorro3.SetActive(true);
            cachorro4.SetActive(true);
        }

        if (collision.gameObject.CompareTag("desbloquear3"))
        {
            parte3.SetActive(false);
            cachorro5.SetActive(true);
            cachorro6.SetActive(true);
            
        }

        if (collision.gameObject.layer == 3)
        {
            treino.gameObject.SetActive(true);
        }

        if (collision.gameObject.layer == 10)
        {
            EntrarMapa.gameObject.SetActive(true);
        }
    }

    ////---CAMPOS PUBLICOS----/////

    public void parar()
    {
        Destroy(gameObject);
    }

   

}
