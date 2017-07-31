using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorControl : MonoBehaviour {
	Vector3 temp;

	void Start () {
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = false;
	}

	void Update () {
		if (!Camera.main.GetComponent<PauseMenu>().paused) {
			temp = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			temp.z = transform.position.z;
			transform.position = temp;	
		}
	}
}
