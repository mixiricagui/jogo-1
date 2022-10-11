using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bau : MonoBehaviour
{
    /// <summary>
    /// VARIAVEIS PUBLICAS
    /// </summary>
    
    
    
    public float raio;
    public Transform alvo;
    public Transform player;

    /// <summary>
    /// VARIAVEIS PRIVADAS
    /// </summary>

    [SerializeField]
    private LayerMask ariavisao;
    [SerializeField]
    private GameObject BauAberto;
    [SerializeField]
    private GameObject BauFechado;
    [SerializeField]
    private GameObject texto;

    void Update()
    {
        
        
    }

    public void Bau()
    {
            BauAberto.SetActive(true);
            BauFechado.SetActive(false);

            Debug.Log("hgdf");
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
}
