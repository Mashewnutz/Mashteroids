using UnityEngine;

public class ShipInput : MonoBehaviour {
	
	public GameObject bulletPrefab;
	public float thrust = 1.0f;
	public float rotation = 1.0f;
	public float bulletSpeed = 1.0f;
	public float fireRate = 10;
	private Rigidbody2D rb2d;
	private GameObject thruster;
	private Animator animator;
	private float fireInterval;

	void Awake() {
		rb2d = GetComponent<Rigidbody2D>();
		thruster = transform.GetChild(0).gameObject;
	}

	void OnEnable(){
		fireInterval = 1/fireRate;
		thruster.SetActive(false);
	}

	void OnDisable(){
		CancelInvoke();
	}

	void Update() {
		if(Input.GetKeyDown(KeyCode.Space)){			
			Fire();
		} else if(Input.GetKeyUp(KeyCode.Space)){
			CancelInvoke();			
		} else if(Input.GetKeyDown(KeyCode.H)){
			FireMissle();
		}
	}
		
	void FixedUpdate () {

		if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){			
			rb2d.AddForce(transform.up * thrust);
			thruster.SetActive(true);
		} else {
			thruster.SetActive(false);
		}

		if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){			
			rb2d.rotation += rotation;
		}
		if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
			rb2d.rotation -= rotation;
		}
	}

	void Fire() {
		var bullet = PoolManager.Instance.Allocate(PoolId.Bullet, transform.position, Quaternion.identity);		
		var bulletRb2d = bullet.GetComponent<Rigidbody2D>();
		bulletRb2d.velocity = transform.up;
		bulletRb2d.velocity.Normalize();
		bulletRb2d.velocity *= bulletSpeed;
		Invoke("Fire", fireInterval);
	}

	void FireMissle() {

	}

}
