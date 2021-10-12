using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canhao : MonoBehaviour
{
    public int municao; //armazenará as minições disponíveis. Começará com 10
    public Joystick joystick; //o Joystic que controlará esse canhão
    public Transform projetil; //o projetil que será atirado
    public AudioSource audioSource;//o audiosource desse canhão
    public AudioClip tiro, lixo; //os sons de tiro e de lixo caindo na lixeira
    public int velocidade; //a velocidade com que esse canhão irá se mover na tela
    public Text municaoText;//O campo de texto que mostrará a munição na tela

    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > -3.6f && joystick.Horizontal < 0) {
            transform.Translate(joystick.Horizontal * Time.deltaTime * velocidade, 0, 0);
        }
        if (transform.position.x < 3.5f && joystick.Horizontal > 0) {
            transform.Translate(joystick.Horizontal * Time.deltaTime * velocidade, 0, 0);
        }
    }
    //Método que faz o canhão atirar
    public void atirar() {
        if (municao > 0) {
            audioSource.Stop();
            audioSource.clip = tiro;
            audioSource.Play();
            Instantiate(projetil, transform.position, projetil.rotation);
            municao--;
            atualizaTextoMunicao();
        }
        
    }
    //Metodo que atualiza o texto em tela
    private void atualizaTextoMunicao() {
        this.municaoText.text = "Munição: " + municao;
    }
    //Metodo que adiciona munição no contador
    public void setMinicao(int municao) {
        this.municao += municao;
        atualizaTextoMunicao();
        audioSource.Stop();
        audioSource.clip = lixo;
        audioSource.Play();
    }
}
