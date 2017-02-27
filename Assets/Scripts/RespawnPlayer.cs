
using UnityEngine;

public class RespawnPlayer : MonoBehaviour {
	
	public GameObject playerPrefab;
	public float timeBetweenSpawns = 1;
	public int lives = 3;
	public float invincibilityTime = 3;
	private GameObject player;

	void Start() {
		player = Spawn();
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

	GameObject Spawn() {
		var player = PoolManager.Instance.Allocate(PoolId.Player, Vector3.zero, Quaternion.identity);
		GameEvents.Instance.OnPlayerSpawned.Invoke(player);
		return player;
	}
	
	void Respawn(){
		if(PoolManager.Instance.GetAllocatedCount(PoolId.Player) == 0){
			player = Spawn();			
			player.GetComponent<Collider2D>().enabled = false;
			player.GetComponent<BlinkSprite>().enabled = true;
			Invoke("TurnOffInvincibility", invincibilityTime);
				
		}
	}

	void TurnOffInvincibility(){
		player.GetComponent<Collider2D>().enabled = true;
		player.GetComponent<BlinkSprite>().enabled = false;
	}
}
