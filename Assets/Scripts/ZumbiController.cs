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
        //calcular a distância entre dois pontos. Queremos calcular a distância entre duas posições a posição do jogador, que temos o objeto salvo numa variável de nome jogador, e a posição do nosso inimigo que é o objeto com o Script que estamos criando

        float distancia = Vector3.Distance(transform.position, player.transform.position);

        // um vetor de direção que pega a posição do jogador mas leva em consideração onde nosso inimigo está posicionado.

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
