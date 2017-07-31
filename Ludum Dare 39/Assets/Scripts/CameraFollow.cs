using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public float dampTime = .2f;
	public float passiveMouseOffset;
	public float activeMouseOffset;
	public float rotateAmount;
	public float shakeTimer;
	public float shakeAmount;
	public float origionalZoom;

	private Camera cam;
	private Vector3 refVector;
	private Vector3 temp;
	private bool resetZoom = false;

	void Start() {
		cam = Camera.main;
		refVector = Vector3.zero;
		origionalZoom = cam.orthographicSize;
	}


	void Update () {
		Vector3 delta = target.position - cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
		Vector3 desired = transform.position + delta;

		if (Input.GetKey (KeyCode.Mouse1)) {
			desired *= activeMouseOffset;
			desired += cam.ScreenToWorldPoint (Input.mousePosition); 
			desired /= activeMouseOffset + 1;
		} else {
			desired *= passiveMouseOffset;
			desired += cam.ScreenToWorldPoint (Input.mousePosition); 
			desired /= passiveMouseOffset + 1;
		}

		if (resetZoom) {
			float reference = 0;
			cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, origionalZoom, ref reference, .05f);
			if(cam.orthographicSize == origionalZoom) {
				resetZoom = false;
			}
		}

		Quaternion tempRot = transform.rotation;
		tempRot.z = (Input.GetAxis("Horizontal") / 180) * rotateAmount;
		transform.rotation = tempRot;

		temp = Vector3.SmoothDamp (transform.position, desired, ref refVector, dampTime);
		temp.z = transform.position.z;
		transform.position = temp;

		if (shakeTimer >=0) {
			Vector2 shakePosition = Random.insideUnitCircle * shakeAmount;
			shakeTimer -= Time.deltaTime;
			transform.position = new Vector3(transform.position.x + shakePosition.x, transform.position.y + shakePosition.y, transform.position.z);
		}

		if (Input.GetKeyDown(KeyCode.F)) {
			ShakeCamera(.1f, .3f);
		}
	}

	public void SetZoom (float zoom) {
		float reference = 0;
		cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoom, ref reference, 0f);
	}

	public void ResetZoom () {
		resetZoom = true;
	}

	public void ShakeCamera(float power, float duration){
		shakeAmount = power;
		shakeTimer = duration;
	}
}
