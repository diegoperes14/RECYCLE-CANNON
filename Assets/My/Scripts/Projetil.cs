using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{
    public float velocidade;
    public int potencia;//o valor que este projétil irá causar de dano
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, Time.deltaTime * velocidade, 0);
        if (transform.position.z >= 25) {
            Destroy(gameObject);
        }
    }
    public int getDemage() {
        return potencia;
    }
}
