using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace CameraControl
{

    /*
   * #################################################
   *  カメラコントロール
   *  シネマシーンコンポーネントでヴァーチャルカメラを指定　bodyはFraming Trannsposer　aimはPov
   *  
   *  
   * #################################################
   */
    public class CameraControl : MonoBehaviour
    {



        public GameObject player;
   
        [SerializeField] const float rotateSpeed = 100;     //回転速度
        [SerializeField] const float viewRange = 10;        //視界距離
        [SerializeField] const float inputAxisMoveValue = 0.3f;


        public float getRotateSpeed()
        {
            return rotateSpeed;
        }


        private Vector3 offset; //プレイヤーとの距離

        void Start()
        {

        }

        void Update()
        {
            Rotate();       //カメラ回転
        }

        void LateUpdate()
        {

        }

        /*########################################## カメラ　回転 ##########################################*/
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