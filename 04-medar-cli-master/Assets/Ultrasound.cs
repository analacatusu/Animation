using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ultrasound : MonoBehaviour
{
    public GameObject ultrasound;
    private readonly float scale = 0.13F;
   /* public Material mat1;
    public Material mat2;
    public Material mat3;
    public Material mat4;
    public Material mat5;*/
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        /* if (Input.GetKeyDown(KeyCode.N))
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


         }*/
        /*mat1.SetVector("_CenterPoint", transform.position);
        mat2.SetVector("_CenterPoint", transform.position);
        mat3.SetVector("_CenterPoint", transform.position);
        mat4.SetVector("_CenterPoint", transform.position);
        mat5.SetVector("_CenterPoint", transform.position);
*/
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