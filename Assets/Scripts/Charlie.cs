using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Charlie : MonoBehaviour
{
    [SerializeField] private int animationID;
    [SerializeField] private Transform startPoint,endPoint;
    [SerializeField] private float speed;
    private Animator animator;
    private Rigidbody2D rb;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        animator.SetInteger("animID", animationID);
        if(animationID == 2)
        {
            transform.position = startPoint.position;
        }
    }

    private void Update()
    {
        if (animationID==2)
        {
            CharlieWalk();
        }
    }

    private void CharlieWalk()
    {
        if(transform.position == endPoint.position)
        {
            transform.position = startPoint.position;
        }
        else
        {
            Vector2 direction = (endPoint.position - startPoint.position).normalized;
            rb.velocity = direction * speed * Time.deltaTime;
        }
    }
}
