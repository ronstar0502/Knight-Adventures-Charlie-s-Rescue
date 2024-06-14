using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerData playerData = other.gameObject.GetComponent<PlayerData>();
            playerData.TakeDamage(5);
        }
    }
}
