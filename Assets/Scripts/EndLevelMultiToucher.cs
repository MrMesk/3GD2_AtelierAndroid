using UnityEngine;
using System.Collections;

public class EndLevelMultiToucher : MonoBehaviour {

	public GameObject EndCanvas;
	public string levelToLoad;
	bool levelEnd;

	// Use this for initialization
	void Start () {
		levelEnd = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (FindObjectsOfType<DragNDrop> ().Length == 0 && levelEnd == false)
		{
			EndCanvas.SetActive (true);
			levelEnd = true;
		}
		if (Input.touchCount > 0 && levelEnd)
		{
			GameManager.GM.NextLevel(levelToLoad);
		}
	}
}
