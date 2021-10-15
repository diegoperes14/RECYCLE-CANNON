using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onda : MonoBehaviour
{
    /*Este objeto ser� instanciado na cena e como filhos dele estar�o os zonbies
     * quando um zombie � derrotado, o contador de zombies neste objeto decrementar�, e
     * quando atigir zero, esse objeto ser� destru�do da cena, para desocupar mem�ria.
     */
    public int quantidadeInimigo;//ser� decrementado sempre que um inimigo morrer. Quando zerar, esse GameObject ser� destru�do
    public Transform geraOnda; //o gerador de onda, que come�ar� a contagem para a �pr�xima onda quando esta for destru�da
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Se o n�mero de inimigos zerar, destroi este objeto da cena.
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
