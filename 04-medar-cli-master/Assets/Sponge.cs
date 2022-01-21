using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sponge : MonoBehaviour
{
    public GameObject sponge;
    private float scale = 100F;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            print("capslock was pressed");

            if (sponge.transform.localScale.x == 0 && sponge.transform.localScale.y == 0 && sponge.transform.localScale.z == 0)
            {
                start_animation();
            }
            else
            {
                stop_animation();
            }


        }

    }
    public void start_animation()
    {
        sponge.transform.localScale = new Vector3(scale, scale, scale);
    }

    public void stop_animation()
    {
        sponge.transform.localScale = new Vector3(0, 0, 0);
    }
}
