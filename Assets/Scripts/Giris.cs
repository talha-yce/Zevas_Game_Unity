using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Giris : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene("Sahne 1");
    }

    public void Bilgi()
    {
        SceneManager.LoadScene("Bilgiler");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Girisekran()
    {
        SceneManager.LoadScene("Giris");
    }
}
