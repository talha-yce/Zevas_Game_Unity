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
            // D��man objesiyle etkile�im ger�ekle�ti�inde yap�lacak i�lemler burada olacak
            Debug.Log("D��manla etkile�im ger�ekle�ti!");
        }
        else if (collision.CompareTag("Reward"))
        {
            // �d�l objesiyle etkile�im ger�ekle�ti�inde yap�lacak i�lemler burada olacak
            Debug.Log("�d�lle etkile�im ger�ekle�ti!");
        }
    }

}
