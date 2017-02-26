using UnityEngine;

public class MissileLauncher : MonoBehaviour {

	public GameObject leftMissile;	
	public GameObject rightMissile;

	void Awake(){
		leftMissile = transform.GetChild(0).gameObject;
		rightMissile = transform.GetChild(1).gameObject;
	}	

	void Update () {
		if(Input.GetKeyDown(KeyCode.H)){			
			if(leftMissile != null){
				LaunchMissile(leftMissile);				
				leftMissile = null;
			}

			if(rightMissile != null){
				LaunchMissile(rightMissile);
				rightMissile = null;
			}
		}	
	}

	void LaunchMissile(GameObject missile){
		missile.GetComponentInChildren<MissileSeeker>().enabled = true;
	}
}
