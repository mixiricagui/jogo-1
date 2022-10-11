using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interagir : MonoBehaviour
{
    public bool enteragir { get; set; }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("interagir"))
        {
            enteragir = true;
        }
        else
        {
            enteragir = false;
        }
    }
}
