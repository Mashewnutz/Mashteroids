using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	public float gameOverDelay = 5;
	private GameObject pressAnyKeyToContinue;

	void Start() {		
		gameObject.SetActive(false);
		pressAnyKeyToContinue = transform.GetChild(0).gameObject;		
		GameEvents.Instance.OnGameOver.AddListener(OnGameOver);	
		GameEvents.Instance.OnGameWon.AddListener(OnGameWon);		
	}

	public void OnGameOver() {
		gameObject.SetActive(true);		
		Invoke("ShowPressAnyKeyToContinueText", gameOverDelay);
	}

	public void OnGameWon() {
		gameObject.SetActive(true);
		gameObject.GetComponent<Text>().text = "YOU WIN!";
		Invoke("ShowPressAnyKeyToContinueText", gameOverDelay);
	}

	void ShowPressAnyKeyToContinueText(){
		pressAnyKeyToContinue.SetActive(true);
	}

}
