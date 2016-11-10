using UnityEngine;
using System.Collections;

public class DragTest : MonoBehaviour {

	public GameObject selectedCube = null;
	public GameObject canalRéférent;
	public float margeDerreur ;
	private Vector3 cubePosition;

	public Vector3 originalPosition;

	// Use this for initialization
	void Start () {

		originalPosition = transform.position;
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
			if (touched) 
			{
				selectedCube = hitInfo.collider.gameObject;
			}
		}
		if (Input.GetMouseButtonUp (0) && selectedCube !=null) 
		{
			float checkDist = Vector3.Distance (selectedCube.transform.position, canalRéférent.transform.position);
			if (checkDist < margeDerreur) {
				selectedCube.transform.position = canalRéférent.transform.position;
			}
				else
					selectedCube.transform.position = originalPosition;
			
			//check si sur referent.
			//sinon pos = pos init
			selectedCube = null;
		}
		if (Input.GetMouseButton (0) && selectedCube !=null) 
			{
			Vector2 mouseCache = Input.mousePosition;
			//Vector3 cubePosition2 = new Vector3 (mouseCache.x, mouseCache.y, 0);
			float dist = Vector3.Distance (Camera.main.transform.position, selectedCube.transform.position);
			Vector3 cubePosition2 = Camera.main.ScreenToWorldPoint (Input.mousePosition) + dist * Camera.main.ScreenPointToRay (mouseCache).direction;
			selectedCube.transform.position = new Vector3(cubePosition2.x, cubePosition2.y, selectedCube.transform.position.z);
			//bouger objet ici
			}
		}
	void FixedUpdate() 
	{
		//selectedCube.transform.position = cubePosition;
	}
}