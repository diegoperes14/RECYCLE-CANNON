using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeraOnda : MonoBehaviour
{
    public Transform[] ondas;//as ondas que atacar�o o jogador
    public Text textoOnda; //o texto que exibir� as informa��es da onda na tela
    public float tempoEntreOndas;//o tempo entre uma onda e outra
    private int contaOnda; //ir� conferir quantas ondas j� foram chamadas
    private float tempoPassado;//o tempo passado desde a �ltima onda
    public bool iniciaOnda;//ir� guardar o valor para quando uma onda precisar ser iniciada
    // Start is called before the first frame update
    void Start()
    {
        contaOnda = 0;
        iniciaOnda = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (iniciaOnda && contaOnda < ondas.Length) {
            tempoPassado += Time.deltaTime;
            textoOnda.text = "Pr�xima onda em " + (tempoEntreOndas - tempoPassado).ToString("0.00");
        }
        if (tempoPassado >= tempoEntreOndas) {
            if (contaOnda < ondas.Length) {
                ondas[contaOnda].GetComponent<Onda>().geraOnda = this.transform;
                Instantiate(ondas[contaOnda],transform.position, transform.rotation);
            }
            tempoPassado = 0;
            contaOnda++;
            textoOnda.text = contaOnda + "� Onda";
            iniciaOnda = false;
        }
        if (contaOnda >= ondas.Length && iniciaOnda) {
            GetComponent<GameOverController>().YouWin();
        }
        
    }
}
