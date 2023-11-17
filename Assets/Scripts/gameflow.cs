using System.Collections;
using UnityEngine;

public class gameflow : MonoBehaviour
{
    public Transform goobleObj;
    public Transform plasticObj;
    public int randYcoor;
    private bool isGooble = false; // Track which object to spawn
    public int spawnLimit = 5;
    public int extraPlasticEvery = 3;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        while (true)
        {
            if (isGooble)
            {
                int[] allowedValues = { -30, 0, 30 };
                randYcoor = allowedValues[Random.Range(0, allowedValues.Length)];
                Instantiate(goobleObj, new Vector3(240, randYcoor, 0), goobleObj.rotation);
            }
            else
            {
                // Spawn 6 plasticObj in a row
                for (int i = 0; i < spawnLimit; i++)
                {
                    int[] allowedValues = { -30, 0, 30 };
                    randYcoor = allowedValues[Random.Range(0, allowedValues.Length)];
                    Instantiate(plasticObj, new Vector3(160, randYcoor, 0), plasticObj.rotation);
                    yield return new WaitForSeconds(2);

                    // Spawn an extra plasticObj every 3 iterations
                    if ((i + 1) % extraPlasticEvery == 0)
                    {
                        int[] allowedValuesExtra = { -30, 0, 30 };
                        randYcoor = allowedValuesExtra[Random.Range(0, allowedValuesExtra.Length)];
                        Instantiate(plasticObj, new Vector3(160, randYcoor, 0), plasticObj.rotation);
                    }
                }
            }

            isGooble = !isGooble; // Switch between goobleObj and plasticObj
            yield return new WaitForSeconds(0.5f);
        }
    }
}
