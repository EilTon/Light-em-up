using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
	#region Declarations public
	public RotateAround _player;
	
	#endregion
	
	#region Declarations privates
	bool _isPaused = false;
	#endregion

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{			
			PausedGame();
		}
	}

	#region Helpers
	public void PausedGame()
	{
		if (_isPaused)
		{
			_player.enabled = true;
			GetComponent<SpriteRenderer>().enabled = false;
			Time.timeScale = 1;
			_isPaused = false;

		}
		else	
		{
			_player.enabled = false;
			GetComponent<SpriteRenderer>().enabled = true;
			Time.timeScale = 0;
			_isPaused = true;
		}
	}
	#endregion
}