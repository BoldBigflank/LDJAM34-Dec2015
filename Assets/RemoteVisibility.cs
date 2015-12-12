using UnityEngine;
using System.Collections;

public class RemoteVisibility : MonoBehaviour {
	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if( gameObject.layer != LayerMask.NameToLayer("Below") && 
			transform.position.y < player.transform.position.y){
			SetLayer(LayerMask.NameToLayer("Below"));

		} else if ( gameObject.layer != LayerMask.NameToLayer("Above") && 
			transform.position.y > player.transform.position.y ){
			SetLayer(LayerMask.NameToLayer("Above"));
		}
	}

	void SetLayer(int layer){
		gameObject.layer = layer;
		foreach(Transform child in transform){
			child.gameObject.layer = layer;
		}
	}
}
