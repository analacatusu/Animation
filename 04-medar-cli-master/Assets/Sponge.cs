using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sponge : MonoBehaviour
{
    public GameObject sponge;
    private readonly float scale = 100F;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            print("caps lock was pressed");

            if (sponge.transform.localScale.x == 0 && sponge.transform.localScale.y == 0 && sponge.transform.localScale.z == 0)
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
        sponge.transform.localScale = new Vector3(scale, scale, scale);
    }

    public void StopAnimation()
    {
        sponge.transform.localScale = new Vector3(0, 0, 0);
    }
}
