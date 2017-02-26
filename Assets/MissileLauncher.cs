using UnityEngine;

public class MissileLauncher : Pickup {
	
	public GameObject leftMissile;	
	public GameObject rightMissile;
	private Rigidbody2D rb2d;

	public override void AttachToPlayer(GameObject player){
		transform.SetParent(player.transform, false);
		rb2d = player.GetComponent<Rigidbody2D>();
	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.H)){			
			if(leftMissile != null){
				LaunchMissile(leftMissile);				
				leftMissile = null;
			} else if(rightMissile != null){
				LaunchMissile(rightMissile);
				rightMissile = null;
			}

			if(leftMissile == null && rightMissile == null){
				Destroy(gameObject);
			}
		}	
	}

	void LaunchMissile(GameObject launcher){
		launcher.SetActive(false);
		var missile = PoolManager.Instance.Allocate(PoolId.Missile, launcher.transform.position, launcher.transform.rotation);		
		var missileRb2d = missile.GetComponent<Rigidbody2D>();
		missileRb2d.velocity = rb2d.velocity;
	}
}
