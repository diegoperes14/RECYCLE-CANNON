using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onda : MonoBehaviour
{
    public int quantidadeInimigo;//ser� decrementado sempre que um inimigo morrer. Quando zerar, esse GameObject ser� destru�do
    public Transform geraOnda; //o gerador de onda, que come�ar� a contagem para a �pr�xima onda quando esta for destru�da
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (quantidadeInimigo <= 0) {
            geraOnda.GetComponent<GeraOnda>().iniciaOnda = true;
            Destroy(gameObject);
        }
    }

}
