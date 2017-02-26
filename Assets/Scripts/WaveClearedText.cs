using UnityEngine;
using UnityEngine.UI;

public class WaveClearedText : MonoBehaviour {

	private Text text;

	void Awake () {
		text = GetComponent<Text>();
	}

	void Start() {
		GameEvents.Instance.OnWaveCleared.AddListener(OnWaveCleared);
		GameEvents.Instance.OnNewWave.AddListener(OnNewWave);
	}
	
	void OnWaveCleared(int wave){
		gameObject.SetActive(true);
		text.text = "WAVE " + wave + " CLEARED";
	}

	void OnNewWave(int wave){
		gameObject.SetActive(false);
	}
}
