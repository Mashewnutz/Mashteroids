
using UnityEngine;

public class RespawnPlayer : MonoBehaviour {
	
	public GameObject playerPrefab;
	public float timeBetweenSpawns = 1;
	public int lives = 3;

	void Start() {
		Respawn();
		GameEvents.Instance.OnPlayerDestroyed.AddListener(OnPlayerDestroyed);
	}
	
	public void OnPlayerDestroyed () {
		lives--;
		if(lives > 0){
			Invoke("Respawn", timeBetweenSpawns);
		} else {
			GameEvents.Instance.OnGameOver.Invoke();
		}
	}

	void Respawn(){
		PoolManager.Instance.Allocate(PoolId.Player, Vector3.zero);		
	}
}
