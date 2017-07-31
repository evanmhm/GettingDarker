using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerStats : MonoBehaviour {

	public float health;
	public float power;

	public Color fullPower;
	public Color fullHealth;
	public Color low;
	public Color empty;

	public RectTransform powerBG;
	public RectTransform healthBG;
	public GameObject shadowMask;

	private int batteryAmount = 0;
	public bool loadingBattery;
	public bool loadingFuel;

	private bool canLoadFuel;

	private Vector2 powerPosition;
	private Vector2 healthPosition;

	public Image circleLoader;

	private float fuelTimer;
	private float fuelTime = 2;
	private GameObject fuelObject;

	void Start () {
		powerPosition = powerBG.anchoredPosition;
		healthPosition = powerBG.anchoredPosition;
		fuelTimer = fuelTime;
	}
	

	void Update () {
		powerPosition.x = 380 * (power / 100) - 380;
		powerBG.localPosition = powerPosition;
		if (power > 33) {
			powerBG.gameObject.GetComponent<Image>().color = fullPower;
		}
		if (power <= 33) {
			if (power <= 10){
				powerBG.gameObject.GetComponent<Image>().color = empty;
			} else {
				powerBG.gameObject.GetComponent<Image>().color = low;
			}
		}

		healthPosition.x = 380 * (health / 100) - 380;
		healthBG.localPosition = healthPosition;
		if (health > 33) {
			healthBG.gameObject.GetComponent<Image>().color = fullHealth;
		}
		if (health <= 33) {
			if (health <= 10){
				healthBG.gameObject.GetComponent<Image>().color = empty;
			} else {
				healthBG.gameObject.GetComponent<Image>().color = low;
			}
		}

		shadowMask.transform.localScale = Vector3.one * (power / 100) * .7f + Vector3.one * .1f;

		if (Input.GetKey(KeyCode.F)) {
			if (batteryAmount >= 1) {
				loadingBattery = true;
				// load battery
			} else {
				// play cancel noise
			}
		}

		if (Input.GetKeyUp(KeyCode.F)) {
			if (loadingBattery) {
				loadingBattery = false;
			}
		}

		if (Input.GetKey(KeyCode.E)) { 
			if (canLoadFuel) {
				loadingFuel = true;
				fuelTimer -= Time.deltaTime;
				circleLoader.fillAmount = (fuelTime-fuelTimer) / fuelTime;
				if (fuelTimer < 0) {
					// All the way full
					canLoadFuel = false;
					circleLoader.fillAmount = 0;
					fuelObject.SendMessage("FueledUp", SendMessageOptions.RequireReceiver);
					batteryAmount += 1;
				}
			} else {
				loadingFuel = false;
				fuelTimer = fuelTime;
				circleLoader.fillAmount = 0;

			}
		}

		if (Input.GetKeyUp(KeyCode.E)) {
			if (loadingFuel) {
				loadingFuel = false;
				fuelTimer = fuelTime;
				circleLoader.fillAmount = 0;
			}
		}

		if (health <= 0) {
			SceneManager.LoadScene("DeathScene");
		}

	}

	public void reducePower (float amount) {
		power -= amount;
	}

	public void reduceHealth (float amount) {
		health -= amount;
	}

	public void CanLoad(bool value, GameObject fuelSpot) {
		fuelTimer = fuelTime;
		canLoadFuel = value;
		fuelObject = fuelSpot;
	}

}
