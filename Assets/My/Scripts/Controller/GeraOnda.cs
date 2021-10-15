using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeraOnda : MonoBehaviour
{
    /*Esta Classe ir� controlar as ondas de inimigos que aparecem na tela ap�s um determinado tempo
     * 
    */
    public Transform[] ondas;       //as ondas que atacar�o o jogador
    public Text textoOnda;          //o texto que exibir� as informa��es da onda na tela
    public float tempoEntreOndas;   //o tempo entre uma onda e outra
    private int contaOnda;          //ir� conferir quantas ondas j� foram chamadas
    private float tempoPassado;     //o tempo passado desde a �ltima onda
    public bool iniciaOnda;         //ir� guardar o valor para quando uma onda precisar ser iniciada
    // Start is called before the first frame update
    void Start()
    {
        //inicia como 0 o valor das ondas j� passadas e como verdadeiro o booleano que indica que pode iniciar a contagem
        contaOnda = 0;
        iniciaOnda = true;
    }

    // Update is called once per frame
    void Update()
    {
        //atualiza o contador na tela nos intervalos entre as ondas
        if (iniciaOnda && contaOnda < ondas.Length) {
            tempoPassado += Time.deltaTime;
            textoOnda.text = "Pr�xima onda em " + (tempoEntreOndas - tempoPassado).ToString("0.00");
        }
        //instancia uma onda de inimigos na cena caso a contagem tenha atingido o limite
        if (tempoPassado >= tempoEntreOndas) {
            if (contaOnda < ondas.Length) {
                ondas[contaOnda].GetComponent<Onda>().geraOnda = this.transform;
                Instantiate(ondas[contaOnda],transform.position, transform.rotation);
            }
            tempoPassado = 0;                       //zera o contador para a pr�xima onda
            contaOnda++;                            //incrementa o contador de ondas para o gerenciador saber qual ser� a pr�xima
            textoOnda.text = contaOnda + "� Onda";  //atualiza o texto na tela para mostrar qual a onda atul
            iniciaOnda = false;                     //deixa em false o iniciaOnda at� que a atual onda seja totalmente destru�da
        }
        //informa quando o jogador tives destru�do a �ltima onda
        if (contaOnda >= ondas.Length && iniciaOnda) {
            GetComponent<GameOverController>().YouWin();
        }
        
    }
}
