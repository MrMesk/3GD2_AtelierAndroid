using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour 
{
	public float maxFOVValue;
	public float minFOVValue;
	public float zoomSpeed;
	public Camera cam;

	// Use this for initialization
	void Start () 
	{
		if (cam == null) 
		{
			cam = Camera.main;
		}
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.touchCount == 2) 
		{
			FoVChange (PinchManager());
		} 
	}

	float PinchManager()
	{

		Touch touchZero = Input.GetTouch (0);
		Touch touchOne = Input.GetTouch (1);

		Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
		Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

		float prevTouchDeltaMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
		float touchDeltaMagnitude = (touchZero.position - touchOne.position).magnitude;

		return prevTouchDeltaMagnitude - touchDeltaMagnitude;


	}
	void FoVChange(float modifier)
	{
		float zoomedFoV = cam.fieldOfView + modifier;

		zoomedFoV = Mathf.Clamp (zoomedFoV, minFOVValue, maxFOVValue);
		//Debug.Log ("Cam FoV" + zoomedFoV);

		cam.fieldOfView = zoomedFoV;
	}
}
