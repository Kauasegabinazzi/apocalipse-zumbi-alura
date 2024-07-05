using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocidade = 20;

    private Rigidbody rigidbodyBala;

    private void Start()
    {
        rigidbodyBala = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidbodyBala.MovePosition(rigidbodyBala.position + transform.forward * velocidade * Time.deltaTime);

    }

    //Este m�todo a Unity nos fornece � bastante interessante porque ele recebe dentro de par�nteses um par�metro para guardar qual objeto colidiu com o objeto que tem o Script 
    void OnTriggerEnter(Collider objetoColisao)
    {
        if(objetoColisao.tag == "Inimigo")
        {
            Destroy(objetoColisao.gameObject);
        }

        //Desta forma estamos destruindo o pr�prio objeto que tem o Script que estamos criando.
        Destroy(gameObject);
    }
}
