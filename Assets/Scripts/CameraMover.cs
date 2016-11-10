using UnityEngine;
using System.Collections;

public class CameraMover : MonoBehaviour 
{
	public float moveDistanceOnTap;
	[Range(0f,1f)]
	public float moveSpeed;
	Vector3 targetPos;

	// Use this for initialization
	void Start () 
	{
		targetPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (Input.touchCount == 1) 
		{
			Touch doubleTapChecker = Input.GetTouch(0);
			if (doubleTapChecker.tapCount >= 2) 
			{
				GoForward ();
			}
		}
	}

	void FixedUpdate()
	{
		if (targetPos != transform.position) 
		{
			transform.position = Vector3.MoveTowards (transform.position, targetPos, 0.5f);
		}
	}

	void GoForward()
	{
		targetPos += transform.forward * moveDistanceOnTap;
	}
}
