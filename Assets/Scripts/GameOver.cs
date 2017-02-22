using UnityEngine;

public class GameOver : MonoBehaviour {
	
	void Start() {		
		gameObject.SetActive(false);
	}

	public void OnGameOver() {		
		gameObject.SetActive(true);		
	}
}
