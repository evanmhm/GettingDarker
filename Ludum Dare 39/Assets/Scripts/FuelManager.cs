using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelManager : MonoBehaviour {

	public Text counter;
	public GameObject elevatorTrigger;
	public GameObject elevatorLight;
	public TextMesh elevatorText;


	public int total;
	void Start () {
		UpdateZoneCounter();
	}
	public void UpdateZoneCounter () {
		total++;
		counter.text = total + " / 4 switches activated\n";
		if (total == 4) {
			elevatorLight.transform.localScale = Vector3.one * 20;
			elevatorTrigger.SetActive(true);
			counter.text = "4 / 4 activated.\n Head for the elevator!";
			elevatorText.text = "Elevator Activated";
			elevatorText.color = new Color(155,255,155);

		}
	}
}
