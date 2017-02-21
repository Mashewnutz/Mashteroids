
using UnityEngine;

public class RespawnPlayer : MonoBehaviour {
	public GameObject playerPrefab;
	public float timeBetweenSpawns = 1;
	public void OnPlayerDeath () {
		Invoke("Respawn", timeBetweenSpawns);
	}

	void Respawn(){
		GameObject.Instantiate(playerPrefab);
	}
}
