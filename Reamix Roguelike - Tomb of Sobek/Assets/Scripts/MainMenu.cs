using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Canvas firstCanvas;
    public Canvas secondCanvas;
    public Canvas thirdCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SwitchCanvas1()
    {
        firstCanvas.gameObject.SetActive(false);
        secondCanvas.gameObject.SetActive(true);
        thirdCanvas.gameObject.SetActive(false);
    }
    public void SwitchCanvas2()
    {
        firstCanvas.gameObject.SetActive(false);
        secondCanvas.gameObject.SetActive(false);
        thirdCanvas.gameObject.SetActive(true);
    }

    public void changeScene()
    {
        SceneManager.LoadScene("Room Creation");
    }

    public void quitGame()
    {
        Application.Quit();
    }


}
