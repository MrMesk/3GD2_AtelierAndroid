using UnityEngine;
using System.Collections;

public class DragTest : MonoBehaviour {

	public GameObject selectedCube = null;
	private Vector3 cubePosition;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			
			Vector2 mouseCache = Input.mousePosition;
			Ray rayPosition = Camera.main.ScreenPointToRay (mouseCache);
			RaycastHit hitInfo;
			bool touched = Physics.Raycast (rayPosition, out hitInfo);
			if (touched) {
				selectedCube = hitInfo.collider.gameObject;
			}
		}
		if (Input.GetMouseButtonUp (0)) 
		{
			//check si sur referent.
			//sinon pos = pos init
			selectedCube = null;
		}
		if (Input.GetMouseButton (0)) 
		{
			Vector2 mouseCache = Input.mousePosition;
			//Vector3 cubePosition2 = new Vector3 (mouseCache.x, mouseCache.y, 0);
			float dist = Vector3.Distance (Camera.main.transform.position, selectedCube.transform.position);
			Vector3 cubePosition2 = Camera.main.ScreenToWorldPoint (Input.mousePosition) + dist * Camera.main.ScreenPointToRay (mouseCache).direction;
			//bouger objet ici
		}
	}
	void FixedUpdate() 
	{
		selectedCube.transform.position = cubePosition;
	}
}