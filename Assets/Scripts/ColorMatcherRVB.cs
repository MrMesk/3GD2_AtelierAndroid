using UnityEngine;
using System.Collections;

public class ColorMatcherRVB : MonoBehaviour
{
	public Color meshColor;

	public GameObject rCube;
	public GameObject vCube;
	public GameObject bCube;

	// Update is called once per frame
	void Update ()
	{
		meshColor = GameManager.GM.Moyenne();

		rCube.GetComponent<Renderer>().material.color = new Color(meshColor.r,0f,0f);
		vCube.GetComponent<Renderer>().material.color = new Color(0f, meshColor.g, 0f);
		bCube.GetComponent<Renderer>().material.color = new Color(0f, 0f, meshColor.b);
	}
}
