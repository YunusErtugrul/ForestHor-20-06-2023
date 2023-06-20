using UnityEngine;

public class LookAround : MonoBehaviour
{
    public Transform playerTransform;
    public float rotationSpeed = 5f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

        playerTransform.Rotate(Vector3.up * mouseX);
    }
}
