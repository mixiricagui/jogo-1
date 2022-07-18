using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float pulo;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float movex = Input.GetAxisRaw("Horizontal");
        float movey = Input.GetAxisRaw("Vertical");

        rb.AddForce(new Vector3(speed * movex, 0));
        rb.AddForce(new Vector3(0, 1, speed * movey));

        Run();
    }

    void Run()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector3(0f, pulo, 0f), ForceMode.Impulse);
        }
    }
}
