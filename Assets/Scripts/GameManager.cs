using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class GameManager : MonoBehaviour {
	public Text coinCount;

	// Use this for initialization
	void Start () {
		Application.targetFrameRate = 30;
	}
	
	// Update is called once per frame
	void Update () {
		coinCount.text = "Coins left: " + GameObject.FindGameObjectsWithTag("Coin").Length;
	}
}
