using UnityEngine;

public class goobleatt : MonoBehaviour
{
    public Vector3 startspeed = new Vector3(-20, 0, 0);
    public Vector3 medspeed = new Vector3(-40, 0, 0);
    public Vector3 fastspeed = new Vector3(-60, 0, 0);
    public float timeThreshold1 = 50;
    public float timeThreshold2 = 100;
    public float transitionDuration = 10; // Adjust this value for the duration of the speed transition

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = startspeed;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.time);

        if (Time.time >= timeThreshold1 && Time.time < timeThreshold2)
        {
            ChangeSpeed(startspeed, medspeed, timeThreshold1);
            Debug.Log("Medspeed reached for gooble");
        }
        else if (Time.time >= timeThreshold2)
        {
            ChangeSpeed(medspeed, fastspeed, timeThreshold2);
            Debug.Log("Fastspeed reached gooble");
        }
    }

    void ChangeSpeed(Vector3 fromSpeed, Vector3 toSpeed, float threshold)
    {
        float t = Mathf.Clamp01(Time.time / transitionDuration);

        // Smoothly interpolate between fromSpeed and toSpeed
        Vector3 newSpeed = Vector3.Lerp(fromSpeed, toSpeed, t);

        // Apply the new speed
        GetComponent<Rigidbody>().velocity = newSpeed;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "KW")
        {
            Destroy(gameObject);
        }
        else if (other.name == "Skildpadde")
        {
            Destroy(gameObject);
        }
    }
}
