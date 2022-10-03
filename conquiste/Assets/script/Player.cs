using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float pulo;

    public bool ispulo;
    public bool puloduplo;

    //private
    private Animator anin;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        anin = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Atack();
        Move();
        Pulo();

        GameControle.instance.Pause();

    }

    void Move()
    {
        Vector3 movimento = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movimento * Time.deltaTime * speed;

        if (Input.GetAxis("Horizontal") > 0f)
        {
            anin.SetBool("corendo", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        if (Input.GetAxis("Horizontal") < 0f)
        {
            anin.SetBool("corendo", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        if (Input.GetAxis("Horizontal") == 0f)
        {
            anin.SetBool("corendo", false);
        }
    }

    void Pulo()
    {
        if (Input.GetButtonDown("Jump") && !ispulo)
        {
            rb.AddForce(new Vector2(0f, pulo), ForceMode2D.Impulse);
            anin.SetBool("pulo", true);
        }
    }

    void Atack()
    {
        if (Input.GetButton("atak"))
        {
            anin.SetBool("atak", true);
        }
        else
        {
            anin.SetBool("atak", false);
        }
    }



    void OnCollisionEnter2D(Collision2D collision)
     {
        if (collision.gameObject.layer == 6)
        {
            ispulo = false;
            anin.SetBool("pulo", false);
        }

        if (collision.gameObject.tag == "atacks")
        {
            GameControle.instance.GamerOver();
            Destroy(gameObject);
        }
     }
   

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            ispulo = true;
        }
    }


}
