using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assessment1
{
    public class DynamicCamera : MonoBehaviour
    {
        public GameObject Player;
        public Transform Movement_Direction;
        public Transform Target;
        public Transform BoneTarget;
        public float CamSpeed = 80;
        public float RotateSpeed = 80;
        public Transform Pivot2;
        public bool Forward;
        public Transform Original_Direction;
        public Transform Left_Direction;
        public Transform Right_Direction;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void LateUpdate()
        {
            if (Player.GetComponent<Transform>().eulerAngles.y == Player.GetComponent<PlayerMovement>().Forward_Transform.eulerAngles.y)
            {
                Pivot2.rotation = Quaternion.RotateTowards(Pivot2.rotation, Original_Direction.rotation, Time.deltaTime * RotateSpeed);
            }

            if (Player.GetComponent<Transform>().eulerAngles.y == Player.GetComponent<PlayerMovement>().Back_Transform.eulerAngles.y)
            {
                Pivot2.rotation = Quaternion.RotateTowards(Pivot2.rotation, Original_Direction.rotation, Time.deltaTime * RotateSpeed);
            }

            if (Player.GetComponent<Transform>().eulerAngles.y == Player.GetComponent<PlayerMovement>().Forward_Left_Transform.eulerAngles.y)
            {
                Pivot2.rotation = Quaternion.RotateTowards(Pivot2.rotation, Left_Direction.rotation, Time.deltaTime * RotateSpeed);
            }

            if (Player.GetComponent<Transform>().eulerAngles.y == Player.GetComponent<PlayerMovement>().Forward_Right_Transform.eulerAngles.y)
            {
                Pivot2.rotation = Quaternion.RotateTowards(Pivot2.rotation, Right_Direction.rotation, Time.deltaTime * RotateSpeed);
            }

            if (Player.GetComponent<Transform>().eulerAngles.y == Player.GetComponent<PlayerMovement>().Back_Left_Transform.eulerAngles.y)
            {
                Pivot2.rotation = Quaternion.RotateTowards(Pivot2.rotation, Right_Direction.rotation, Time.deltaTime * RotateSpeed);
            }

            if (Player.GetComponent<Transform>().eulerAngles.y == Player.GetComponent<PlayerMovement>().Back_Right_Transform.eulerAngles.y)
            {
                Pivot2.rotation = Quaternion.RotateTowards(Pivot2.rotation, Left_Direction.rotation, Time.deltaTime * RotateSpeed);
            }

            if (Player.GetComponent<Renderer>().enabled == false)
            {
                gameObject.GetComponent<Transform>().position = Vector3.Lerp(gameObject.GetComponent<Transform>().position, Target.position, Time.deltaTime * 10);
            }
            else
            {
                gameObject.GetComponent<Transform>().position = Vector3.Lerp(gameObject.GetComponent<Transform>().position, BoneTarget.position, Time.deltaTime * 10);
            }
            if (Player.GetComponent<PlayerMovement>().Moving == false)
            {
                gameObject.GetComponent<Transform>().rotation = Quaternion.RotateTowards(gameObject.GetComponent<Transform>().rotation, Target.rotation, Time.deltaTime * CamSpeed);
            }
        }
    }
}
