// Импорт необходимых библиотек
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Класс для управления генерацией объектов и вращением камеры
public class ObjectGenerationScript : MonoBehaviour
{

    // Ссылка на префаб сферы (назначается в инспекторе)
    public GameObject spherePrefub;

    // Компонент отрисовки сетки (не используется в данном контексте)
    private MeshRenderer meshRenderer;

    // Минимальные и максимальные границы по X и Z (не используются в данном контексте)
    private float minX, maxX;
    private float minZ, maxZ;

    // Координаты для размещения объектов
    private float nX, nY, nZ;

    // Start вызывается один раз при инициализации объекта
    void Start()
    {
        // Получение компонента отрисовки сетки
        meshRenderer = gameObject.GetComponent<MeshRenderer>();

        // **Эти значения не используются в текущей реализации**
  	minX = meshRenderer.bounds.min.x;
         maxX = meshRenderer.bounds.max.x;
        minZ = meshRenderer.bounds.min.z;
         maxZ = meshRenderer.bounds.max.z;

        // Установка высоты для размещения объектов (смещение на 5 по Y)
        nY = gameObject.transform.position.y + 5;
    }

    // Update вызывается каждый кадр
    void Update()
    {
        // Случайное определение координат по X и Z внутри границ (не используются)
        nX = Random.Range(minX, maxX);
        nZ = Random.Range(minZ, maxZ);

        // Создание куба по нажатию клавиши Q
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Создание нового игрового объекта - куба
            GameObject newCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            // Установка позиции куба
            newCube.transform.position = new Vector3(nX, nY, nZ);
            // Добавление компонента Rigidbody для физического поведения
            newCube.AddComponent<Rigidbody>();
        }

        // Создание сферы из префаба по нажатию клавиши E
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Создание нового объекта из префаба сферы
            Instantiate(spherePrefub, new Vector3(nX, nY, nZ), Quaternion.identity);
        }

        // Поворот камеры влево по удержанию клавиши A
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward);  // Вращение по направлению вперед
        }

        // Поворот камеры вправо по удержанию клавиши D
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back);  // Вращение по направлению назад
        }
    }
}
