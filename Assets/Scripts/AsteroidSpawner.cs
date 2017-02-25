using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {
	
	public GameObject spawnPositions;	
	public GameObject waveClearedText;
	public float delayBetweenWaves = 2;

	public void SpawnNewWave(int wave){
		int newAsteroidCount = GetNumberOfAsteroids(wave);
		SpawnAsteroidsAtRandomPositions(newAsteroidCount);
		waveClearedText.SetActive(false);		
	}

	void SpawnAsteroidsAtRandomPositions(int count) {
		List<Vector3> positions = GeneratePositions();
		for(int i = 0; i < count; ++i){
			var position = positions[0];
			positions.RemoveAt(0);			
			PoolManager.Instance.Allocate(PoolId.LargeAsteroid, position);			
		}			
	}	

	int GetNumberOfAsteroids(int wave){
		return 1 + Mathf.RoundToInt(wave * 0.5f);
	}

	List<Vector3> GeneratePositions() {
		List<Vector3> positions = new List<Vector3>();
		foreach(Transform child in spawnPositions.transform){
			positions.Add(child.position);
		}

		var random = new Random();		
		return positions.OrderBy(item => Random.Range(0.0f, 100.0f)).ToList();
	}
}
