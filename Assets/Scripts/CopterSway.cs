using UnityEngine;
using System.Collections;

public class CopterSway : MonoBehaviour {
	public float swayRadius = 1.5F;

	Vector3 originalPosition;
	Vector3 swayDirection;
	Vector3 targetPosition;



	// Use this for initialization
	void Start () {
	
	}

	void Awake(){
		originalPosition = transform.position;
		swayDirection = Random.onUnitSphere * 6.0F;
		targetPosition = originalPosition + Random.onUnitSphere * swayRadius/2.0F;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += swayDirection * Time.deltaTime;
		if((transform.position - originalPosition).sqrMagnitude > swayRadius*swayRadius){
			swayDirection = Vector3.Lerp(swayDirection, -1 * (transform.position - targetPosition), Time.deltaTime);
		} else {
			targetPosition = originalPosition + Random.onUnitSphere * swayRadius/2.0F;
		}
	}
}
