using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
	public void NewGame(string newGame)
	{
		SceneManager.LoadScene(newGame);
	}

    public void Controls(string controlsMenu)
	{
		SceneManager.LoadScene(controlsMenu);
	}

    public void Credits(string creditsMenu)
	{
		SceneManager.LoadScene(creditsMenu);
	}

    public void GoBack(string goBackButton)
	{
		SceneManager.LoadScene(goBackButton);
	}
}
