
using UnityEngine;

public class UfoWeapon : MonoBehaviour {
	public GameObject bulletPrefab;
	public float fireRate;
	public float fireAccuracy;
	public float bulletSpeed;
	private GameObject player;
	private float timeUntilNextShot;
	
	void Awake() {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		timeUntilNextShot += Time.deltaTime;
		if(timeUntilNextShot > fireRate){
			Shoot();
		}
	}

	void Shoot(){
		if(player == null)
			return;

		var bullet = GameObject.Instantiate(bulletPrefab, transform.position, Quaternion.identity);
		var rb2d = bullet.GetComponent<Rigidbody2D>();
		
		var directionToPlayer = player.transform.position - bullet.transform.position;
		directionToPlayer.Normalize();
		rb2d.velocity = directionToPlayer * bulletSpeed;
		
		timeUntilNextShot = 0;
	}
}
