using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour {

	public float rotFactor;

	public float initFactor;
	//Quaternion rotationInit;

	// Use this for initialization
	void Start () {
		Input.gyro.enabled = true;

		//rotationInit = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (-Input.gyro.rotationRateUnbiased.x * rotFactor, -Input.gyro.rotationRateUnbiased.y * rotFactor, 0);

		/*if (Input.acceleration.x > initFactor) {
			transform.rotation = rotationInit;
		}*/
	}
}
