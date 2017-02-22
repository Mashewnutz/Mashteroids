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
	public void OnAsteroidDestroyed(AsteroidType.Type type){
		switch(type){
			case AsteroidType.Type.Large:
			score += largeAsteroid;
			break;
			case AsteroidType.Type.Medium:
			score += mediumAsteroid;
			break;
			case AsteroidType.Type.Small:
			score += smallAsteroid;
			break;
		}		
		UpdateText();
	}

	void UpdateText(){
		text.text = score.ToString();
	}
}
