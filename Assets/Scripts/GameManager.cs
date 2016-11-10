using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
	public static GameManager GM;

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


}
