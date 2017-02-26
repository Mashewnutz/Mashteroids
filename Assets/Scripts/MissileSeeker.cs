using UnityEngine;

public class MissileSeeker : MonoBehaviour {

	public float thrust = 1;
	public float torque = 1f;	
	private GameObject target = null;
	private Rigidbody2D rb2d;
	ObjectCollector objectCollector;

	void Awake() {
		rb2d = GetComponent<Rigidbody2D>();
		objectCollector = GetComponentInChildren<ObjectCollector>();
	}

	void OnEnable(){
		target = FindTarget();
	}

	void OnDisable(){
		target = null;
	}
	
	void Update () {		
		if(target != null && target.active){

			var directionToTarget = target.transform.position - transform.position;
			Debug.DrawLine(transform.position, target.transform.position);						
			directionToTarget.Normalize();
			
			if(Vector3.Dot(transform.up, directionToTarget) < 0){
				target = null;
				rb2d.AddForce(transform.up * thrust);
			} else {
				rb2d.AddForce(directionToTarget * thrust);
			}			

		} else {
			rb2d.AddForce(transform.up * thrust);
			target = FindTarget();
		}
	}

	GameObject FindTarget() {
		var targets = objectCollector.objects;
		if(targets.Count == 0){
			return null;
		}

		return targets[0];
	}

	float SignedAngle(Vector3 v1, Vector3 v2){
		var angle = Vector3.Angle(v1, v2);
    	var cross = Vector3.Cross(v1, v2);
   		if (cross.z < 0) angle = -angle;
		return angle;
	}
}
