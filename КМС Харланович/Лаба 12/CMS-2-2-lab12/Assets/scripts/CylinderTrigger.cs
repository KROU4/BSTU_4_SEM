// Подключение необходимых пространств имен
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Объявление класса CylinderTrigger, который наследуется от MonoBehaviour
public class CylinderTrigger : MonoBehaviour
{
    // Публичное поле для хранения ссылки на объект цилиндра
    public GameObject cylinder;
    // Публичное поле для задания вектора вращения цилиндра
    public Vector3 cylinderRotation = Vector3.zero;
    // Список источников света, которые будут изменяться при нахождении в триггере
    public List<Light> lights;
    // Публичное поле для настройки шага изменения интенсивности света
    public float intensityStep = 1;
    // Публичное поле для задания минимальной интенсивности света
    public float minIntensity = 0;
    // Публичное поле для задания максимальной интенсивности света
    public float maxIntensity = 100;
    // Список имен объектов, для которых триггер будет активным
    public List<string> detectableObjects = new List<string>();

    // Метод Start вызывается один раз при инициализации
    void Start()
    {
        // Установка минимальной интенсивности света для всех источников в списке lights
        foreach (var light in lights)
        {
            light.intensity = minIntensity;
        }
    }

    // Метод Update вызывается один раз за кадр
    void Update()
    {
        // Здесь можно поместить код, который нужно выполнять каждый кадр
    }

    // Метод, вызываемый при нахождении другого объекта внутри триггера
    void OnTriggerStay(Collider other)
    {
        // Проверка, содержится ли имя объекта в списке detectableObjects
        if (!detectableObjects.Contains(other.name))
        {
            return; // Если не содержится, выход из метода
        }
        // Вращение цилиндра на заданный вектор вращения
        cylinder.transform.Rotate(cylinderRotation);
        // Изменение интенсивности света для всех источников в списке lights
        foreach (var light in lights)
        {
            // Ограничение значения интенсивности в пределах minIntensity и maxIntensity
            light.intensity = Mathf.Clamp(
                light.intensity + intensityStep,
                minIntensity,
                maxIntensity
            );
            // Если интенсивность достигла максимального значения, изменение направления шага
            if (light.intensity >= maxIntensity)
            {
                intensityStep = -intensityStep;
            }
            // Если интенсивность достигла минимального значения, изменение направления шага
            if (light.intensity <= minIntensity)
            {
                intensityStep = -intensityStep;
            }
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
        // Установка минимальной интенсивности света для всех источников в списке lights
        foreach (var light in lights)
        {
            light.intensity = minIntensity;
        }
    }
}
