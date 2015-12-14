using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class TouchMove : MonoBehaviour {
	
	public float speed = 6.0F;
    public Camera forwardCamera;

    void Update() {
        CharacterController controller = GetComponent<CharacterController>();
        Vector3 forward = forwardCamera.transform.forward;
        float curSpeed = (Input.touchCount > 0 || Input.GetKey(KeyCode.LeftShift)) ? speed : 0.0f;
        controller.SimpleMove(forward * curSpeed);

		if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began){
			GameManager.current.StartNewGame();
		}
		if(Input.GetMouseButtonDown(0)){
			GameManager.current.StartNewGame();
		}
    }
}
