using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goobleatt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(-4, 0, 0);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
