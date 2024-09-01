// Подключение необходимых пространств имен
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Объявление класса SpotLightTrigger, который наследуется от MonoBehaviour
public class SpotLightTrigger : MonoBehaviour
{
    // Ссылка на источник света
    public Light spotLight;
    // Скорость вращения источника света
    public float rotationSpeed = 1;
    // Список имен объектов, для которых триггер будет активным
    public List<string> detectableObjects = new List<string>();

    // Метод Start вызывается один раз при инициализации
    void Start()
    {
    }

    // Метод Update вызывается один раз за кадр
    void Update()
    {
    }

    // Метод, вызываемый при нахождении другого объекта внутри триггера
    void OnTriggerStay(Collider other)
    {
        // Проверка, содержится ли имя объекта в списке detectableObjects
        if (!detectableObjects.Contains(other.name))
        {
            return; // Если не содержится, выход из метода
        }
        // Вращение источника света вокруг оси Y с заданной скоростью
        spotLight.transform.Rotate(rotationSpeed * Vector3.up);
    }
}
