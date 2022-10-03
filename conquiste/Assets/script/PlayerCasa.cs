using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCasa : MonoBehaviour
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
        Move();
        
        Lado();
        Frente();
    }

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
            anin.SetBool("corendoF", true);
        }
        if (Input.GetAxis("Vertical") < 0f)
        {
            anin.SetBool("corendoF", true);
        }
        if (Input.GetAxis("Vertical") == 0f)
        {
            anin.SetBool("corendoF", false);
        }
    }

    void Frente()
    {
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



}
