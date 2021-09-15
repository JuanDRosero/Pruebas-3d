using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JugadorController : MonoBehaviour
{
    public float mouseSpeed = 100f;
    public Transform cam;

    private float mouseX;
    private float mouseY;
    private float yReal = 0.0f;

    //Movimiento
    public CharacterController controller;
    public float speed = 12f;
    float x;
    float z;
    Vector3 move;

    //Gravedad
    Vector3 velocity;           //Al usar el CharacterController no se puede usar un rigidbody por lo que hay que crear una gravedad artifical
    public float gravity = -15f;
    bool isGrouned = false;

    //Salto
    public float jumpForce = 1f;
    float jumpValue;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        jumpValue = Mathf.Sqrt(jumpForce * -2 * gravity);
    }

    void Update()
    {
        lookMouse();
        if (isGrouned &&velocity.y<0)   
        {
            velocity.y = gravity;   //Reinicia la gravedad
        }
        movement();
        jump();
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    void lookMouse()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime;
        yReal -= mouseY;
        yReal = Mathf.Clamp(yReal, -90f, 90f);    //Evita que el jugador pueda mirar mas de 90° o menos de 90°

        cam.localRotation = Quaternion.Euler(yReal, 0f, 0f);

        transform.Rotate(Vector3.up * mouseX);
    }
    void movement()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
    }

    private void jump()
    {
        if (Input.GetButtonDown("Jump")&& isGrouned)
        {
            isGrouned = false;
            velocity.y = jumpValue;
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("Floor"))       //Todo lo que sea piso debe tener el tag floor
        {
            if (isGrouned==false)
            {
                isGrouned = true;
            }
        }
    }
    private bool puedeTransportar()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
}
