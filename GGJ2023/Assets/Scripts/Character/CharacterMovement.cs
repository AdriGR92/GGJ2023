using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace firstpart
{
    public class CharacterMovement : MonoBehaviour
    {
        //
        public float speed;
        [SerializeField] private float jumpForce;
        private Rigidbody rigidbody;

        [Header("GroundCheck")]
        public bool isGrounded;
        public LayerMask groundMask;
        public Transform groundCheck;
        [SerializeField] private float widthGroundCheck = 0.2f;
        [SerializeField] private float heightGroundCheck = 0.2f;
        [SerializeField] private float deepGroundCheck = 0.5f;

        private void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        void Update()
        {
            if (VirtualInputManager.Instance.MoveRight && VirtualInputManager.Instance.MoveLeft)
            {
                return;
            }
            if (VirtualInputManager.Instance.MoveRight)
            {
                this.gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
                this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }

            if (VirtualInputManager.Instance.MoveLeft)
            {
                this.gameObject.transform.Translate(-Vector3.right * speed * Time.deltaTime);
                this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }


            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                Jump();
            }
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

        private void Jump()
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}

