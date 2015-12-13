using UnityEngine;
using System.Collections;

public class RemoteVisibility : MonoBehaviour {
	GameObject player;

	public bool isPlaceholder = false;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if( gameObject.layer != LayerMask.NameToLayer("Below") && 
			transform.position.y < player.transform.position.y - 0.5f){
			if(isPlaceholder){
				gameObject.SetActive(false);
			} else {
				SetLayer(gameObject, LayerMask.NameToLayer("Below"));
			}

		} else if ( gameObject.layer != LayerMask.NameToLayer("Above") && 
			transform.position.y >= player.transform.position.y ){
			if(isPlaceholder){
				gameObject.SetActive(true);
			} else {
				SetLayer(gameObject, LayerMask.NameToLayer("Above"));
			}

		}
	}

	void SetLayer(GameObject cur, int layer){
		cur.layer = layer;
		foreach(Transform child in cur.transform){
			SetLayer(child.gameObject, layer);
		}
	}
}
