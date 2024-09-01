using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_GetAxis : MonoBehaviour {
	float _translateX, _translateZ;
	float _rotateX, _rotateY;

	// Use this for initialization
	void Start () {
		
	}

    // Update вызывается один раз на каждый кадр
    void Update()
    {
        // _translateX хранит горизонтальное перемещение по вводу
        _translateX = Input.GetAxis("Horizontal");

        // _translateZ хранит вертикальное перемещение по вводу
        _translateZ = Input.GetAxis("Vertical");

        // _rotateX хранит вращение по оси X по горизонтальному движению мыши
        _rotateX = Input.GetAxis("Mouse X");

        // _rotateY хранит вращение по оси Y по вертикальному движению мыши
        _rotateY = Input.GetAxis("Mouse Y");

        // Ограничение вращения по Y-оси от 0 до 90 градусов (по желанию, можно убрать) 
        _rotateY = Mathf.Clamp(_rotateY, 0, 90);

        // Перемещение объекта на величину _translateX по X, 0 по Y и _translateZ по Z
        transform.Translate(_translateX, 0, _translateZ);

        // Вращение объекта на _rotateX по X, _rotateY по Y и 0 по Z
        transform.Rotate(_rotateX, _rotateY, 0);
    }
}
