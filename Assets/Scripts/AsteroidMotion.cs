﻿using UnityEngine;

public class AsteroidMotion : MonoBehaviour {

	public float minSpeed = 1;
	public float maxSpeed = 1;	
	public float minRotationSpeed = -1;	
	public float maxRotationSpeed = 1;
	private Rigidbody2D rb2d;

	void Awake() {
		rb2d = GetComponent<Rigidbody2D>();
	}

	void OnEnable () {
		float randomSpeed = Random.Range(minSpeed, maxSpeed);
		var velocity = Vector3.zero-transform.position;
		velocity.Normalize();
		velocity *= randomSpeed;			

		rb2d.velocity = velocity;
		rb2d.angularVelocity = Random.Range(minRotationSpeed, maxRotationSpeed);
	}
}
