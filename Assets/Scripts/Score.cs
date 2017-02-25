using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	
	public int largeAsteroid = 20;
	public int mediumAsteroid = 50;
	public int smallAsteroid = 100;	
	public int smallUfo = 1000;
	public int largeUfo = 200;
	private Text text;
	private int score = 0;

	void Awake() {
		text = GetComponent<Text>();
		UpdateScore();
	}
	public void OnAsteroidDestroyed(PoolId asteroidType){
		switch(asteroidType){
			case PoolId.LargeAsteroid:
			score += largeAsteroid;
			break;
			case PoolId.MediumAsteroid:
			score += mediumAsteroid;
			break;
			case PoolId.SmallAsteroid:
			score += smallAsteroid;
			break;
		}		
		UpdateScore();
	}

	public void OnUfoDestroyed(UfoType.Type type){
		switch(type){
			case UfoType.Type.Large:
			score += largeUfo;
			break;
			case UfoType.Type.Small:
			score += smallUfo;
			break;
		}
		UpdateScore();
	}

	void UpdateScore(){
		text.text = score.ToString();
	}

	public int GetScore(){
		return score;
	}
}
