using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Syringe2 : MonoBehaviour
{
    public GameObject syringe;
    private readonly float scale = 0.01F;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            print("F was pressed");

            if (syringe.transform.localScale.x == 0 && syringe.transform.localScale.y == 0 && syringe.transform.localScale.z == 0)
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
        syringe.transform.localScale = new Vector3(scale, scale, scale);
    }

    public void StopAnimation()
    {
        syringe.transform.localScale = new Vector3(0, 0, 0);
    }
}
