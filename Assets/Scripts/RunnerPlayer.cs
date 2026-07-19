using UnityEngine;

public class RunnerPlayer : MonoBehaviour
{
    public float speed = 15f;
    public float jumpForce = 7f;
    public Transform cameraTransform;
    public float mouseSensitivity = 2f;

    private Rigidbody rb;
    private bool isGrounded = true;
    private Vector3 originalScale;
    private float xRotation = 0f;
    private float yRotation = 0f;
    private bool isFirstFrame = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalScale = transform.localScale;
        Cursor.lockState = CursorLockMode.Locked;

        xRotation = 0f;
        yRotation = 0f;
        cameraTransform.localRotation = Quaternion.Euler(0f, 0f, 0f);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && isGrounded)
        {
            transform.localScale = new Vector3(originalScale.x, originalScale.y * 0.5f, originalScale.z);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            transform.localScale = originalScale;
        }

        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity;

        if (isFirstFrame)
        {
            mouseX = 0f;
            mouseY = 0f;
            isFirstFrame = false;
        }

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        yRotation += mouseX;
        yRotation = Mathf.Clamp(yRotation, -135f, 135f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }

    void FixedUpdate()
    {
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}