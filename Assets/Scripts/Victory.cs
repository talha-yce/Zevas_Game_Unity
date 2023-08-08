using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    int sonsahne_no;

    // Start is called before the first frame update
    void Start()
    {
        sonsahne_no = PlayerPrefs.GetInt("son_sahne_no");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Tekrar()
    {
        SceneManager.LoadScene("Sahne " + sonsahne_no + "");
    }
    public void Sonraki()
    {
        SceneManager.LoadScene("Sahne " + (sonsahne_no+1) + "");
    }
}

