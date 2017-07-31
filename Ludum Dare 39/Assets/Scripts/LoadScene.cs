using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadScene : MonoBehaviour {

	void Start() {
		if (SceneManager.GetActiveScene().buildIndex == 0) {
			Time.timeScale = 1;
		}
	}

	public void NextLevelButton(int index)
	{
		SceneManager.LoadScene(index, LoadSceneMode.Single);
	}

	public void NextLevelButton(string levelName)
	{
		SceneManager.LoadScene(levelName, LoadSceneMode.Single);
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public void LoadMainMenu() {
		Camera.main.GetComponent<PauseMenu>().paused = false;
		Time.timeScale = 1;
		SceneManager.LoadScene(0, LoadSceneMode.Single);
	}


}
