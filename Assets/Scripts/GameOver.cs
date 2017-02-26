using UnityEngine;

public class GameOver : MonoBehaviour {

	public float gameOverDelay = 5;
	private GameObject pressAnyKeyToContinue;

	void Start() {		
		gameObject.SetActive(false);
		pressAnyKeyToContinue = transform.GetChild(0).gameObject;		
		GameEvents.Instance.OnGameOver.AddListener(OnGameOver);		
	}

	public void OnGameOver() {
		gameObject.SetActive(true);
		Invoke("ShowPressAnyKeyToContinueText", gameOverDelay);
	}

	void ShowPressAnyKeyToContinueText(){
		pressAnyKeyToContinue.SetActive(true);
	}

}
