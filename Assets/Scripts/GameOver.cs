using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public float gameOverDelay = 5;
	void Start() {		
		gameObject.SetActive(false);
	}
	void Update() {
		gameOverDelay -= Time.deltaTime;
		if(Input.anyKeyDown && gameOverDelay <= 0){
			SceneManager.LoadScene("Title");
		}
	}
	public void OnGameOver() {
		gameObject.SetActive(true);
	}
}
