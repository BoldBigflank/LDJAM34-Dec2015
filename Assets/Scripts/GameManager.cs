using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class GameManager : MonoBehaviour {
	public static GameManager current;

	public Text coinText;
	public Text timerText;
	Vector3 startPosition;

	public GameObject prison;
	public GameObject ladder;
	GameObject[] enemies;
	GameObject[] coins;

	GameObject player;
	int coinCount;
	bool gameInProgress;
	float timer;
	int caughtCount;


	// Use this for initialization
	void Start () {
		gameInProgress = false;
		Application.targetFrameRate = 30;
		GameManager.current = this;
		caughtCount = 0;
		coins = GameObject.FindGameObjectsWithTag("Coin");
		coinCount = coins.Length;
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
		player = GameObject.FindGameObjectWithTag("Player");
		startPosition = player.transform.position;

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

	void Escaped(){
		// Fly off

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

		gameInProgress = false;
		timer = 0.0f;
		caughtCount = 0;
	}
}
