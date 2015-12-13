using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {
	public float spinSpeed = 120.0F;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0.0F, Time.deltaTime * spinSpeed, 0.0F);
	}
}
