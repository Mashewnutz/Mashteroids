
using UnityEngine;

public class UfoWeapon : MonoBehaviour {
	
	public float fireRate;
	public float fireAccuracy;
	public float bulletSpeed;	

	void OnEnable() {		
		Invoke("Shoot", fireRate);		
	}
	
	void OnDisable()
	{
		CancelInvoke();
	}

	void Shoot(){
		var player = GameObject.FindGameObjectWithTag("Player");
		if(player == null)
			return;

		var bullet = PoolManager.Instance.Allocate(PoolId.EnemyBullet, transform.position);
		var rb2d = bullet.GetComponent<Rigidbody2D>();
		
		var directionToPlayer = player.transform.position - bullet.transform.position;
		directionToPlayer.Normalize();
		rb2d.velocity = directionToPlayer * bulletSpeed;
		
		Invoke("Shoot", fireRate);
	}
}
