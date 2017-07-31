using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

	public float speed = 10f;
	public float sightRadius = 10;
	public LayerMask ignoreSelf;
	public GameObject powerPickup;
	public AudioClip hitClip;
	public AudioClip deathClip;

	private GameObject target;

	void Start() {
		target = GameObject.FindGameObjectWithTag("PlayerWrapper");
	}

	void Update () {

		Vector3 diff = new Vector3(target.transform.position.x - transform.position.x, target.transform.position.y - transform.position.y, 0) ;

		if (diff.magnitude < sightRadius) {

			RaycastHit2D hit = Physics2D.Raycast(transform.position, diff, sightRadius + 1, ignoreSelf);
			if (hit.collider.gameObject.tag == "Player"){
				diff.Normalize();
				float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
				transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
				transform.position += transform.up * speed * Time.deltaTime;
			}
		}
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "PlayerWrapper") {
			col.gameObject.GetComponent<PlayerStats>().reduceHealth(10);
			Camera.main.GetComponent<CameraFollow>().ShakeCamera(.2f, .3f);
			Camera.main.GetComponent<AudioSource>().clip = hitClip;
			Camera.main.GetComponent<AudioSource>().pitch = Random.value * .2f + .9f;
			Camera.main.GetComponent<AudioSource>().Play();
			Destroy(gameObject); // Create a real death thing thats not just destroying it? Play a sound?
		}
	}

	public void BulletHit () {
		if (Random.value < .4f){
			Instantiate (powerPickup, transform.position, transform.rotation);
		}
		Camera.main.GetComponent<AudioSource>().clip = deathClip;
		Camera.main.GetComponent<AudioSource>().pitch = Random.value * .2f + .9f;
		Camera.main.GetComponent<AudioSource>().Play();
		Destroy(gameObject); // Create a real death thing thats not just destroying it? Play a sound?
	}
}
