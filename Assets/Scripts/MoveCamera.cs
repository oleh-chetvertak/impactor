using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Camera targetCamera;  
    private const float moveDistanceBackward = 500f; 
    private const float moveDistanceLeft = 100f;
    private const float moveSpeed = 1f;
    private const float smoothTime = 0.3f; // чем меньше, тем быстрее движение

    private Vector3 targetPosition;
    private bool isMoving = false;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        if (targetCamera == null)
            targetCamera = Camera.main;

        targetPosition = targetCamera.transform.position;
    }

    public void MoveBack()
    {
        Vector3 backDirection = -targetCamera.transform.forward * moveDistanceBackward;
        Vector3 leftDirection = -targetCamera.transform.right * moveDistanceLeft;

        targetPosition += backDirection + leftDirection;

        isMoving = true;
    }

    void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);


            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                transform.position = targetPosition;
                isMoving = false;
            }
        }
    }
}
