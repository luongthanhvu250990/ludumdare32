﻿using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour
{
	static SceneController _instance;
	
	public static SceneController Instance
	{
		get { return _instance ?? GameObject.FindObjectOfType<SceneController>(); }
	}

	void Awake ()
	{
		DontDestroyOnLoad(gameObject);
	}

	public void FadeToScene (string sceneName, Transform playerTransform, Vector3 newPosition)
	{
		StartCoroutine(FadeToSceneAsync(sceneName, playerTransform, newPosition));
	}
	
	IEnumerator FadeToSceneAsync(string sceneName, Transform playerTransform, Vector3 newPosition)
	{
		GUIController.Instance.FadeToBlack();
		yield return new WaitForSeconds (1.1f);
		
		if (sceneName == "victory_screen")
		{
			foreach (Renderer r in playerTransform.GetComponentsInChildren<Renderer>())
				r.enabled = false;
		}

		Application.LoadLevel(sceneName);
		if (playerTransform != null)
			playerTransform.position = newPosition;
		GUIController.Instance.FadeInFromBlack();
	}
}
