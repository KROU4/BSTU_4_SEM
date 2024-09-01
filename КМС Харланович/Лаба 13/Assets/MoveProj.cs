// Подключение необходимых пространств имен
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Объявление класса MoveProj, который наследуется от MonoBehaviour
public class MoveProj : MonoBehaviour {

	// Скорость движения объекта
	float moveSpeed = 10f;
	// Префаб взрыва, который будет создан при столкновении
	public GameObject explosionPrefab;
	// Компонент AudioSource для воспроизведения звука
	private AudioSource audioSource;

	// Метод Start вызывается один раз при инициализации
	private void Start()
	{
		// Получение компонента AudioSource
		audioSource = GetComponent<AudioSource>();
		// Запуск корутины для уничтожения объекта через 3 секунды
		StartCoroutine(DestroyAfterTime(3f));
	}

	// Метод, вызываемый при столкновении с другим объектом
	private void OnCollisionEnter(Collision collision)
	{
		// Проверка, имеет ли столкнувшийся объект тег "goal"
		if(collision.gameObject.tag == "goal")
		{
			// Создание взрыва на позиции текущего объекта
			var exp = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
			// Воспроизведение звука
			audioSource.Play();
			// Уничтожение взрыва через 3 секунды
			Destroy(exp, 3f);
			// Отключение рендеринга текущего объекта
			GetComponent<Renderer>().enabled = false;
		}
	}

	// Метод Update вызывается один раз за кадр
	void Update () {
		// Перемещение объекта вперед с заданной скоростью
		transform.Translate(transform.forward * moveSpeed * Time.deltaTime);
	}

	// Корутина для уничтожения объекта через заданное время
	IEnumerator DestroyAfterTime(float time)
	{
		// Ожидание заданного времени
		yield return new WaitForSeconds(time);
		// Уничтожение объекта
		Destroy(gameObject);
	}
}
