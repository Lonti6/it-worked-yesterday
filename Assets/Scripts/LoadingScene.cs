using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
	public string sceneName;
	public void ChangeScene()
	{
		SceneManager.LoadScene(sceneName);
	}
	public void Exit()
	{
		Application.Quit();
	}
}
