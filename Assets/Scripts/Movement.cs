using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController controller;
    public KeyCode inputup = KeyCode.UpArrow;
    public KeyCode inputdown = KeyCode.DownArrow;
    public float sidewaysSpeed;

    private Vector3 direction;
    private int desiredLane = 1; // upper lane = 0, middel lane = 1, lower lane = 2
    public float laneDistance = 20; // the length between lanes
    

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        direction.x = sidewaysSpeed;

        if (Input.GetKeyDown(inputup)) 
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
     
        }
        
        if (Input.GetKeyDown(inputdown))
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;

        }

        // Calculation of new position

        Vector3 newPosition = transform.right + transform.position.z *  transform.position.y * transform.right;

        if (desiredLane == 0)
        {
            newPosition += Vector3.down * laneDistance;
        } 
        else if (desiredLane == 2) 
        {
            newPosition += Vector3.up * laneDistance;
        }

        transform.position = Vector3.Lerp(transform.position,newPosition,4*Time.deltaTime);
    }

  

}
