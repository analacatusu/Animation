using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddShader : MonoBehaviour
{
    public Material mat;

    void Update()
    {
        mat.SetVector("_CenterPoint", transform.position);
    }
}
