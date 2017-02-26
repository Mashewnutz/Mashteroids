
using UnityEngine;
using UnityEngine.UI;

public class PickupText : MonoBehaviour {

	public float displayTime = 2;
	private Text text;
	
	void Awake() {
		text = GetComponent<Text>();
	}

	void Start () {
		gameObject.SetActive(false);
		GameEvents.Instance.OnPickupCollected.AddListener(OnPickupCollected);
	}
	
	// Update is called once per frame
	void OnPickupCollected (GameObject pickup) {
		text.text = pickup.name.ToUpper();
		gameObject.SetActive(true);
		Invoke("Hide", displayTime);
	}

	void Hide(){
		gameObject.SetActive(false);
	}
}
