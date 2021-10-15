using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public int vida;            //a vida que esse zombe ter�
    public int type;            //que tipo esse zumbie ser�
    public float velocidade;    // A velocidade com que esse zombie ir� se mover na tela
    public Animator animador;   //o animador que controlar� as anima��es desse zumbie
    public Transform[] Lixo;    //o lixo que ser� dropado

    private bool morreu = false;        //Booleano que controlar� o estado de vivo ou morto deste zombie
    private float tempoDeSumir = 5;     //o trempo que esse zumbie ficar� morto no ch�o
    private float atualtempodead = 0;   // o tempo que esse zuembie j� est� morto no ch�o
    public Transform controller;        //O controlador geral

    // Start is called before the first frame update
    void Start()
    {
        //procura o controlador na cena
        controller = GameObject.FindGameObjectWithTag("Controller").transform;
    }

    // Update is called once per frame
    void Update()
    {   //fas o zombie andar e atualiza a anima��o conforme o tipo
        transform.Translate(0, 0, Time.deltaTime * velocidade);
        animador.SetInteger("type", type);

        //Atualiza a anima��o do zombie para morte, caso ele tenha zerado a vida, e instancia o lixo que ser� dropado.
        if (vida <= 0 && !morreu) {
            animador.SetBool("IsDead", true);
            Instantiate(Lixo[type], transform.position, transform.rotation);
            morreu = true;
        }

        //Confere h� quanto tempo este zombie morreu, para poder tir�-lo da cena.
        if (morreu && atualtempodead <= tempoDeSumir) {
            velocidade = 0;
            atualtempodead += Time.deltaTime;
        }
        //Destroi esse zombie e informa para o Gerenciador de onda que um zombie morreu
        if (atualtempodead > tempoDeSumir) {
            Destroy(gameObject);
            GetComponentInParent<Onda>().setQntInimigo(-1);//decrementa a quantidade de inimigos na onda
        }
    }

    //fun��o que ir� decrementar a vida do zombie
    public void decrementaVida(int valor) {
        this.vida += valor;
    }
    //detecta as colis�es, comparando as tags
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Projetil")) {
            if (vida > 0) {
                decrementaVida(other.GetComponent<Projetil>().getDemage() * (-1));
                Destroy(other.gameObject);
            }
        }
        if (other.gameObject.CompareTag("Goal")) {
            controller.GetComponent<GameOverController>().GameOver();
        }
    }
}
