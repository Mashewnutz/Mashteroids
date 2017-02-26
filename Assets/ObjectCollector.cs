using System.Collections.Generic;
using UnityEngine;

public class ObjectCollector : MonoBehaviour {

	public bool debugDrawObjects = false;
	public List<GameObject> objects;	

	void OnEnable(){
		objects = new List<GameObject>();
	}
	
	void OnDisable()
	{
		objects.Clear();
	}

	void Update(){
		if(debugDrawObjects){
			DebugDrawObjects();
		}

		PurgeDeadObjects();
	}

	void PurgeDeadObjects(){		
		objects.RemoveAll(obj => obj == null);		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Asteroid"){
			objects.Add(other.gameObject);
		}else if(other.gameObject.tag == "Ufo"){
			objects.Add(other.gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		objects.Remove(other.gameObject);
	}

	void DebugDrawObjects(){
		foreach(var obj in objects){
			var pos = obj.transform.position;
			Debug.DrawLine(pos + Vector3.up, pos + Vector3.down, Color.red);
			Debug.DrawLine(pos + Vector3.left, pos + Vector3.right, Color.red);
		}
	}
}
