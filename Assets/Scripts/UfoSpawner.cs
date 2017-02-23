using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoSpawner : MonoBehaviour {
	public Score score;
	public GameObject largeUfoPrefab;
	public GameObject smallUfoPrefab;
	public int minScoreToSpawnLargeUfo;
	public int minScoreToSpawnSmallUfo;
	public float chanceOfSpawningUfo;
	public GameObject ufoSpawnPositions;
	public int ufoCheckingTime = 30;
	// Use this for initialization
	void Start () {
		Invoke("SpawnUfo", ufoCheckingTime);
	}

	void SpawnUfo(){
		if(GameObject.FindGameObjectsWithTag("Ufo").Length == 0){
			if(score.GetScore() > minScoreToSpawnSmallUfo){
				SpawnUfoWithChance(smallUfoPrefab, chanceOfSpawningUfo);
			} else if(score.GetScore() > minScoreToSpawnLargeUfo){
				SpawnUfoWithChance(largeUfoPrefab, chanceOfSpawningUfo);				
			}
		}		
		Invoke("SpawnUfo", ufoCheckingTime);
	}

	Vector3 GetRandomSpawnPosition(){
		int childCount = ufoSpawnPositions.transform.childCount;
		int randomIndex = Random.Range(0, childCount);
		return ufoSpawnPositions.transform.GetChild(randomIndex).transform.position;
	}

	void SpawnUfoWithChance(GameObject prefab, float chance){
		float random = Random.Range(0.0f, 1.0f);
		if(random < chance){
			var pos = GetRandomSpawnPosition();
			Instantiate(prefab, pos, Quaternion.identity);
		}		
	}
		
}
