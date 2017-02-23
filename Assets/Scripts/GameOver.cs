using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public float gameOverDelay = 5;
	private GameObject pressAnyKeyToContinue;
	void Start() {		
		gameObject.SetActive(false);
		pressAnyKeyToContinue = transform.GetChild(0).gameObject;
		pressAnyKeyToContinue.SetActive(false);
	}
	void Update() {
		gameOverDelay -= Time.deltaTime;
		if(gameOverDelay <= 0){
			pressAnyKeyToContinue.SetActive(true);
		}

		if(Input.anyKeyDown && gameOverDelay <= 0){
			SceneManager.LoadScene("Title");
		}
	}
	public void OnGameOver() {
		gameObject.SetActive(true);
	}
}
