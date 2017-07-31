using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerGun : MonoBehaviour {

	public float chargeTime = 1;
	public float cooldown = 2;
	public GameObject bulletPrefab;
	public Transform bulletSpawnPoint;
	public CameraFollow cam;
	public LineRenderer laserSight;
	public Image circleLoader;
	public Image circleCooldown;

	public LayerMask ignorePlayer;


	public AudioClip charge;
	public AudioClip cancel;
	public AudioClip shoot;

	private float chargeTimer;
	private float cooldownTimer;
	private bool played = false;
	private bool ready = false;

	void Start () {
		chargeTimer = chargeTime;
		circleCooldown.fillAmount = 0;
	}

	void Update () {
		cooldownTimer -= Time.deltaTime;
		circleCooldown.fillAmount = (cooldown - cooldownTimer) / cooldown;

		if (cooldownTimer < 0) {
			ready = true;
		}
		if (Input.GetKey (KeyCode.Mouse0)) {
			if (ready && GetComponent<PlayerStats>().power > 10) {
				// Charging
				if (!played) {
					GetComponent<AudioSource>().clip = charge;
					GetComponent<AudioSource>().Play();
					played = true;
				}
				cam.SetZoom(cam.origionalZoom - chargeTime + chargeTimer);
				chargeTimer -= Time.deltaTime;
				circleLoader.fillAmount = (chargeTime-chargeTimer) / chargeTime;
				if (chargeTimer < 0) {
					Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
					Camera.main.GetComponent<CameraFollow>().ShakeCamera(.05f, .2f);
					GetComponent<PlayerStats>().reducePower(10);
					GetComponent<AudioSource>().clip = shoot;
					GetComponent<AudioSource>().Play();

					cam.ResetZoom ();
					chargeTimer = chargeTime;
					cooldownTimer = cooldown;
					played = false;
					ready = false;
					circleLoader.fillAmount = 0;
				}
			}
		} 
		if (Input.GetKeyDown(KeyCode.Mouse0) && GetComponent<PlayerStats>().power <= 10) {
			GetComponent<AudioSource>().clip = cancel;
			GetComponent<AudioSource>().Play();
		}

		if (Input.GetKeyDown(KeyCode.Mouse0) && !ready) {
			GetComponent<AudioSource>().clip = cancel;
			GetComponent<AudioSource>().Play();
		}

		if (Input.GetKeyUp(KeyCode.Mouse0)) {
			if (ready && GetComponent<PlayerStats>().power > 10){
				// Cancel when charging
				chargeTimer = chargeTime;
				cam.ResetZoom ();
				GetComponent<AudioSource>().clip = cancel;
				GetComponent<AudioSource>().Play();
				played = false;
				circleLoader.fillAmount = 0;
			}
		}
		if (!Camera.main.GetComponent<PauseMenu>().paused) {
			laserSight.positionCount = 2;

			laserSight.SetPosition(0, laserSight.gameObject.transform.position);

			RaycastHit2D hit = Physics2D.Raycast(new Vector2(laserSight.gameObject.transform.position.x, laserSight.gameObject.transform.position.y), new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x - laserSight.gameObject.transform.position.x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y - laserSight.gameObject.transform.position.y), 80, ignorePlayer);
			if (hit.collider != null) {
				Vector3 temp = hit.point;
				temp.z = laserSight.gameObject.transform.position.z;
				laserSight.SetPosition(1, temp);
			} else {
				Vector3 temp = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - laserSight.gameObject.transform.position);
				temp.z = 0;
				temp = temp.normalized;
				temp *= 50;
				temp += laserSight.gameObject.transform.position;
				temp.z = laserSight.gameObject.transform.position.z;
				laserSight.SetPosition(1, temp);
			}
		}

	}
}
