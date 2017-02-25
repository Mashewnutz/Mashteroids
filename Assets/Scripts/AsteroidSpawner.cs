using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {
	
	public GameObject spawnPositions;
	public float delayBetweenWaves = 2;
	public GameObject waveClearedText;

	public int SpawnNewWave(int wave){
		int newAsteroidCount = GetNumberOfAsteroids(wave);
		SpawnAsteroidsAtRandomPositions(newAsteroidCount);
		waveClearedText.SetActive(false);
		return newAsteroidCount * 7;
	}

	void SpawnAsteroidsAtRandomPositions(int count) {
		List<int> indices = GenerateIndices();
		for(int i = 0; i < count; ++i){
			int randomIndex = indices[Random.Range(0, indices.Count)];
			indices.Remove(randomIndex);
			var worldPos = GetAsteroidPositionAtIndex(randomIndex);
			PoolManager.Instance.Allocate(PoolId.LargeAsteroid, worldPos);			
		}			
	}	

	int GetNumberOfAsteroids(int wave){
		return (int)(Mathf.Log (wave, 2) + 1);
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
