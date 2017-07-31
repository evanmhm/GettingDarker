using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelZone : MonoBehaviour {

	public bool full;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Player") {
			col.gameObject.transform.parent.GetComponentInParent<PlayerStats>().CanLoad(!full, gameObject);
		}
	}

	void OnTriggerExit2D (Collider2D col) {
		if (col.tag == "Player") {
			col.gameObject.transform.parent.GetComponentInParent<PlayerStats>().CanLoad(false, gameObject);
		}
	}

	public void FueledUp () {
		full = true;
		gameObject.GetComponentInParent<FuelManager>().UpdateZoneCounter();
	}
}
