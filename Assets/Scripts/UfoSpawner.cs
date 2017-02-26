using UnityEngine;

public class UfoSpawner : MonoBehaviour {

	public Score score;	
	public int minScoreToSpawnLargeUfo;
	public int minScoreToSpawnSmallUfo;
	public float chanceOfSpawningUfo;
	public GameObject ufoSpawnPositions;
	public int ufoCheckingTime = 30;
	
	void Start () {
		Invoke("SpawnUfo", ufoCheckingTime);
	}

	void SpawnUfo(){
		int ufoCount = GetUfoCount();
		if(ufoCount == 0){
			if(score.GetScore() > minScoreToSpawnSmallUfo){
				if(Random.value < 0.5f){
					SpawnUfoWithChance(PoolId.SmallUfo, chanceOfSpawningUfo);
				} else {
					SpawnUfoWithChance(PoolId.LargeUfo, chanceOfSpawningUfo);
				}
			} else if(score.GetScore() > minScoreToSpawnLargeUfo){
				SpawnUfoWithChance(PoolId.LargeUfo, chanceOfSpawningUfo);				
			}
		}		
		Invoke("SpawnUfo", ufoCheckingTime);
	}

	int GetUfoCount() {
		int largeUfos = PoolManager.Instance.GetAllocatedCount(PoolId.LargeUfo);
		int smallUfos = PoolManager.Instance.GetAllocatedCount(PoolId.SmallUfo);
		return largeUfos + smallUfos;
	}
	Vector3 GetRandomSpawnPosition(){
		int childCount = ufoSpawnPositions.transform.childCount;
		int randomIndex = Random.Range(0, childCount);
		return ufoSpawnPositions.transform.GetChild(randomIndex).transform.position;
	}

	void SpawnUfoWithChance(PoolId ufoType, float chance){
		float random = Random.Range(0.0f, 1.0f);
		if(random < chance){
			var pos = GetRandomSpawnPosition();
			PoolManager.Instance.Allocate(ufoType, pos, Quaternion.identity);			
		}		
	}
		
}
