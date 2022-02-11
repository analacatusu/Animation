using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainKiller : MonoBehaviour
{
    public GameObject painKiller;
    private readonly float scale = 0.8F;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            print("key: M was pressed");

            if (painKiller.transform.localScale.x == 0 && painKiller.transform.localScale.y == 0 && painKiller.transform.localScale.z == 0)
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
        painKiller.transform.localScale = new Vector3(scale, scale, scale);
    }

    public void StopAnimation()
    {
        painKiller.transform.localScale = new Vector3(0, 0, 0);
    }
}
