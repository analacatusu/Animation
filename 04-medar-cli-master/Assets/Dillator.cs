using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dillator : MonoBehaviour
{
    public GameObject dillator;
    private readonly float scale = 0.001F;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            print("P was pressed");

            if (dillator.transform.localScale.x == 0 && dillator.transform.localScale.y == 0 && dillator.transform.localScale.z == 0)
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
        dillator.transform.localScale = new Vector3(scale, scale, scale);
    }

    public void StopAnimation()
    {
        dillator.transform.localScale = new Vector3(0, 0, 0);
    }
}
