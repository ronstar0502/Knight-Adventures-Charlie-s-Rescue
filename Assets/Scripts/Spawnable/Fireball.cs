using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    private Vector2 _startPoint,_endPoint;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetMovementAndRotation();
    }
    public void SetStartAndEndPoints(Vector2 startPoint,Vector2 endPoint)
    {
        _startPoint = startPoint;
        _endPoint = endPoint;
    }

    private void SetMovementAndRotation()
    {
        Vector2 direction = (_endPoint - _startPoint).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        rb.velocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<PlayerData>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
