using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oyun_Yonetim : MonoBehaviour
{
    private Animator anim;
    bool dead = false;
    public int can = 5;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dusman"))
        {
            can--;
            // Düþman objesiyle etkileþim gerçekleþtiðinde yapýlacak iþlemler burada olacak
            Debug.Log("Düþmanla etkileþim gerçekleþti!");
        }
        else if (collision.CompareTag("Reward"))
        {
            // Ödül objesiyle etkileþim gerçekleþtiðinde yapýlacak iþlemler burada olacak
            Debug.Log("Ödülle etkileþim gerçekleþti!");
        }
    }

}
