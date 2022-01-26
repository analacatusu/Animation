using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public GameObject heart;
    private readonly float scale = 1.0F;
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
        heart.transform.localScale = new Vector3(scale, scale, scale);
    }

    public void Disappear()
    {
        heart.transform.localScale = new Vector3(0, 0, 0);
    }
}
