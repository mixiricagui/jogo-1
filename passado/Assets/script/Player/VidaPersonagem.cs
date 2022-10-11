using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaPersonagem : MonoBehaviour
{
    

    void Start()
    {
        GameControle.instance.atualizarVida();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Dano()
    {
        GameControle.instance.Setvida(-1);
        
    }
}
