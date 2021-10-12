using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onda : MonoBehaviour
{
    public int quantidadeInimigo;//será decrementado sempre que um inimigo morrer. Quando zerar, esse GameObject será destruído
    public Transform geraOnda; //o gerador de onda, que começará a contagem para a ´próxima onda quando esta for destruída
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
