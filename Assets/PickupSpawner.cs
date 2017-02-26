using UnityEngine;

public class PickupSpawner : MonoBehaviour {
		
	public GameObject genericPickupPrefab;
	public GameObject[] pickupPrefabs;	

	void Start () {
		GameEvents.Instance.OnUfoDestroyed.AddListener(OnUfoDestroyed);		
	}
		
	void OnUfoDestroyed (GameObject ufo) {
		SpawnRandomPowerup(ufo);
	}

	void SpawnRandomPowerup(GameObject ufo){
		int index = Random.Range(0, pickupPrefabs.Length);
		var pickup = pickupPrefabs[index];
		var pickupContainer = GameObject.Instantiate(genericPickupPrefab, ufo.transform.position, Quaternion.identity);
		var spawnedPickup = GameObject.Instantiate(pickup, ufo.transform.position, Quaternion.identity, pickupContainer.transform);
		spawnedPickup.SetActive(false);
	}
}
