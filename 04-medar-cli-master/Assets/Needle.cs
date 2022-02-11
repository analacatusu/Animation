using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needle : MonoBehaviour
{
    public GameObject needle;
    private readonly float scale = 0.4F;
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
        needle.transform.localScale = new Vector3(scale, scale, scale);
    }

    public void Disappear()
    {
        needle.transform.localScale = new Vector3(0, 0, 0);
    }
}
