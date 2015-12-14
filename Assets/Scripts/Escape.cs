using UnityEngine;
using System.Collections;

public class Escape : MonoBehaviour {
	GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		// If we have the player, keep them at 0,0
		Transform t = gameObject.transform.FindChild("Player");
		if(t){
			t.localPosition = Vector3.zero;
		}
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log("Collided " + other.tag);
		if(other.tag == "Player"){
			// Attach the player to the ladder
			other.gameObject.transform.parent = transform;

			// Fire the escape plan
			GameManager.current.Escaped();
		}
	}

}
