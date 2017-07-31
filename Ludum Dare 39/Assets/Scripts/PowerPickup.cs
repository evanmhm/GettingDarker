using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPickup : MonoBehaviour {

	public PlayerStats player;
	public AudioClip clip;
	public float powerRegain;

	void Start() {
		player = GameObject.FindGameObjectWithTag("PlayerWrapper").GetComponent<PlayerStats>();
	}
	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.tag == "Player") {
			player.power += powerRegain;
			if(player.power > 100) {
				player.power = 100;
			}
			Camera.main.GetComponent<AudioSource>().clip = clip;
			Camera.main.GetComponent<AudioSource>().pitch = Random.value * .2f + .9f;
			Camera.main.GetComponent<AudioSource>().Play();
			Destroy(gameObject);
		}
	}
}
