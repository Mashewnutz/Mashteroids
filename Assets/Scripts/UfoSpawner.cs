using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoSpawner : MonoBehaviour {
	public Score score;
	public GameObject largeUfoPrefab;
	public GameObject smallUfoPrefab;
	public int minScoreToSpawnLargeUfo;
	public int minScoreToSpawnSmallUfo;
	public GameObject ufoSpawnPositions;
	private int ufoCheckingTime = 1;	
	// Use this for initialization
	void Start () {
		Invoke("SpawnUfo", ufoCheckingTime);
	}

	void SpawnUfo(){
		if(GameObject.FindGameObjectsWithTag("Ufo").Length == 0){
			if(score.GetScore() > minScoreToSpawnSmallUfo){
				var pos = GetRandomSpawnPosition();
				Instantiate(smallUfoPrefab, pos, Quaternion.identity);
			} else if(score.GetScore() > minScoreToSpawnLargeUfo){
				var pos = GetRandomSpawnPosition();
				Instantiate(largeUfoPrefab, pos, Quaternion.identity);
			}
		}		
		Invoke("SpawnUfo", ufoCheckingTime);
	}

	Vector3 GetRandomSpawnPosition(){
		int childCount = ufoSpawnPositions.transform.childCount;
		int randomIndex = Random.Range(0, childCount);
		return ufoSpawnPositions.transform.GetChild(randomIndex).transform.position;
	}
		
}
