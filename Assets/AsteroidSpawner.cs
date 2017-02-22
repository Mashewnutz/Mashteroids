﻿using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {

	public GameObject largeAsteroidPrefab;
	// Use this for initialization
	void Start () {
		SpawnAsteroidAtRandomPosition();
	}
	
	void SpawnAsteroidAtRandomPosition() {
		float x = Random.Range(0, Screen.width);
		float y = Random.Range(0, Screen.height);
		var worldPos = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 0));
		worldPos.z = 0;
		Instantiate(largeAsteroidPrefab, worldPos, Quaternion.identity);
	}
}
