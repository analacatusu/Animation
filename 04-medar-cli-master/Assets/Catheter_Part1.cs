using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catheter_Part1 : MonoBehaviour
{
    public GameObject catheter_1;
    private readonly float scale = 0.2F;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Appear()
    {
        catheter_1.transform.localScale = new Vector3(scale, scale, scale);
    }

    public void Disappear()
    {
        catheter_1.transform.localScale = new Vector3(0, 0, 0);
    }
}
