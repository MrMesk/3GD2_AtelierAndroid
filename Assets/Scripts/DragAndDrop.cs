using UnityEngine;
using System.Collections;

public class DragAndDrop : MonoBehaviour {

	public GameObject selectedCube ;
	private Vector3 cubePosition2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.touchCount >= 1)
		{
			foreach (Touch touch in Input.touches)	
			{
				Vector2 cubePosition = touch.position;
				Vector3 cubePosition2 = new Vector3 (cubePosition.x, cubePosition.y, 0);
			}
		}
	}
	void FixedUpdate () {
		selectedCube.transform.position = cubePosition2;
	}
}
