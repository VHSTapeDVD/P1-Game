using UnityEngine;

public class goobleatt : MonoBehaviour
{
    public Vector3 startspeed = new Vector3(-2, 0, 0);
    public Vector3 medspeed = new Vector3(-4, 0, 0);
    public Vector3 fastspeed = new Vector3(-6, 0, 0);
    public float timeThreshold1 = 50;
    public float timeThreshold2 = 100;
    public float transitionDuration = 10; // Adjust this value for the duration of the speed transition

    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = startspeed;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float elapsed = Time.time - startTime;

        if (elapsed >= timeThreshold1 && elapsed < timeThreshold2)
        {
            ChangeSpeed(startspeed, medspeed, timeThreshold1);
            Debug.Log("Medspeed reached for gooble");
        }
        else if (elapsed >= timeThreshold2)
        {
            ChangeSpeed(medspeed, fastspeed, timeThreshold2);
            Debug.Log("Fastspeed reached gooble");
        }
    }

    void ChangeSpeed(Vector3 fromSpeed, Vector3 toSpeed, float threshold)
    {
        float elapsed = Time.time - startTime;
        float t = Mathf.Clamp01(elapsed / transitionDuration);

        // Smoothly interpolate between fromSpeed and toSpeed
        Vector3 newSpeed = Vector3.Lerp(fromSpeed, toSpeed, t);

        // Apply the new speed
        GetComponent<Rigidbody>().velocity = newSpeed;

        // Reset the start time if the threshold is reached
        if (elapsed >= threshold)
        {
            startTime = Time.time;
        }
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
