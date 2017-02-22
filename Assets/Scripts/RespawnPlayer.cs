
using UnityEngine;

public class RespawnPlayer : MonoBehaviour {
	public GameObject playerPrefab;
	public float timeBetweenSpawns = 1;
	public int lives = 3;
	
	public void OnPlayerDeath () {
		lives--;
		if(lives > 0){
			Invoke("Respawn", timeBetweenSpawns);
		} else {
			GameEvents.instance.OnGameOver();
		}
	}

	void Respawn(){
		GameObject.Instantiate(playerPrefab);
	}
}
