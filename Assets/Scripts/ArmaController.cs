using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaController : MonoBehaviour
{
    public GameObject Bala;

    public GameObject CanoArma;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // testa se o botão do mouse for apertado
        if (Input.GetButtonDown("Fire1"))
        {
            // cria novos objetos (bala)
            Instantiate(Bala, CanoArma.transform.position, CanoArma.transform.rotation);

        }
         
    }
}
