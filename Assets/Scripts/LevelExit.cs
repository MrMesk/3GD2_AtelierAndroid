using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelExit : MonoBehaviour
{
	public Canvas endLevelText;
	public string levelToLoad;
	bool levelEnd;
	// Use this for initialization
	void Start ()
	{
		endLevelText.enabled = false;
		levelEnd = false;
	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.touchCount == 1 && levelEnd)
		{
			GameManager.GM.NextLevel(levelToLoad);
		}
	}
	void OnTriggerEnter()
	{
		levelEnd = true;
		endLevelText.enabled = true;
	}
}
