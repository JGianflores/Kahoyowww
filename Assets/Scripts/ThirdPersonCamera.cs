using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target; // Player to follow
    public Vector3 offset = new Vector3(0f, 3f, -6f); // Camera offset from the player
    public float sensitivity = 2f;
    public float distance = 6f;
    public float minY = -30f;
    public float maxY = 60f;

    private float currentX = 0f;
    private float currentY = 20f;

    void LateUpdate()
    {
        currentX += Input.GetAxis("Mouse X") * sensitivity;
        currentY -= Input.GetAxis("Mouse Y") * sensitivity;
        currentY = Mathf.Clamp(currentY, minY, maxY);

        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        Vector3 direction = rotation * new Vector3(0, 0, -distance);
        transform.position = target.position + direction + new Vector3(0, offset.y, 0);
        transform.LookAt(target.position + Vector3.up * 1.5f); // Look at player's upper body
    }
}
