using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CycleHue : MonoBehaviour {

	private Image img;
	private float timer;
	// Use this for initialization
	void Start () {
		img = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime * .1f;
		timer = timer % 1;
		img.color = Color.HSVToRGB(timer, .4f, 1);
	}
}
