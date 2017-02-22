using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {

	public GameObject largeAsteroidPrefab;
	public GameObject spawnPositions;
	private int level = 0;

	void Update() {
		int asteroidCount = GameObject.FindGameObjectsWithTag("Asteroid").Length;
		if(asteroidCount == 0){
			level++;
			int newAsteroidCount = GetNumberOfAsteroids(level);
			SpawnAsteroidsAtRandomPositions(newAsteroidCount);
		}		
	}

	void SpawnAsteroidsAtRandomPositions(int count) {
		for(int i = 0; i < count; ++i){
			var worldPos = GetRandomAsteroidPosition();
			Instantiate(largeAsteroidPrefab, worldPos, Quaternion.identity);
		}			
	}

	int GetNumberOfAsteroids(int level){
		return (int)(Mathf.Log (level, 2) + 1);
	}

	Vector3 GetRandomAsteroidPosition(){
		int childCount = spawnPositions.transform.childCount;
		int randomIndex = Random.Range(0, childCount);
		return spawnPositions.transform.GetChild(randomIndex).position;
	}
}
