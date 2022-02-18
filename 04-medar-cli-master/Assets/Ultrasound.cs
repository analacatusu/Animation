using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ultrasound : MonoBehaviour
{
    public GameObject ultrasound;
    private readonly float scale = 0.13F;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            print("N was pressed");

            if (ultrasound.transform.localScale.x == 0 && ultrasound.transform.localScale.y == 0 && ultrasound.transform.localScale.z == 0)
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
        ultrasound.transform.localScale = new Vector3(scale, scale, scale);
    }

    public void StopAnimation()
    {
        ultrasound.transform.localScale = new Vector3(0, 0, 0);
    }
}