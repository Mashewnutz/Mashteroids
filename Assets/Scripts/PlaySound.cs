using UnityEngine;

public class PlaySound : MonoBehaviour {

	public AudioClip clip;
	public bool onEnable = true;
	public bool onDisable = false;
	
	void OnEnable () {
		if(onEnable)
			SoundEffects.Instance.Play(clip);
	}

	void OnDisable () {
		if(onDisable)
			SoundEffects.Instance.Play(clip);
	}
}
