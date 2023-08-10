using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;


public class Oyun_Yonetim : MonoBehaviour
{

    public int sonsahne_no;

    
    private Animator anim;
    private bool dead = false;
    public int can = 3;
    private bool gameOver = false;

    void Start()
    {
        
        sonsahne_no = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("son_sahne_no", sonsahne_no);
        // Ýlk baþta, "gameOver" deðerini false olarak ayarlayýn.
        gameOver = false;

    }

    void Update()
    {

       


        if (can == 0 && !gameOver)
        {
            gameOver = true;
            StartCoroutine(LoadGameOverSceneAfterDelay(1f));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dusman"))
        {
            if (can > 0)
                can--;
            Debug.Log("Düþmanla etkileþim gerçekleþti!");
        }
        else if (collision.CompareTag("odul"))
        {
            can++;
            Destroy(collision.gameObject);
            Debug.Log("Ödülle etkileþim gerçekleþti!");
        }
        else if (collision.CompareTag("sinir"))
        {
            can = 0;
            Destroy(collision.gameObject);
            Debug.Log("Sýnýr etkileþim gerçekleþti!");
        }
        else if (collision.CompareTag("finish"))
        {
            StartCoroutine(LoadVictorySceneAfterDelay(0.5f));
        }
    }

    private IEnumerator LoadGameOverSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Game_Ower");
    }
    private IEnumerator LoadVictorySceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Victory");
    }

}
