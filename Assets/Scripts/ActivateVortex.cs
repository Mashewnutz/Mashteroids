
using UnityEngine;

public class ActivateVortex : MonoBehaviour {

	public float startDelay;
	public float vortexSpeed;
	private Rigidbody2D rb2d;
	private GameObject vortex;
	
	void Awake() {
		rb2d = GetComponent<Rigidbody2D>();
		vortex = transform.GetChild(0).gameObject;
	}

	// Use this for initialization
	void Start () {
		Invoke("Activate", startDelay);
	}
	
	void Activate(){
		rb2d.angularVelocity = vortexSpeed;
		vortex.SetActive(true);
	}
}
