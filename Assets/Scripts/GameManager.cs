using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

// Stores all static methods and functions we might be able to use
public class GameManager : MonoBehaviour
{
	public static GameManager GM;

	WebCamTexture webcamTexture;

	// This way we can access the scene manager from anywhere
	public void NextLevel (string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}

	void Awake ()
	{
		Application.RequestUserAuthorization(UserAuthorization.WebCam);
		// We make sure there are no other game managers in the scene.
		if (GM != null)
		{
			Destroy(GM);
		}
		else
			GM = this;

		DontDestroyOnLoad(this);
	}

	void Start ()
	{
		// We get the image from the device camera
		webcamTexture = new WebCamTexture();
		webcamTexture.Play();
	}

	//Returns the average color from the camera. We put it on the Game Manager so we can access that value from anywhere
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
