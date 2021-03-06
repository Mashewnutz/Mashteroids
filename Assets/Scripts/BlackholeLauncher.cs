﻿using UnityEngine;

public class BlackholeLauncher : Pickup {
	
	public float launchForce;
	public GameObject blackholeLauncher;
	public GameObject blackholePrefab;

	public override void AttachToPlayer (GameObject player) {
		transform.SetParent(player.transform, false);
	}
		
	public override void Use() {
		LaunchBlackhole(blackholeLauncher);
		Destroy(gameObject);
	}

	void LaunchBlackhole(GameObject launcher) {
		var blackhole = GameObject.Instantiate(blackholePrefab, launcher.transform.position, launcher.transform.rotation);
		blackhole.GetComponent<Rigidbody2D>().AddForce(transform.up * launchForce, ForceMode2D.Impulse);
	}
}
