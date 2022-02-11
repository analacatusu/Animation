using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catheter_Part2 : MonoBehaviour
{
    public GameObject catheter_2;
    private readonly float scale = 1.0F;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            print("S was pressed");

            if (catheter_2.transform.localScale.x == 0 && catheter_2.transform.localScale.y == 0 && catheter_2.transform.localScale.z == 0)
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
        catheter_2.transform.localScale = new Vector3(scale, scale, scale);
    }

    public void StopAnimation()
    {
        catheter_2.transform.localScale = new Vector3(0, 0, 0);
    }
}
