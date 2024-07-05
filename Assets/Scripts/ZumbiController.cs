using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZumbiController : MonoBehaviour
{
    public GameObject player;

    public float velocidade = 5;
    private Rigidbody rigidbodyZumbi;

    private Animator animatorZumbi;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyZumbi = GetComponent<Rigidbody>();
        animatorZumbi = GetComponent<Animator>();

        player = GameObject.FindWithTag("jogador");

        int geraTipoZumbi = Random.Range(1, 28);

        transform.GetChild(geraTipoZumbi).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        //calcular a dist�ncia entre dois pontos. Queremos calcular a dist�ncia entre duas posi��es a posi��o do jogador, que temos o objeto salvo numa vari�vel de nome jogador, e a posi��o do nosso inimigo que � o objeto com o Script que estamos criando

        float distancia = Vector3.Distance(transform.position, player.transform.position);

        // um vetor de dire��o que pega a posi��o do jogador mas leva em considera��o onde nosso inimigo est� posicionado.

        Vector3 direcao = player.transform.position - transform.position;

        Quaternion novaRotacao = Quaternion.LookRotation(direcao);

        rigidbodyZumbi.MoveRotation(novaRotacao);

        if (distancia > 2.5)
        {
            rigidbodyZumbi.MovePosition(rigidbodyZumbi.position + direcao.normalized * velocidade * Time.deltaTime);

            animatorZumbi.SetBool("atacando", false);
        }
        else
        {
            animatorZumbi.SetBool("atacando", true);
        }
    }

    void AtacaPlayer()
    {
        // jogo vai pausar
        Time.timeScale = 0;
        player.GetComponent<JogadorController>().TextGameOver.SetActive(true);
        player.GetComponent<JogadorController>().alive = false;
    }
}
