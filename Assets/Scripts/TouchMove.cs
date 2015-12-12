using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class TouchMove : MonoBehaviour {
	
	public float speed = 6.0F;
    public Camera forwardCamera;

    void Update() {
        CharacterController controller = GetComponent<CharacterController>();
        Vector3 forward = forwardCamera.transform.forward;
        float curSpeed = (Input.touchCount > 0 || Input.GetKey(KeyCode.W)) ? speed : 0.0f;
        controller.SimpleMove(forward * curSpeed);
    }
}
