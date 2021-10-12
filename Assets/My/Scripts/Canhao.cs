using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canhao : MonoBehaviour
{
    public int municao; //armazenar� as mini��es dispon�veis. Come�ar� com 10
    public Joystick joystick; //o Joystic que controlar� esse canh�o
    public Transform projetil; //o projetil que ser� atirado
    public AudioSource audioSource;//o audiosource desse canh�o
    public AudioClip tiro, lixo; //os sons de tiro e de lixo caindo na lixeira
    public int velocidade; //a velocidade com que esse canh�o ir� se mover na tela
    public Text municaoText;//O campo de texto que mostrar� a muni��o na tela

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
    //M�todo que faz o canh�o atirar
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
        this.municaoText.text = "Muni��o: " + municao;
    }
    //Metodo que adiciona muni��o no contador
    public void setMinicao(int municao) {
        this.municao += municao;
        atualizaTextoMunicao();
        audioSource.Stop();
        audioSource.clip = lixo;
        audioSource.Play();
    }
}
