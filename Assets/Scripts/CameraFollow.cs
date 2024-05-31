using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new Vector3(0,0,-10f);

    private void LateUpdate()
    {
        if (target != null)
        {
            FollowTarget();
        }
    }

    private void FollowTarget()
    {
        Vector3 targetPosition = target.position+offset;
        transform.position = Vector3.Lerp(transform.position,targetPosition,Time.deltaTime*5f);
    }
}
