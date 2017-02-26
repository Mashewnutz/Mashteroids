
using UnityEngine;

public class UfoWeapon : MonoBehaviour {
	
	[RangeAttribute(0, 1)]
	public float accuracy;
	public float fireRate;	
	public float bulletSpeed;	
	private float fireInterval;
	
	void OnEnable() {
		fireInterval = 1.0f/fireRate;
		Shoot();		
	}
	
	void OnDisable()
	{
		CancelInvoke();
	}

	void Shoot(){		
		var player = GameObject.FindGameObjectWithTag("Player");
		if(player != null){			
			var bullet = PoolManager.Instance.Allocate(PoolId.EnemyBullet, transform.position, Quaternion.identity);
			var rb2d = bullet.GetComponent<Rigidbody2D>();
			
			var directionToPlayer = player.transform.position - bullet.transform.position;
			directionToPlayer.Normalize();
			
			var randomAngle = Random.Range(-180, 180) * (1.0f-accuracy);
			var bulletDirection = Quaternion.AngleAxis(randomAngle, Vector3.forward) * directionToPlayer;
			rb2d.velocity = bulletDirection * bulletSpeed;	
		}		
		Invoke("Shoot", fireInterval);
	}
}
