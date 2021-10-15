using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onda : MonoBehaviour
{
    /*Este objeto será instanciado na cena e como filhos dele estarão os zonbies
     * quando um zombie é derrotado, o contador de zombies neste objeto decrementará, e
     * quando atigir zero, esse objeto será destruído da cena, para desocupar memória.
     */
    public int quantidadeInimigo;//será decrementado sempre que um inimigo morrer. Quando zerar, esse GameObject será destruído
    public Transform geraOnda; //o gerador de onda, que começará a contagem para a ´próxima onda quando esta for destruída
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Se o número de inimigos zerar, destroi este objeto da cena.
        if (quantidadeInimigo <= 0) {
            geraOnda.GetComponent<GeraOnda>().iniciaOnda = true;
            Destroy(gameObject);
        }
    }

    //altera o 
    public void setQntInimigo(int valor) {
        this.quantidadeInimigo += valor;
    }

}
