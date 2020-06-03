using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoudaryScript : MonoBehaviour
{
    //Срабатывает при выходе объекта за границы
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject); //Уничтожаем объект
    }
}
