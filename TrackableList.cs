using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;

public class TrackableList : MonoBehaviour
{
    public float insertionDistance = 0.1f;
    public GameObject marker1 = null;
    public GameObject marker2 = null;
    // Start is called before the first frame update
    void Start()
    {
        //marker1 = this.transform.root.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float needleToModelDistance = Vector2.Distance(new Vector2(marker1.transform.position.x, marker1.transform.position.z),
            new Vector2(marker2.transform.position.x, marker2.transform.position.z));
        Debug.Log(needleToModelDistance);

        if(needleToModelDistance < insertionDistance)
        {
            Debug.Log("true");
        }
    }
}
