using UnityEngine;
using System.Collections;
using FluffyUnderware.Curvy;
using FluffyUnderware.Curvy.Controllers;

public class EnemyStart : MonoBehaviour {
	public float delay = 3.0f;

	SplineController spline;
	// Use this for initialization
	void Start () {
		
	}

	void OnEnable() {
		Debug.Log("Enemy is waking up");
		spline = gameObject.GetComponent<SplineController>();
		spline.ResetOnStop = true;
		spline.Stop();
		StartCoroutine(StartMoving());
	}

	IEnumerator StartMoving(){
		Debug.Log("Getting ready to move");
		spline.AbsolutePosition= 0.0f;
		yield return new WaitForSeconds(delay);
		Debug.Log("Now move");
		spline.Play();
	}

	// Update is called once per frame
	void Update () {
	
	}
}
