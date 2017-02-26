using UnityEngine;

public class PickupSpawner : MonoBehaviour {
		
	public GameObject[] pickups;

	void Start () {
		GameEvents.Instance.OnUfoDestroyed.AddListener(OnUfoDestroyed);		
	}
		
	void OnUfoDestroyed (GameObject ufo) {
		SpawnRandomPowerup(ufo);
	}

	void SpawnRandomPowerup(GameObject ufo){
		int index = Random.Range(0, pickups.Length);
		var pickup = pickups[index];
		GameObject.Instantiate(pickup, ufo.transform.position, Quaternion.identity);
	}
}
