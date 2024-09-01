using UnityEngine;

public class TankMovement : MonoBehaviour
{
    // Movement variables
    public float movementSpeed = 5f;
    public float rotationSpeed = 100f;
    public float spinSpeed = 90f;

    // References to the tank parts
    public Transform turret;
    public Transform hull;
    public Transform tracks;
    public Transform dulo;

    private Rigidbody rb;
    private float forwardMovement;
    private float horizontalMovement;

    // Camera
    public Transform mainCamera;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        forwardMovement = Input.GetAxis("Vertical");

        float mouse = Input.GetAxis("Mouse X");
        dulo.Rotate(Vector3.forward * mouse * 10f * Time.deltaTime);

        if(Input.GetKey(KeyCode.Q))
        {
            turret.transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            turret.transform.Rotate(Vector3.forward, -spinSpeed * Time.deltaTime);
        }

        #region unused
        //float mouseX = Input.GetAxis("Mouse X");

        //float turretRotationAngle = -mouseX * rotationSpeed * Time.deltaTime;

        //turret.Rotate(0f, 0f, turretRotationAngle);
        //return;
        //if(mainCamera != null)
        //{
        //    mainCamera.Translate(movement.x, movement.y, movement.z);
        //    mainCamera.Rotate(0f, turretRotationAngle, 0f);
        //}
        #endregion
    }
    private void FixedUpdate()
    {
        MoveTank(-forwardMovement);
        RotateTank(-horizontalMovement);
    }
    void MoveTank(float input)
    {
        Vector3 moveDirection = transform.up * input * movementSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + moveDirection);
    }
    void RotateTank(float input)
    {
        float rotation = input * rotationSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, 0f, rotation);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}