using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	public Light light;

	private float counter;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Cursor.visible = true;
		counter += Time.deltaTime;
		light.range = Mathf.Sin(counter * Mathf.PI /2 ) * 5 + 12;
	}
}
