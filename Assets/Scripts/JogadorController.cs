using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JogadorController : MonoBehaviour
{
    public float velocidade = 10;

    Vector3 direcao;

    public LayerMask mascaraChao;

    public GameObject TextGameOver;

    public bool alive = true;

    private Rigidbody rigidbodyPlayer;

    private Animator animatorPlayer;

    private void Start()
    {
        Time.timeScale = 1;
        rigidbodyPlayer = GetComponent<Rigidbody>();
        animatorPlayer = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Inputs do player - Guardando teclas apertadas

        float eixoX = Input.GetAxis("Horizontal"); // esquerda e direita
        float eixoZ = Input.GetAxis("Vertical"); // frente e tras

        direcao = new Vector3(eixoX, 0, eixoZ);
       
        //Anima��es do Jogador

        if (direcao != Vector3.zero)
        {
           animatorPlayer.SetBool("IsRunning", true);
        }
        else
        {
           animatorPlayer.SetBool("IsRunning", false);
        }

        if(alive == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("game");
            }
        }

        //Vector3.zero � 0 em x, y, z;
    }

     void FixedUpdate()

    {   //Movimenta��o do Jogador por segundo atraves da fisica
        rigidbodyPlayer.MovePosition(rigidbodyPlayer.position + (direcao * velocidade * Time.deltaTime));

        // adicionado na variavel a posicao do mouse atraves da camera

        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(raio.origin, raio.direction * 100, Color.red);

        // criado um impacto
        RaycastHit impact;

        //raycat foi juntado o raio s� bate nas camdas de mascarachao com o impacto
        if (Physics.Raycast(raio, out impact, 100, mascaraChao))
        {
            // apartidar da posicao do impacto para aonde eu estou � gerado uma posicao mirar
            Vector3 posicaoMiraPlayer = impact.point - transform.position;

            // cancelado o y para ficar na mesma altura
            posicaoMiraPlayer.y = transform.position.y;

            // � calculado a rota��o a partir da posicao do jogador vai ter 
            Quaternion novaRotacao = Quaternion.LookRotation(posicaoMiraPlayer);

            // ai � s� adicionar no personagem
            rigidbodyPlayer.MoveRotation(novaRotacao);
        }
    }
}

// PEGA UM EIXO
// FLOAT - 0.5

//transform.Translate(direcao * velocidade * Time.deltaTime);

// direcao * Time.deltaTime - vai movimentar 10 blocos 10 vez por segundo 

//transform.Translate(Vector3.forward);

// pegando a propriedade transforme e movimentando para frente
//Na Unity, quando queremos movimentar um objeto na Cena, podemos utilizar a ferramenta de movimenta��o, mexendo assim no Transform do objeto e em espec�fico na parte de Posi��o.
//Vector3.right, Vector3.left, Vector3.down, Vector3.up, Vector3.back 

//Atrav�s da LayerMask podemos criar uma m�scara de colis�o, filtrando as colis�es e ignorando objetos que n�o estamos interessados em fazer nosso raio colidir, utilizando as camadas (Layers) da Unity para isso.
// utilizar o Physics.Raycast como forma de lan�ar um raio tendo uma dire��o e origem. Podemos atrav�s dele recuperar a colis�o com objetos.