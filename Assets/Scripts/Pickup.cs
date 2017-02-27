using UnityEngine;

public abstract class Pickup : MonoBehaviour {
	public abstract void AttachToPlayer(GameObject player);
	public abstract void Use();
}
