using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidEmitter : MonoBehaviour
{
    public GameObject Asteroid;
    public float minDelay, maxDelay;
    float nextLaunchTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextLaunchTime)
        {
            float positionX = Random.Range (-transform.localScale.x / 2, transform.localScale.x / 2);

            Instantiate(Asteroid, new Vector3(positionX, 0, transform.position.z), Quaternion.identity);

            nextLaunchTime = Time.time + Random.Range(minDelay, maxDelay);
        }
    }
}
