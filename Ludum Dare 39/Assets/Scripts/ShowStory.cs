using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowStory : MonoBehaviour {

	public GameObject[] storySteps;
	public int index;
	public string sceneToLoad;

	// Use this for initialization
	void Start () {
		foreach(GameObject step in storySteps) {
			step.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Mouse0)) {
			index++;
			foreach(GameObject step in storySteps) {
				step.SetActive(false);
			}
		}
		if (index < storySteps.Length) {
			storySteps[index].SetActive(true);
		} else {
			SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
		}
	}
}
