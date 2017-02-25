using UnityEngine;

public class GameEvents : MonoBehaviour {
	
	public static GameEvents instance;
	public Lives lives;
	public Score score;
	public GameOver gameOver;
	public RespawnPlayer respawnPlayer;
	public WaveManager waveManager;	

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
		var asteroidType = asteroid.GetComponent<PoolAllocation>().poolId;
		score.OnAsteroidDestroyed(asteroidType);
		waveManager.OnAsteroidDestroyed();
	}

	public void OnUfoDestroyed(GameObject ufo){
		score.OnUfoDestroyed(ufo.GetComponent<PoolAllocation>().poolId);
		waveManager.OnUfoDestroyed();
	}
}
