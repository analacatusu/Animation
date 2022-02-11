using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    public GameObject wire;
    private readonly float scale = 1.0F;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            print("N was pressed");

            if (wire.transform.localScale.x == 0 && wire.transform.localScale.y == 0 && wire.transform.localScale.z == 0)
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
        wire.transform.localScale = new Vector3(scale, scale, scale);
    }

    public void StopAnimation()
    {
        wire.transform.localScale = new Vector3(0, 0, 0);
    }
}
