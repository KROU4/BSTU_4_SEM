using UnityEngine;

public class TankMovement : MonoBehaviour
{
	// Переменные для движения
	public float movementSpeed = 5f; // Скорость движения танка
	public float rotationSpeed = 100f; // Скорость поворота танка
	public float spinSpeed = 90f; // Скорость вращения башни

	// Ссылки на части танка
	public Transform turret; // Ссылка на башню
	public Transform hull; // Ссылка на корпус
	public Transform tracks; // Ссылка на гусеницы
	public Transform dulo; // Ссылка на ствол

	private Rigidbody rb; // Компонент Rigidbody для физического движения
	private float forwardMovement; // Величина движения вперед/назад
	private float horizontalMovement; // Величина движения влево/вправо
	private AudioSource audioSource; // Компонент AudioSource для воспроизведения звука

	// Камера
	public Transform mainCamera; // Ссылка на основную камеру

	// Метод Start вызывается один раз при инициализации
	private void Start()
	{
		// Получение компонента Rigidbody
		rb = GetComponent<Rigidbody>();
		// Получение компонента AudioSource
		audioSource = GetComponent<AudioSource>();
		// Закомментировано: блокировка курсора и скрытие его видимости
		//Cursor.lockState = CursorLockMode.Locked;
		//Cursor.visible = false;
	}

	// Метод Update вызывается один раз за кадр
	void Update()
	{
		// Получение входных данных для горизонтального и вертикального движения
		horizontalMovement = Input.GetAxis("Horizontal");
		forwardMovement = Input.GetAxis("Vertical");

		// Воспроизведение звука при движении танка
		if ((horizontalMovement != 0 || forwardMovement != 0) && !audioSource.isPlaying)
		{
			audioSource.Play();
		}
		// Остановка воспроизведения звука при остановке танка
		if ((horizontalMovement == 0 && forwardMovement == 0))
		{
			audioSource.Stop();
		}

		// Вращение ствола танка вверх и вниз по движению мыши
		float mouseInput = Input.GetAxis("Mouse Y");
		Vector3 turretRotation = Vector3.back * mouseInput * 30f * Time.deltaTime;
		turretRotation.z = Mathf.Clamp(turretRotation.z, -14, 11); // Ограничение угла вращения ствола
		dulo.Rotate(turretRotation);

		// Вращение башни танка по нажатию клавиш Q и E
		if (Input.GetKey(KeyCode.Q))
		{
			turret.transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.E))
		{
			turret.transform.Rotate(Vector3.forward, -spinSpeed * Time.deltaTime);
		}

		#region unused
		// Закомментированные строки для альтернативного управления
		//float mouseX = Input.GetAxis("Mouse X");
		//float turretRotationAngle = -mouseX * rotationSpeed * Time.deltaTime;
		//turret.Rotate(0f, 0f, turretRotationAngle);
		//return;
		//if(mainCamera != null)
		//{
		//    mainCamera.Translate(movement.x, movement.y, movement.z);
		//    mainCamera.Rotate(0f, turretRotationAngle, 0f);
		//}
		#endregion
	}

	// Метод FixedUpdate вызывается с фиксированной частотой кадров
	private void FixedUpdate()
	{
		// Движение танка вперед/назад
		MoveTank(-forwardMovement);
		// Поворот танка влево/вправо
		RotateTank(-horizontalMovement);
	}

	// Метод для движения танка
	void MoveTank(float input)
	{
		// Расчет направления движения
		Vector3 moveDirection = transform.up * input * movementSpeed * Time.fixedDeltaTime;
		// Перемещение Rigidbody танка
		rb.MovePosition(rb.position + moveDirection);
	}

	// Метод для поворота танка
	void RotateTank(float input)
	{
		// Расчет угла поворота
		float rotation = input * rotationSpeed * Time.fixedDeltaTime;
		// Создание кватерниона для поворота
		Quaternion turnRotation = Quaternion.Euler(0f, 0f, rotation);
		// Поворот Rigidbody танка
		rb.MoveRotation(rb.rotation * turnRotation);
	}
}
