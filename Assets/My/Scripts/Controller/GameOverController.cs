using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public Transform painelgameOver;
    public Transform painelYouWin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver() {
        painelgameOver.gameObject.SetActive(true);
    }
    public void YouWin() {
        painelYouWin.gameObject.SetActive(true);
    }
    public void LoadScene(int ID) {
        SceneManager.LoadScene(ID, LoadSceneMode.Single);
    }
}
