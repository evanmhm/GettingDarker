using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureFix : MonoBehaviour {

	private LineRenderer line;

	void Awake()
	{
		line = GetComponent<LineRenderer>();
	}

	void Update()
	{
		Vector2 newPosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
		line.material.SetTextureOffset("_MainTex", new Vector2(Time.timeSinceLevelLoad * 4f, 0f));
		line.material.SetTextureScale("_MainTex", new Vector2(newPosition.magnitude, 1f));
		line.SetPosition(0, newPosition);
	}
}
