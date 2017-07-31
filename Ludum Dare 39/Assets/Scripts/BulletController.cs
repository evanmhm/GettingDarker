using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	public float speed;

	private float timer = 3;
	private Rigidbody2D rb;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
		rb.velocity = new Vector2(transform.up.x, transform.up.y) * speed;
		timer -= Time.deltaTime;
		if (timer < 0) {
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag != "PlayerWrapper" && col.gameObject.tag != "Player"){
			Debug.Log(col.gameObject.tag);

			col.gameObject.SendMessage("BulletHit", SendMessageOptions.DontRequireReceiver);
			Destroy(gameObject);
		}


	}
	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.tag != "PlayerWrapper" && col.gameObject.tag != "Player" && col.gameObject.tag != "Pickup"){
//			Debug.Log();
			if (col.gameObject.tag != "Enemy") {
				Destroy(gameObject);
			}
			col.gameObject.SendMessage("BulletHit", SendMessageOptions.DontRequireReceiver);
		}

	}
}
