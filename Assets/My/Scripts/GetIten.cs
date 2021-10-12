using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetIten : MonoBehaviour
    {
    public Vector3 positionItem; //a posição que o item coletado receberá
    public GameObject ItemColetado;//este será o ítem que será coletado
    public Transform canhao;
    public bool pegou; //irá guardar o valor para quando o jogador pegar o lixo
    public bool encostou; //irá guardar o valor para quando o jogador apenas encostar no lixo;

    // Start is called before the first frame update
    void Start() {

        }

    // Update is called once per frame
    void Update() {

        }
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Lixo")) {
            if (!pegou) {
                ItemColetado = other.gameObject;
                encostou = true;
            }
        }
        //Bloco que gerencia a entrega de lixo na lixeira
        if (other.gameObject.CompareTag("Lixeira")) {
            print("Colidiu com a lixeira");
            if (pegou) {
                if (ItemColetado.GetComponent<Lixo>().getType() == other.GetComponent<Lixeira>().getType()) {
                    canhao.GetComponent<Canhao>().setMinicao(5); //adiciona a munição ao canhão
                    ItemColetado.transform.SetParent(null);      
                    Destroy(ItemColetado);                       //destroi o lixo
                    this.ItemColetado = null;
                    pegou = false;
                    encostou = false;
                }
            }
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Lixo")) {
            encostou = false;
        }
    }
    public void coletaItem() {
        if (pegou) {//faz o player soltar o objeto lixo coletado
            ItemColetado.transform.SetParent(null);
            this.ItemColetado = null;
            pegou = false;
            encostou = false;
        }
        if (ItemColetado != null && !pegou && encostou ) {//faz o player coletar o objeto lixo
            ItemColetado.transform.SetParent(this.transform);
            ItemColetado.transform.localPosition = positionItem;
            pegou = true;
            encostou = false;
        }

        
    }
}
