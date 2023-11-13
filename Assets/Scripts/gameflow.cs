using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameflow : MonoBehaviour
{
    public Transform goobleObj;
    public int randYcoor;
    public string spawnDelay = "n";
    // Start is called before the first frame update
    void Start()
    {
        
    }

        // Update is called once per frame
        void Update()
        {
            if (spawnDelay == "n") { 
            randYcoor = Random.Range (0, 3);
                Instantiate(goobleObj, new Vector3(15, randYcoor, 0), goobleObj.rotation);
                spawnDelay = "y";
                StartCoroutine (resetSpawnTimer ());
            }
        }
    IEnumerator resetSpawnTimer()
    {
        yield return new WaitForSeconds (2);
        spawnDelay = "n";
    }
    }
