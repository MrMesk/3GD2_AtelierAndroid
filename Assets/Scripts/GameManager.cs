using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
	public static GameManager GM;

	WebCamTexture webcamTexture;

	public void NextLevel (string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}

	void Awake ()
	{
		if (GM != null)
		{
			Destroy(GM);
		}
		else
			GM = this;

		DontDestroyOnLoad(this);
	}

	void Start () {
		webcamTexture = new WebCamTexture();
		webcamTexture.Play();
	}

	public Color Moyenne ()
	{
		Color[] pixels = webcamTexture.GetPixels ();

		float redSum = 0;
		float greenSum = 0;
		float blueSum = 0;

		for (int i = 0; i < pixels.Length; i++)
		{
			redSum += pixels[i].r;
			greenSum += pixels[i].g;
			blueSum += pixels[i].b;
		}

		return new Color(redSum / pixels.Length, greenSum / pixels.Length, blueSum / pixels.Length);
	}
}
