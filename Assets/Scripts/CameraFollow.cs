using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;

    public Vector3 offset;


    // Update is called once per frame
    void FixedUpdate()
    {   
        if (target == null) return;

        Vector3 delta = target.position;

        Vector3 desiredPosition = new Vector3(delta.x, delta.y, delta.z) + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
