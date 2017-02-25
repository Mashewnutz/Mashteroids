using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	
	public int largeAsteroid = 20;
	public int mediumAsteroid = 50;
	public int smallAsteroid = 100;	
	public int smallUfoScore = 1000;
	public int largeUfoScore = 200;
	private Text text;
	private int score = 0;

	void Awake() {
		text = GetComponent<Text>();		
	}

	void Start() {
		GameEvents.Instance.OnAsteroidDestroyed.AddListener(OnAsteroidDestroyed);
		GameEvents.Instance.OnUfoDestroyed.AddListener(OnUfoDestroyed);
		UpdateScore();
	}

	public void OnAsteroidDestroyed(GameObject asteroid){
		var asteroidType = asteroid.GetComponent<PoolAllocation>().poolId;
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

	public void OnUfoDestroyed(GameObject ufo){
		var ufoType = ufo.GetComponent<PoolAllocation>().poolId;
		switch(ufoType){
			case PoolId.LargeUfo:
			score += largeUfoScore;
			break;
			case PoolId.SmallUfo:
			score += smallUfoScore;
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
