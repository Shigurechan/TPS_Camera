using System.Collections;
using System.Collections.Generic;
using UnityEngine;





namespace Player
{

    /*
     * #################################################
     *  �v���C���[�R���g���[��
     * #################################################
     */

    public class Control : MonoBehaviour
    {

        [SerializeField] const float walkSpeed = 10;    //�ړ����x
        [SerializeField] const float fallSpeed = 15;    //�������x
        [SerializeField] GameObject weapon;             //����
        private Vector3 moveSpeed;  
        private CharacterController controller;
        private Vector3 moveVector = new Vector3();


        void Start()
        {
            controller = GetComponent<CharacterController>();
        }

        void Update()
        {
            Animation();
            Move();
            Attack();
            Jump();
        }

        /*########################################## �A�j���[�V���� ##########################################*/
        private void Animation()
        {
            Vector3 move = Vector3.Scale(moveSpeed, new Vector3(1, 0, 1));
            GetComponent<CharacterController>().Move(moveSpeed * Time.deltaTime);    //�ړ�

            moveVector = move.normalized;  //�ړ�����
        }

    
        /*########################################## �ړ� ##########################################*/
        private void Move()
        {
            float inputHorizontal = Input.GetAxis("Left_Horizontal");
            float inputVertical = Input.GetAxis("Left_Vertical");

            Quaternion horizontalRotation = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y,Vector3.up);
            Vector3 velocity = horizontalRotation * new Vector3(inputHorizontal, 0, inputVertical�@* -1).normalized;

            if (velocity.magnitude > 0.3f)
            {
                Debug.Log("������");

                transform.rotation = Quaternion.LookRotation(velocity, transform.up);
                moveSpeed.x = (velocity * walkSpeed).x;
                moveSpeed.z = (velocity * walkSpeed).z;

            }
            else
            {
                moveSpeed.x = 0;
                moveSpeed.z = 0;
            }

            moveSpeed.y = -20;  //�����d��
        }


        private void Attack()
        {
            
        }


        private void Jump()
        {
            
        }

      

    }
}