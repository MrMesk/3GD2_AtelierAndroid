using UnityEngine;
using System.Collections;

public class EndLevelMultiToucher : MonoBehaviour {

	public GameObject EndCanvas;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (FindObjectsOfType<DragNDrop> ().Length == 0) {
			EndCanvas.SetActive (true);
		}
	}
}
