using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject LaserShot;
    public Transform LaserGun1;
    public Transform LaserGun2;
    public float shotDelay;
    public float speed;
    public float tilt;
    public float xMin, xMax, zMin, zMax;
    float nextShotTime;

    Rigidbody ship;

    // Start is called before the first frame update
    void Start()
    {
        //Кусок кода вызывается при создании объекта

        ship = GetComponent<Rigidbody>();

        ship.velocity = new Vector3(10, 0, 10);
    }

    // Update is called once per frame
    void Update()
    {
        //Вызывается на каждый кадр

        //1. Узнать, куда хочет полететь игрок
        var moveHorizontal = Input.GetAxis("Horizontal"); //Куда игрок хочет лететь по горизонтали
        var moveVertical = Input.GetAxis("Vertical");

        //2. Полететь туда
        ship.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;

        //3. Наклон
        ship.rotation = Quaternion.Euler(moveVertical * tilt, 0, -moveHorizontal * tilt);

        //4. Сковываем движения
        var xPosition = Mathf.Clamp(ship.position.x, xMin, xMax);
        var zPosition = Mathf.Clamp(ship.position.z, zMin, zMax);
        ship.position = new Vector3(xPosition, 0, zPosition);

        //5. Стрельба
        if (Time.time > nextShotTime && Input.GetButton("Fire1")) //&& - логическое "и"
        {
            Instantiate(LaserShot, LaserGun1.position, Quaternion.identity);
            Instantiate(LaserShot, LaserGun2.position, Quaternion.identity);

            nextShotTime = Time.time + shotDelay;
        }
        //if (Time.time > nextShotTime)
        //{
        //    Instantiate(LaserShot, LaserGun2.position, Quaternion.identity);
        //    nextShotTime = Time.time + shotDelay;
        //}
    }
}
