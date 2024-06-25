using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform platform,startPoint , endPoint;
    private int direction = 1;

    private void Update()
    {
        PlatformMovement();
    }

    private void PlatformMovement()
    {
        Vector2 targetPosition = SetNextPoint();
        platform.position = Vector2.MoveTowards(platform.position, targetPosition,speed*Time.deltaTime);  
        float distance = (targetPosition - (Vector2)platform.position).magnitude;

        if (distance < 0.1f)
        {
            direction *= -1;
        }

    }

    private Vector2 SetNextPoint()
    {
        if (direction == 1)
        {
            return endPoint.position;
        }else
        {
            return startPoint.position;
        }
    }

    private void OnDrawGizmos()
    {
        if(startPoint!=null && endPoint != null)
        {
            Gizmos.DrawLine(platform.position,startPoint.position);
            Gizmos.DrawLine(platform.position,endPoint.position);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("Player on Platform");
            collision.gameObject.transform.SetParent(platform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("Player off Platform");
            collision.gameObject.transform.SetParent(null);
        }
    }
}
