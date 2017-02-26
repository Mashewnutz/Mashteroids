using UnityEngine;

public class CameraShake : MonoBehaviour {

	public float strength;

	void Start(){
		GameEvents.Instance.OnPlayerDestroyed.AddListener(Shake);
	}

	void Shake() {
		var up = new Vector3(0, 1, 0);
		var force = Quaternion.AngleAxis(Random.Range(0, 360.0f), Vector3.forward) * up;
		force *= strength;
		GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);		
	}
}
