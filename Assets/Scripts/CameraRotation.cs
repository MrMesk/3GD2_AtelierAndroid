using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour {

	public float rotFactor;

	// Use this for initialization
	void Start () {
		Input.gyro.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (-Input.gyro.rotationRateUnbiased.x * rotFactor, -Input.gyro.rotationRateUnbiased.y * rotFactor, 0);
	}
}
