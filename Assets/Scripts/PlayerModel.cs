using UnityEngine;
using System.Collections;

public class PlayerModel : MonoBehaviour {
	public Camera playerCamera;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
//		transform.rotation = playerCamera.transform.rotation;
		transform.rotation = Quaternion.Euler(
			0.0F,
			playerCamera.transform.rotation.eulerAngles.y,
			0.0F
		);
	}
}
