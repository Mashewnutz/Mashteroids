using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public float gameOverDelay = 5;
	private GameObject pressAnyKeyToContinue;

	void Start() {		
		gameObject.SetActive(false);
		pressAnyKeyToContinue = transform.GetChild(0).gameObject;
		pressAnyKeyToContinue.SetActive(false);
		GameEvents.Instance.OnGameOver.AddListener(OnGameOver);
	}

	void Update() {
		gameOverDelay -= Time.deltaTime;

		if(Input.anyKeyDown && gameOverDelay <= 0){
			SceneManager.LoadScene("Title");
		}
	}

	void ShowPressAnyKeyToContinueText(){
		pressAnyKeyToContinue.SetActive(true);
	}

	public void OnGameOver() {
		gameObject.SetActive(true);
		Invoke("ShowPressAnyKeyToContinueText", gameOverDelay);
	}
}
