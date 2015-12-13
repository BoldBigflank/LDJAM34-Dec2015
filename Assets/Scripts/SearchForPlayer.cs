using UnityEngine;
using System.Collections;

public class SearchForPlayer : MonoBehaviour {
	public float searchAngle = 45.0F;
	public float sightDistance = 20.0F;

	GameObject player;


	// Use this for initialization
	void Start () {
	
	}

	void Awake () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		// Cast a ray to the player
		RaycastHit ray = new RaycastHit();

		// If it hits
		if(Physics.Linecast(transform.position, player.transform.position, out ray)) {
			if(ray.collider.tag == "Player") {
				float hitAngle = Vector3.Angle(ray.point - transform.position, transform.forward);
				// If the angle of the ray is close enough to the enemy camera
				if(hitAngle < searchAngle && ray.distance < sightDistance){
					// The player is caught, end the game.
					Debug.DrawLine ( transform.position, player.transform.position, Color.green);
					Debug.Log("BUSTED!");
					GameManager.current.Caught();
				}
			}
		}

	}
}
