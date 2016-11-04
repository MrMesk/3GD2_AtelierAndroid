using UnityEngine;
using System.Collections;

public class ColorMatcher : MonoBehaviour {

	public Color meshColor;
	public GameObject ball;

	WebCamTexture webcamTexture;

	// Use this for initialization
	void Start () {
		webcamTexture = new WebCamTexture();
		webcamTexture.Play();
	}
	
	// Update is called once per frame
	void Update () {
		meshColor = moyenne (webcamTexture.GetPixels());

		ball.GetComponent<Renderer> ().material.color = meshColor;
	}

	Color moyenne (Color[] pixels) {
		float redSum = 0;
		float greenSum = 0;
		float blueSum = 0;

		for (int i = 0; i < pixels.Length; i++) {
			redSum += pixels [i].r;
			greenSum += pixels [i].g;
			blueSum += pixels [i].b;
		}

		return new Color (redSum / pixels.Length, greenSum / pixels.Length, blueSum / pixels.Length);
	}
}
