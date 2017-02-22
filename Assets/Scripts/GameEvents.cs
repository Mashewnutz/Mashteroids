using UnityEngine;
using UnityEngine.Events;

public class GameEvents : MonoBehaviour {

	public Lives lives;
	public Score score;
	public GameOver gameOver;
	public RespawnPlayer respawnPlayer;
	public static GameEvents instance;
	void Awake(){
		instance = this;
		DontDestroyOnLoad(gameObject);
	}
	public void OnPlayerDeath(){
		lives.OnPlayerDeath();
		respawnPlayer.OnPlayerDeath();
	}
	public void OnGameOver(){
		gameOver.OnGameOver();
	}
	public void OnAsteroidDestroyed(GameObject asteroid){
		score.OnAsteroidDestroyed(asteroid.GetComponent<AsteroidType>().type);
	}
}
