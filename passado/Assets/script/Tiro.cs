using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{

    [SerializeField]
    private Transform posisaoTiro;
    [SerializeField]
    private GameObject tiro;
    private float tempo;
    private Animator anin;

    private void Start()
    {
        anin = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Atirar();
        }
    }

    private void Atirar()
    {
        Instantiate(tiro, posisaoTiro.position, posisaoTiro.rotation);
    }

    
}
