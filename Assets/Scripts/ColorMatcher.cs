﻿using UnityEngine;
using System.Collections;

public class ColorMatcher : MonoBehaviour {

	public Color meshColor;

	public GameObject arch;
	public Color archColor;

	public GameObject door;

	public GameObject decorFolder;
	public GameObject[] elems;


	// Use this for initialization
	void Start () {
		AddToObjets ();
		//archColor = Color.red;  //test color
		archColor = new Color (Random.Range(0,1.0f), Random.Range(0,1.0f), Random.Range(0,1.0f));
		arch.GetComponent<Renderer> ().material.color = archColor;
	}
	
	// Update is called once per frame
	void Update () {
		meshColor = GameManager.GM.Moyenne();

		for (int i = 0; i < elems.Length; i++)
		{
			elems[i].GetComponent<Renderer> ().material.color = meshColor;
		}

		TestColor ();
	}

	// add all decor elements to elems so we can apply the color to all of them at once
	void AddToObjets () {
		elems = new GameObject[decorFolder.transform.childCount];

		for (int i = 0; i < decorFolder.transform.childCount; i++) {
			elems[i] = decorFolder.transform.GetChild (i).gameObject;
		}
	}


	// test if the arch color is approximatly the same as the one of the elems
	void TestColor () {
		if ((Mathf.Abs (meshColor.r - archColor.r) + Mathf.Abs (meshColor.g - archColor.g) + Mathf.Abs (meshColor.b - archColor.b)) < 0.3f) {
			door.SetActive (false);
		}
		else {
			door.SetActive (true);
		}
	}
}
