using System.Collections.Generic;
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
		List<int> indices = GenerateIndices();
		for(int i = 0; i < count; ++i){
			int randomIndex = indices[Random.Range(0, indices.Count)];
			indices.Remove(randomIndex);
			var worldPos = GetAsteroidPositionAtIndex(randomIndex);
			Instantiate(largeAsteroidPrefab, worldPos, Quaternion.identity);
		}			
	}	

	int GetNumberOfAsteroids(int level){
		return (int)(Mathf.Log (level, 2) + 1);
	}

	List<int> GenerateIndices() {
		int childCount = spawnPositions.transform.childCount;
		List<int> indices = new List<int>();
		for(int i = 0; i < childCount; ++i){
			indices.Add(i);
		}
		return indices;
	}
	Vector3 GetAsteroidPositionAtIndex(int index){		
		return spawnPositions.transform.GetChild(index).position;
	}
}
