using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public float speed = 10;
	private Rigidbody2D rb;
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	void Update () {
		Vector3 temp = Vector3.right * Input.GetAxis ("Horizontal") + Vector3.up * Input.GetAxis ("Vertical");
		temp = temp.normalized;
		transform.position += temp * speed * Time.deltaTime;
	}

}
