using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target Settings")]
    [SerializeField] private Transform target; // Drag the Player here
    [SerializeField] private float smoothTime = 0.3f; // How long it takes to catch up
    [SerializeField] private Vector3 offset = new Vector3(0, 0, -10); // Maintain distance on Z axis

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (target == null) return;

        // Target position with the desired offset
        Vector3 targetPosition = target.position + offset;

        // Smoothly move the camera towards the target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
