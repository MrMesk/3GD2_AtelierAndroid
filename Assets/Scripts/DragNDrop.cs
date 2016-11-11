using UnityEngine;
using System.Collections;

public class DragNDrop : MonoBehaviour {

	private float dist;
	private bool dragging = false;
	private Vector3 offset;
	private Transform toDrag;

	public Vector3 redBlocPos;
	public Vector3 greenBlocPos;
	public Vector3 blueBlocPos;

	public float distMarge;

	public float margeRed = 0.8f;
	public float margeGreen = 0.8f;
	public float margeBlue = 0.8f;

	Vector3 basePos;

	void Update() {
		Vector3 v3;

		//Debug.Log (GetComponent<Renderer> ().material.color.r);

		if (Input.touchCount != 1) {
			dragging = false; 
			return;
		}

		Touch touch = Input.touches[0];
		Vector3 pos = touch.position;

		if(touch.phase == TouchPhase.Began) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(pos); 
			if(Physics.Raycast(ray, out hit) && (hit.collider.tag == "Draggable"))
			{
				basePos = hit.transform.position;
				Debug.Log ("Here");
				toDrag = hit.transform;
				dist = hit.transform.position.z - Camera.main.transform.position.z;
				v3 = new Vector3(pos.x, pos.y, dist);
				v3 = Camera.main.ScreenToWorldPoint(v3);
				offset = toDrag.position - v3;
				dragging = true;
			}
		}
		if (dragging && touch.phase == TouchPhase.Moved) {
			v3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
			v3 = Camera.main.ScreenToWorldPoint(v3);
			toDrag.position = v3 + offset;
		}
		if (dragging && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)) {
			dragging = false;

			// tester color here
			if (toDrag.name == "RefR") {
				Debug.Log ("red");
				if ((toDrag.GetComponent<Renderer>().material.color.r > margeRed) && ( Vector3.Distance(redBlocPos, toDrag.position) < distMarge)) {
					Destroy (toDrag.gameObject);
				}
				else {
					toDrag.position = basePos;
				}
			}


			if (toDrag.name == "RefV") {
				Debug.Log ("green");
				if ((toDrag.GetComponent<Renderer>().material.color.g > margeGreen) && (Vector3.Distance(greenBlocPos, toDrag.position) < distMarge)) {
					Destroy (toDrag.gameObject);
				}
				else {
					toDrag.transform.position = basePos;
				}
			}


			if (toDrag.name == "RefB") {
				Debug.Log ("blue");
				if ((toDrag.GetComponent<Renderer>().material.color.b > margeBlue) && (Vector3.Distance(blueBlocPos, toDrag.position) < distMarge)) {
					Destroy (toDrag.gameObject);
				}
				else {
					toDrag.transform.position = basePos;
				}
			}

		}
	}

}
