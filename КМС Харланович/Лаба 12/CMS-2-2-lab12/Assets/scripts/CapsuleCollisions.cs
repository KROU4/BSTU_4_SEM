// Подключение необходимых пространств имен
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Объявление класса CapsuleCollisions, который наследуется от MonoBehaviour
public class CapsuleCollisions : MonoBehaviour
{
	// Публичное поле для включения/отключения изменения цвета при столкновении
	public bool changeColor = true;
	// Публичное поле для включения/отключения изменения текстуры при столкновении
	public bool changeTexture = true;
	// Список имен объектов, столкновение с которыми будет обрабатываться
	public List<string> detectableObjects = new List<string>();
	// Список текстур, которые могут применяться при столкновении
	public List<Texture> collisionTextures = new List<Texture>();

	// Список объектов, реагирующих на столкновение
	private List<GameObject> reactingObjects = new List<GameObject>();

	// Метод Start вызывается один раз при инициализации
	void Start()
	{
	}

	// Метод Update вызывается один раз за кадр
	void Update()
	{
		// Проверка нажатия клавиши G
		if (Input.GetKeyDown(KeyCode.G))
		{
			ChangeAllReactingObjects();
		}
	}

	// Метод, вызываемый при столкновении с другим объектом
	void OnCollisionEnter(Collision collision)
	{
		// Проверка, содержится ли имя объекта в списке detectableObjects
		if (detectableObjects.Contains(collision.gameObject.name))
		{
			// Добавление объекта в список реагирующих объектов
			if (!reactingObjects.Contains(collision.gameObject))
			{
				reactingObjects.Add(collision.gameObject);
			}

			// Получение компонента Renderer столкнувшегося объекта
			Renderer collisionRenderer = collision.gameObject.GetComponent<Renderer>();

			// Если включено изменение цвета, изменить цвет материала на случайный
			if (changeColor)
			{
				collisionRenderer.material.color = new Color(
					Random.Range(0f, 1f), // Случайное значение для красного канала
					Random.Range(0f, 1f), // Случайное значение для зеленого канала
					Random.Range(0f, 1f)  // Случайное значение для синего канала
				);
			}

			// Если включено изменение текстуры, изменить текстуру материала на следующую в списке
			if (changeTexture)
			{
				// Проверка наличия текстур в списке collisionTextures
				if (collisionTextures.Count > 0)
				{
					// Получение текущего индекса текстуры объекта
					int oldTextureIndex = collisionTextures.IndexOf(collisionRenderer.material.mainTexture);
					// Вычисление нового индекса текстуры с ограничением по границам списка
					int newTextureIndex = (oldTextureIndex + 1) % collisionTextures.Count;
					// Установка новой текстуры материалу объекта
					collisionRenderer.material.mainTexture = collisionTextures[newTextureIndex];
				}
			}
		}
	}

	// Метод для изменения цвета и текстуры всех реагирующих объектов
	void ChangeAllReactingObjects()
	{
		foreach (GameObject obj in reactingObjects)
		{
			Renderer objRenderer = obj.GetComponent<Renderer>();

			// Изменение цвета материала на случайный
			if (changeColor)
			{
				objRenderer.material.color = new Color(
					Random.Range(0f, 1f), // Случайное значение для красного канала
					Random.Range(0f, 1f), // Случайное значение для зеленого канала
					Random.Range(0f, 1f)  // Случайное значение для синего канала
				);
			}

			// Изменение текстуры материала на следующую в списке
			if (changeTexture)
			{
				// Проверка наличия текстур в списке collisionTextures
				if (collisionTextures.Count > 0)
				{
					// Получение текущего индекса текстуры объекта
					int oldTextureIndex = collisionTextures.IndexOf(objRenderer.material.mainTexture);
					// Вычисление нового индекса текстуры с ограничением по границам списка
					int newTextureIndex = (oldTextureIndex + 1) % collisionTextures.Count;
					// Установка новой текстуры материалу объекта
					objRenderer.material.mainTexture = collisionTextures[newTextureIndex];
				}
			}
		}
	}
}
