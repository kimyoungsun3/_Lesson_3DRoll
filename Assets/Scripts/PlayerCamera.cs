using UnityEngine;
using System.Collections;

//[AddComponentMenu("Camera/3RDPerson Camera")]
public class PlayerCamera : MonoBehaviour {

	public Transform target;
	// The distance in the x-z plane to the target
	public float distance = 15;
	// the height we want the camera to be above the target
	public float height = 5;
	// How much we 
	public float heightDamping = 3;
	public float rotationDamping = 3;
	public Vector2 DISTANCE = new Vector2(10f, 15f);
	float distanceInterpolate = 1f;
	public float MOUSE_SENCE = 0.001f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (target){

			float _wheel = Input.GetAxis ("Mouse ScrollWheel");
			if ( _wheel > 0f) {
				distanceInterpolate -= MOUSE_SENCE * Time.deltaTime;
				if (distanceInterpolate < 0f) {
					distanceInterpolate = 0f;
				}
			} else if (_wheel < 0f) {
				distanceInterpolate += MOUSE_SENCE * Time.deltaTime;
				if (distanceInterpolate > 1f) {
					distanceInterpolate = 1f;
				}
			}
			distance = Mathf.Lerp (DISTANCE.x, DISTANCE.y, distanceInterpolate);
		

			// Calculate the current rotation angles
			float wantedRotationAngle = target.eulerAngles.y;
			float wantedHeight = target.position.y + height;

			float currentRotationAngle = transform.eulerAngles.y;
			float currentHeight = transform.position.y;

			// Damp the rotation around the y-axis
			currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

			// Damp the height
			currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);

			// Convert the angle into a rotation
			Quaternion currentRotation = Quaternion.Euler (0, currentRotationAngle, 0);

			// Set the position of the camera on the x-z plane to:
			// distance meters behind the target

			Vector3 pos = target.position;
			pos -= currentRotation * Vector3.forward * distance;
			pos.y = currentHeight;
			transform.position = pos;


			// Always look at the target
			transform.LookAt (target);
		}
	}


}