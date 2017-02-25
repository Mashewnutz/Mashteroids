using UnityEngine;

public class WaveManager : MonoBehaviour {
	public AsteroidSpawner asteroidSpawner;
	public GameObject waveClearedText;
	public float delayBetweenWaves;
	private int wave = 1;	
	private int totalNumAsteroids;
	void Start(){
		waveClearedText.SetActive(false);
		SpawnNewWave();
	}
	public void OnAsteroidDestroyed(){
		totalNumAsteroids--;
		if(totalNumAsteroids == 0){
			wave++;
			waveClearedText.SetActive(true);			
			Invoke("SpawnNewWave", delayBetweenWaves);
		}
	}

	void SpawnNewWave(){
		waveClearedText.SetActive(false);
		totalNumAsteroids = asteroidSpawner.SpawnNewWave(wave);
	}
}
