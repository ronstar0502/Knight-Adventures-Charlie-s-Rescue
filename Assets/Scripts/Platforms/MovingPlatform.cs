using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private bool isPlayerOnPlatform;

    private void OnCollisionEnter2D(Collision2D collision)
    {     
        if(collision.gameObject.CompareTag("Player"))
        {
            print("Player on Platform");
            isPlayerOnPlatform = true;
            collision.gameObject.transform.SetParent(gameObject.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        print("Player off Platform");
        isPlayerOnPlatform = false;
        collision.gameObject.transform.SetParent(null);
    }
}
