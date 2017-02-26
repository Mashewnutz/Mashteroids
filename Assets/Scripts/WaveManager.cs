using UnityEngine;

public class WaveManager : MonoBehaviour {

	public AsteroidSpawner asteroidSpawner;	
	public float delayBetweenWaves;
	public int wave = 0;

	void Start(){
		GameEvents.Instance.OnAsteroidDestroyed.AddListener(OnAsteroidDestroyed);
		GameEvents.Instance.OnUfoDestroyed.AddListener(OnUfoDestroyed);		
		SpawnNewWave();		
	}

	public void OnAsteroidDestroyed(GameObject gameObject) {
		CheckWaveCleared();
	}

	public void OnUfoDestroyed(GameObject ufo) {
		CheckWaveCleared();
	}

	void CheckWaveCleared() {
		int totalObjects = GetTotalObjectCount();
		if(totalObjects == 0){
			GameEvents.Instance.OnWaveCleared.Invoke(wave);			
			Invoke("SpawnNewWave", delayBetweenWaves);
		}
	}

	int GetTotalObjectCount(){
		int largeAsteroids = PoolManager.Instance.GetAllocatedCount(PoolId.LargeAsteroid);
		int mediumAsteroids = PoolManager.Instance.GetAllocatedCount(PoolId.MediumAsteroid);
		int smallAsteroids = PoolManager.Instance.GetAllocatedCount(PoolId.SmallAsteroid);
		int largeUfos = PoolManager.Instance.GetAllocatedCount(PoolId.LargeUfo);
		int smallUfos = PoolManager.Instance.GetAllocatedCount(PoolId.SmallUfo);
		return largeAsteroids + mediumAsteroids + smallAsteroids + largeUfos + smallUfos;
	}

	void SpawnNewWave(){
		wave++;
		asteroidSpawner.SpawnNewWave(wave);
		GameEvents.Instance.OnNewWave.Invoke(wave);
	}
}
