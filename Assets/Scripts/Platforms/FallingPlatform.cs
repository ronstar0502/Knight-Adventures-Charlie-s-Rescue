using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] private float timeDelay = 1f;
    private Animator animator;
    private bool fallTriggered = false;
    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            fallTriggered = true;
        }        
        
    }
    private void Update()
    {
        timeDelay -= Time.deltaTime;
        if (fallTriggered && timeDelay<=0)
        {
            animator.enabled = true;
            animator.Play("Falling");
        }
    }
    public void DestroyPlatform()
    {
        Destroy(gameObject);
    }
}
