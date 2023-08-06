using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class npc_control : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float minIdleTime = 1f;
    public float maxIdleTime = 5f;
    public float waitTimeBeforeMoving = 1f;

    private Rigidbody2D rb;
    private Animator animator;
    private bool isRunning = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isRunning)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x)); // Animator'daki "Speed" parametresini güncelle

            if (rb.velocity.x > 0)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else if (rb.velocity.x < 0)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
    }

    private IEnumerator IdleAndRun()
    {
        isRunning = false;
        animator.SetBool("isRunning", false);
        rb.velocity = Vector2.zero;

        float idleTime = Random.Range(minIdleTime, maxIdleTime);
        yield return new WaitForSeconds(waitTimeBeforeMoving);
        FlipDirection();
        isRunning = true;
        animator.SetBool("isRunning", true);
        animator.SetTrigger("StartRunning"); // Animasyon tetikleyicisi eklendi
        yield return new WaitForSeconds(idleTime);

        FlipDirection();
        isRunning = true;
        animator.SetBool("isRunning", true);
        animator.SetTrigger("StartRunning"); // Animasyon tetikleyicisi eklendi
    }

    private void FlipDirection()
    {
        moveSpeed *= -1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("sinir"))
        {
            StartCoroutine(IdleAndRun());
        }
    }
}

