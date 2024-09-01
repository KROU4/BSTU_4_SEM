// Подключение необходимых пространств имен
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Объявление класса DoorTrigger, который наследуется от MonoBehaviour
public class DoorTrigger : MonoBehaviour
{
    // Список объектов дверей
    public List<GameObject> doors = new List<GameObject>();
    // Список смещений для открытия дверей
    public List<Vector3> doorsOpenedOffsets = new List<Vector3>();
    // Список имен объектов, для которых триггер будет активным
    public List<string> detectableObjects = new List<string>();

    // Объект, который будет перемещаться и вращаться внутри триггера
    public GameObject levitator;
    // Вектор движения для левитирующего объекта
    public Vector3 levitatorMovement = Vector3.zero;
    // Вектор вращения для левитирующего объекта
    public Vector3 levitatorRotation = Vector3.zero;
    // Имя объекта, который будет активировать левитацию
    public string levitatorDeteactableObject;

    // Метод Start вызывается один раз при инициализации
    void Start()
    {
    }

    // Метод Update вызывается один раз за кадр
    void Update()
    {
    }

    // Метод, вызываемый при входе другого объекта в триггер
    void OnTriggerEnter(Collider other)
    {
        // Проверка, содержится ли имя объекта в списке detectableObjects
        if (!detectableObjects.Contains(other.name))
        {
            return; // Если не содержится, выход из метода
        }
        // Открытие дверей путем смещения их позиций на заданные значения
        for (int i = 0; i < doors.Count; i++)
        {
            // Проверка, есть ли смещение для текущей двери
            if (doorsOpenedOffsets.Count <= i)
            {
                continue; // Если нет, перейти к следующей двери
            }
            // Смещение позиции двери на значение из списка doorsOpenedOffsets
            doors[i].transform.position += doorsOpenedOffsets[i];
        }
    }

    // Метод, вызываемый при выходе другого объекта из триггера
    void OnTriggerExit(Collider other)
    {
        // Проверка, содержится ли имя объекта в списке detectableObjects
        if (!detectableObjects.Contains(other.name))
        {
            return; // Если не содержится, выход из метода
        }
        // Закрытие дверей путем смещения их позиций на обратные значения из списка doorsOpenedOffsets
        for (int i = 0; i < doors.Count; i++)
        {
            // Смещение позиции двери на обратное значение из списка doorsOpenedOffsets
            doors[i].transform.position -= doorsOpenedOffsets[i];
        }
    }

    // Метод, вызываемый при нахождении другого объекта внутри триггера
    void OnTriggerStay(Collider other)
    {
        // Проверка, совпадает ли имя объекта с именем объекта для левитации
        if (other.name != levitatorDeteactableObject)
        {
            return; // Если не совпадает, выход из метода
        }
        // Перемещение левитирующего объекта на заданный вектор
        levitator.transform.Translate(levitatorMovement);
        // Вращение левитирующего объекта на заданный вектор
        levitator.transform.Rotate(levitatorRotation);
    }
}
