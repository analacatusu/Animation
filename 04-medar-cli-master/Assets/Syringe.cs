using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class Syringe : MonoBehaviour
    {
        public GameObject OBJECT1;
        private readonly float scale = 0.05F;
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                print("space key was pressed");

                if (OBJECT1.transform.localScale.x == 0 && OBJECT1.transform.localScale.y == 0 && OBJECT1.transform.localScale.z == 0)
                {
                    StartAnimation();
                }
                else
                {
                    StopAnimation();
                }


            }

        }
        public void StartAnimation()
        {
            OBJECT1.transform.localScale = new Vector3(scale, scale, scale);
        }

        public void StopAnimation()
        {
            OBJECT1.transform.localScale = new Vector3(0, 0, 0);
        }
    }
