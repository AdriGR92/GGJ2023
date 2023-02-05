using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public GameObject body;
    public float speed;
    [SerializeField] private float jumpForce;
    private Rigidbody rigidbody;
    private CameraMovement cam;

    [Header("GroundCheck")]
    public bool isGrounded;
    public LayerMask groundMask;
    public Transform groundCheck;
    [SerializeField] private float widthGroundCheck = 0.2f;
    [SerializeField] private float heightGroundCheck = 0.2f;
    [SerializeField] private float deepGroundCheck = 0.5f;

    

    private void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {

        /*if (VirtualInputManager.Instance.MoveRight && VirtualInputManager.Instance.MoveLeft)
        {
            return;
        }
        if (VirtualInputManager.Instance.MoveRight)
        {
            this.gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
            body.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        if (VirtualInputManager.Instance.MoveLeft)
        {
            this.gameObject.transform.Translate(-Vector3.right * speed * Time.deltaTime);
            body.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }*/

        Movement();
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            GameManager.instance.ManagePlatforms(!GameManager.instance.isActivePlatforms);
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, GameManager.instance.limit.position.x, Camera.main.transform.position.x + 18), transform.position.y, transform.position.z);
    }

    private void FixedUpdate()
    {
        Collider[] colls = Physics.OverlapBox(groundCheck.position, new Vector3(widthGroundCheck, heightGroundCheck, deepGroundCheck), Quaternion.identity, groundMask);
        isGrounded = colls.Length > 0;
    }

    private void OnDrawGizmos()
    {
        // indicamos el color del gizmo
        Gizmos.color = Color.white;
        // dibujamos un cubo en la posición indicada
        Gizmos.DrawCube(groundCheck.position, new Vector3(widthGroundCheck, heightGroundCheck, deepGroundCheck));
    }

    private void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * horizontal * speed * Time.deltaTime);
    }

    private void Jump()
    {
        rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Waypoint"))
        {
            GameManager.instance.checkPoint = other.transform;
            StartCoroutine(cam.Movimiento(other.transform.parent, this));
        }

        if (other.CompareTag("Spike") || other.CompareTag("Fall"))
        {
            GameManager.instance.RespawnLevel(gameObject);
        }

    }

}


