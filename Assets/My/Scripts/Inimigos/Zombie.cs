using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public int vida; //a vida que esse zombe terá
    public int type; //que tipo esse zumbie será
    public float velocidade;
    public Animator animador; //o animador que controlará as animações desse zumbie
    public Transform[] Lixo;//o lixo que será dropado

    private bool morreu = false;
    private float tempoDeSumir = 5;//o trempo que esse zumbie ficará morto no chão
    private float atualtempodead = 0;// o tempo que esse zuembie já está morto no chão
    public Transform controller; //O controlador geral

    // Start is called before the first frame update
    void Start()
    {
        //procura o controlador na cena
        controller = GameObject.FindGameObjectWithTag("Controller").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, Time.deltaTime * velocidade);
        animador.SetInteger("type", type);
        if (vida <= 0 && !morreu) {
            animador.SetBool("IsDead", true);
            Instantiate(Lixo[type], transform.position, transform.rotation);
            morreu = true;
        }

        if (morreu && atualtempodead <= tempoDeSumir) {
            velocidade = 0;
            atualtempodead += Time.deltaTime;
            }
        if (atualtempodead > tempoDeSumir) {
            Destroy(gameObject);
            GetComponentInParent<Onda>().quantidadeInimigo--;//decrementa a quantidade de inimigos na onda
            }
    }

    public void decrementaVida(int valor) {
        this.vida += valor;
    }
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
