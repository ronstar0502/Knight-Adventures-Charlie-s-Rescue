using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform platfrom,startPoint , endPoint;
    private int direction = 1;
    //private bool isPlayerOnPlatform;

    private void Update()
    {
        PlatformMovement();
    }

    private void PlatformMovement()
    {
        Vector2 targetPosition = SetNextPoint();
        platfrom.position = Vector2.MoveTowards(platfrom.position, targetPosition,speed*Time.deltaTime);  
        float distance = (targetPosition - (Vector2)platfrom.position).magnitude;

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
            Gizmos.DrawLine(platfrom.position,startPoint.position);
            Gizmos.DrawLine(platfrom.position,endPoint.position);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {     
        if(collision.gameObject.CompareTag("Player"))
        {
            print("Player on Platform");
            //isPlayerOnPlatform = true;
            collision.gameObject.transform.SetParent(gameObject.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        print("Player off Platform");
        //isPlayerOnPlatform = false;
        collision.gameObject.transform.SetParent(null);
    }
}
