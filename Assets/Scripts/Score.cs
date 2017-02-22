using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	public int largeAsteroid = 20;
	public int mediumAsteroid = 50;
	public int smallAsteroid = 100;	
	private Text text;
	private int score = 0;
	void Awake() {
		text = GetComponent<Text>();
		UpdateText();
	}
	public void OnAsteroidDestroyed(){
		score += largeAsteroid;
		UpdateText();
	}

	void UpdateText(){
		text.text = score.ToString();
	}
}
