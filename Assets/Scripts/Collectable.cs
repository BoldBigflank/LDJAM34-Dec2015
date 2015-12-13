using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log("Collided " + other.tag);
		if(other.tag == "Player"){
			
			// Remove me
			// Increment score
			GameManager.current.CoinCollected();
			gameObject.SetActive(false);
		}
	}
}
