using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace firstpart
{
    public class CharacterMovement : MonoBehaviour
    {
        //
        public float speed;

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
        }
    }
}

