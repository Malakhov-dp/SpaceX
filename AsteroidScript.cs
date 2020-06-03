using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public float rotationSpeed;
    public float minSpeed, maxSpeed;
    float size;

    public GameObject asteroidExplosion;
    public GameObject shipExplosion;

    // Start is called before the first frame update
    void Start()
    {
        size = Random.Range(0.6f, 1.5f);
        Rigidbody Asteroid = GetComponent<Rigidbody>();
        Asteroid.angularVelocity = Random.insideUnitSphere * rotationSpeed;
        float speed = Random.Range(minSpeed, maxSpeed);

        Asteroid.velocity = new Vector3(0, 0, -speed);

        transform.localScale *= size;
    }

    // При столкновении с другим коллайдером
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Game Boundary"){
            return;
        }
        Destroy(other.gameObject);
        Destroy(gameObject); // Разрушить текущий объект

        GameObject explosion = Instantiate(asteroidExplosion, transform.position, Quaternion.identity);
        explosion.transform.localScale *= size;

        if (other.tag =="Player")
        {
            Instantiate(shipExplosion, other.transform.position, Quaternion.identity);
        }
    }
}
