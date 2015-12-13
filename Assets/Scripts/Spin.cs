using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {
	public float spinSpeed = 120.0F;

	// Use this for initialization
	void Start () {
		transform.rotation = Quaternion.Euler(0.0F, Random.Range(0, 360), 0.0F);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0.0F, Time.deltaTime * spinSpeed, 0.0F);
	}
}
