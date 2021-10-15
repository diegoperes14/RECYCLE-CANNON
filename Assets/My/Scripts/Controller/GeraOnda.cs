using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeraOnda : MonoBehaviour
{
    /*Esta Classe irá controlar as ondas de inimigos que aparecem na tela após um determinado tempo
     * 
    */
    public Transform[] ondas;       //as ondas que atacarão o jogador
    public Text textoOnda;          //o texto que exibirá as informações da onda na tela
    public float tempoEntreOndas;   //o tempo entre uma onda e outra
    private int contaOnda;          //irá conferir quantas ondas já foram chamadas
    private float tempoPassado;     //o tempo passado desde a última onda
    public bool iniciaOnda;         //irá guardar o valor para quando uma onda precisar ser iniciada
    // Start is called before the first frame update
    void Start()
    {
        //inicia como 0 o valor das ondas já passadas e como verdadeiro o booleano que indica que pode iniciar a contagem
        contaOnda = 0;
        iniciaOnda = true;
    }

    // Update is called once per frame
    void Update()
    {
        //atualiza o contador na tela nos intervalos entre as ondas
        if (iniciaOnda && contaOnda < ondas.Length) {
            tempoPassado += Time.deltaTime;
            textoOnda.text = "Próxima onda em " + (tempoEntreOndas - tempoPassado).ToString("0.00");
        }
        //instancia uma onda de inimigos na cena caso a contagem tenha atingido o limite
        if (tempoPassado >= tempoEntreOndas) {
            if (contaOnda < ondas.Length) {
                ondas[contaOnda].GetComponent<Onda>().geraOnda = this.transform;
                Instantiate(ondas[contaOnda],transform.position, transform.rotation);
            }
            tempoPassado = 0;                       //zera o contador para a próxima onda
            contaOnda++;                            //incrementa o contador de ondas para o gerenciador saber qual será a próxima
            textoOnda.text = contaOnda + "ª Onda";  //atualiza o texto na tela para mostrar qual a onda atul
            iniciaOnda = false;                     //deixa em false o iniciaOnda até que a atual onda seja totalmente destruída
        }
        //informa quando o jogador tives destruído a última onda
        if (contaOnda >= ondas.Length && iniciaOnda) {
            GetComponent<GameOverController>().YouWin();
        }
        
    }
}
