using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace CameraControl
{

    /*
   * #################################################
   *  �J�����R���g���[��
   *  �V�l�}�V�[���R���|�[�l���g�Ń��@�[�`�����J�������w��@body��Framing Trannsposer�@aim��Pov
   *  
   *  
   * #################################################
   */
    public class CameraControl : MonoBehaviour
    {



        public GameObject player;
   
        [SerializeField] const float rotateSpeed = 100;     //��]���x
        [SerializeField] const float viewRange = 10;        //���E����
        [SerializeField] const float inputAxisMoveValue = 0.3f;


        public float getRotateSpeed()
        {
            return rotateSpeed;
        }


        private Vector3 offset; //�v���C���[�Ƃ̋���

        void Start()
        {

        }

        void Update()
        {
            Rotate();       //�J������]
        }

        void LateUpdate()
        {

        }

        /*########################################## �J�����@��] ##########################################*/
        private void Rotate()
        { 
            float horizontal = Input.GetAxis("Right_Horizontal");
            float vertical = Input.GetAxis("Right_Vertical");


            if( Mathf.Abs(vertical) > inputAxisMoveValue)
            {
               GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_InputAxisValue = vertical * -1;
            }
            else
            {
                GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_InputAxisValue = 0;
            }

            if (Mathf.Abs(horizontal) > inputAxisMoveValue)
            {
                GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_InputAxisValue = horizontal;
            }
            else
            {
                GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_InputAxisValue = 0;
            }


            //GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_InputAxisValue = 0;

        }
    }

}