
using UnityEngine;

public class ScrollBackground : MonoBehaviour {

	public float paralax = 1;
	private Rigidbody2D player = null;
	private Material material;

	void Awake() {
		var meshRenderer = GetComponent<MeshRenderer>();
		material = meshRenderer.material;
	}

	void Start() {
		GameEvents.Instance.OnPlayerSpawned.AddListener(OnPlayerSpawned);
		GameEvents.Instance.OnPlayerDestroyed.AddListener(OnPlayerDestroyed);
	}

	void OnPlayerSpawned(GameObject player) {
		this.player = player.GetComponent<Rigidbody2D>();
	}

	void OnPlayerDestroyed() {
		player = null;
	}

	void Update () {
		if(player != null){						
			Vector2 offset = material.mainTextureOffset;
			
			offset.x += player.velocity.x * Time.deltaTime * paralax;
			offset.y += player.velocity.y * Time.deltaTime * paralax;

			material.mainTextureOffset = offset;
		}		
	}
}
