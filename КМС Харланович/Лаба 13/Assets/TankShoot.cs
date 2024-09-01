// Подключение необходимых пространств имен
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Объявление класса TankShoot, который наследуется от MonoBehaviour
public class TankShoot : MonoBehaviour {

	// Префаб снаряда, который будет создан при выстреле
	public GameObject projectilePrefab;
	// Точка, из которой будет производиться выстрел
	public Transform spawnPoint;
	// Компонент AudioSource для воспроизведения звука
	private AudioSource audioSource;

	// Метод Start вызывается один раз при инициализации
	void Start () {
		// Получение компонента AudioSource
		audioSource = GetComponent<AudioSource>();
	}

	// Метод Update вызывается один раз за кадр
	void Update () {
		// Проверка нажатия клавиши пробела для выстрела
		if (Input.GetKeyDown(KeyCode.Space))
		{
			// Проверка, что точка выстрела и префаб снаряда не равны null
			if (spawnPoint != null && projectilePrefab != null)
			{
				// Создание экземпляра снаряда на позиции и с ротацией точки выстрела
				var bullet = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);
				// Воспроизведение звукового эффекта выстрела
				audioSource.Play();
				// Закомментировано: добавление силы снаряду для его движения вперед
				//bullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * 100f);
			}
		}
	}
}
