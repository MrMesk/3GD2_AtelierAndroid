using UnityEngine;
using System.Collections;

public class ColorMatcherRVB : MonoBehaviour
{
	public Color meshColor;

	WebCamTexture webcamTexture;

	public GameObject rCube;
	public GameObject vCube;
	public GameObject bCube;
	bool rMatching = false;
	bool vMatching = false;
	bool bMatching = false;

	// Use this for initialization
	void Start ()
	{
		webcamTexture = new WebCamTexture();
		webcamTexture.Play();
	}

	// Update is called once per frame
	void Update ()
	{
		meshColor = GameManager.GM.Moyenne(webcamTexture.GetPixels());

		rCube.GetComponent<Renderer>().material.color = new Color(meshColor.r,0f,0f);
		vCube.GetComponent<Renderer>().material.color = new Color(0f, meshColor.g, 0f);
		bCube.GetComponent<Renderer>().material.color = new Color(0f, 0f, meshColor.b);
	}
}
