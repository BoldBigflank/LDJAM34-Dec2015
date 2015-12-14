using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using FluffyUnderware.Curvy;
using FluffyUnderware.Curvy.Controllers;


public class GameManager : MonoBehaviour {
	public static GameManager current;

	public Text coinText;
	public Text timerText;
	public Text resultText;
	Vector3 startPosition;

	public GameObject prison;
	public GameObject ladder;
	public GameObject castCamera;

	GameObject[] enemies;
	GameObject[] coins;

	GameObject player;
	int coinCount;
	bool gameInProgress;
	bool escaped;
	float timer;
	int caughtCount;


	// Use this for initialization
	void Start () {
		gameInProgress = false;
		escaped = false;
		Application.targetFrameRate = 30;
		GameManager.current = this;
		caughtCount = 0;
		coins = GameObject.FindGameObjectsWithTag("Coin");
		coinCount = coins.Length;
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
		player = GameObject.FindGameObjectWithTag("Player");
		startPosition = player.transform.position;

		castCamera.GetComponent<SplineController>().ResetOnStop = true;

		NewGame();
	}

	void Awake () {

	}
	// Update is called once per frame
	void Update () {
		if(gameInProgress) timer += Time.deltaTime;
		coinText.text = coinCount > 0 ? "Coins left: " + coinCount : "Escape!";
//		timerText.text = string.Format("{0:00}:{1:00}", timer % 60, Mathf.FloorToInt( timer ) / 60  );
		timerText.text = Mathf.FloorToInt(timer/60).ToString("D2") + ":" + Mathf.FloorToInt(timer%60).ToString("D2");
	}

	public void CoinCollected(){
		Debug.Log("CoinCollected");
		coinCount -= 1;

		if(coinCount <= 0) ladder.SetActive(true);
	}


	// The trigger at the door fires this
	public void StartEnemies(){
		Debug.Log("GameManager StartEnemies");
		// After some time, start the enemy on her path
		foreach(GameObject enemy in enemies){
			Debug.Log("GameManager Setting enemy active");
			enemy.SetActive(false);
			enemy.SetActive(true);
		}
		gameInProgress = true;
	}

	public void Caught(){
		caughtCount++;

		// Freeze the player and enemies

		// Play a sound


		// Wait a few seconds

		// Drop the player in prison
		player.transform.position = Vector3.up * 4.0F + prison.transform.position;


	}

	public void Escaped(){
		escaped = true;
		// Fly off
		castCamera.GetComponent<SplineController>().Play();
		castCamera.GetComponent<CopterSway>().enabled = false;

		// Show the result score
		string result = "You escaped!\n";
		result += "You took " + Mathf.FloorToInt(timer/60).ToString("D2") + ":" + Mathf.FloorToInt(timer%60).ToString("D2") + " to escape\n";
		result += "You were caught " + caughtCount + " times\n";
		result += "Press a button to try again";

		resultText.text = result;
	}

	public void Retry(){
		// Caught player wants to start again
		player.transform.position = startPosition;
		foreach(GameObject enemy in enemies) {
			enemy.SetActive(false);

		}
		gameInProgress = false;
	}

	void NewGame(){
		// Reset the coins
		coinCount = GameObject.FindGameObjectsWithTag("Coin").Length;

		foreach(GameObject coin in coins){
			coin.SetActive(true);
		}

		// Reset the enemies
		foreach(GameObject enemy in enemies){
			enemy.SetActive(false);
		}

		// Reset the player
		player.transform.position = startPosition;

		// Reset the ladder
		ladder.SetActive(false);
		castCamera.GetComponent<SplineController>().Stop();
		castCamera.GetComponent<CopterSway>().enabled = true;

		gameInProgress = false;
		escaped = false;
		timer = 0.0f;
		caughtCount = 0;
		resultText.text = "";

	}

	public void StartNewGame(){
		if( escaped ){
			NewGame();
		}
	}

}
