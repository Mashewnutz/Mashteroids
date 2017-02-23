using UnityEngine;

public class GameEvents : MonoBehaviour {
	public Lives lives;
	public Score score;
	public GameOver gameOver;
	public RespawnPlayer respawnPlayer;
	public WaveManager waveManager;
	public static GameEvents instance;
	void Awake(){
		instance = this;		
	}
	public void OnPlayerDeath(){
		lives.OnPlayerDeath();
		respawnPlayer.OnPlayerDeath();
	}
	public void OnGameOver(){
		gameOver.OnGameOver();
	}
	public void OnAsteroidDestroyed(GameObject asteroid){
		var asteroidType = asteroid.GetComponent<AsteroidType>().type;
		score.OnAsteroidDestroyed(asteroidType);
		waveManager.OnAsteroidDestroyed();
	}
	public void OnUfoDestroyed(GameObject ufo){
		score.OnUfoDestroyed(ufo.GetComponent<UfoType>().type);
	}
}
