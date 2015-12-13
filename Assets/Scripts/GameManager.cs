using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class GameManager : MonoBehaviour {
	public static GameManager current;

	public Text coinText;
	public Vector3 startPosition = new Vector3 (-4.0F, 2.0F, -18.0F);

	public GameObject prison;
	public GameObject ladder;

	GameObject player;
	int coinCount;


	// Use this for initialization
	void Start () {
		Application.targetFrameRate = 30;
		GameManager.current = this;
	}

	void Awake () {
		player = GameObject.FindGameObjectWithTag("Player");
		coinCount = GameObject.FindGameObjectsWithTag("Coin").Length;
	}
	// Update is called once per frame
	void Update () {
		coinText.text = "Coins left: " + coinCount;
	}

	public void CoinCollected(){
		Debug.Log("CoinCollected");
		coinCount -= 1;

		if(coinCount <= 0) ladder.SetActive(true);
	}

	void StartTrigger(){
		// After some time, start the enemy on her path
	}

	public void Caught(){
		// Drop the player in prison
		player.transform.position = Vector3.up * 4.0F + prison.transform.position;


	}

	void Escaped(){
		// Fly off

	}

	void NewGame(){
		// Reset the coins
		coinCount = GameObject.FindGameObjectsWithTag("Coin").Length;
		// Reset the player
		player.transform.position = startPosition;

		// Reset the ladder
		ladder.SetActive(false);

	}
}
