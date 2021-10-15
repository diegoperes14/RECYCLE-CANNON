using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public int vida;            //a vida que esse zombe terá
    public int type;            //que tipo esse zumbie será
    public float velocidade;    // A velocidade com que esse zombie irá se mover na tela
    public Animator animador;   //o animador que controlará as animações desse zumbie
    public Transform[] Lixo;    //o lixo que será dropado

    private bool morreu = false;        //Booleano que controlará o estado de vivo ou morto deste zombie
    private float tempoDeSumir = 5;     //o trempo que esse zumbie ficará morto no chão
    private float atualtempodead = 0;   // o tempo que esse zuembie já está morto no chão
    public Transform controller;        //O controlador geral

    // Start is called before the first frame update
    void Start()
    {
        //procura o controlador na cena
        controller = GameObject.FindGameObjectWithTag("Controller").transform;
    }

    // Update is called once per frame
    void Update()
    {   //fas o zombie andar e atualiza a animação conforme o tipo
        transform.Translate(0, 0, Time.deltaTime * velocidade);
        animador.SetInteger("type", type);

        //Atualiza a animação do zombie para morte, caso ele tenha zerado a vida, e instancia o lixo que será dropado.
        if (vida <= 0 && !morreu) {
            animador.SetBool("IsDead", true);
            Instantiate(Lixo[type], transform.position, transform.rotation);
            morreu = true;
        }

        //Confere há quanto tempo este zombie morreu, para poder tirá-lo da cena.
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

    //função que irá decrementar a vida do zombie
    public void decrementaVida(int valor) {
        this.vida += valor;
    }
    //detecta as colisões, comparando as tags
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
