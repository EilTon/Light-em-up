using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoad : MonoBehaviour
{
	float _time = 1;
	bool _isTrigger = false;
	private void Start()
	{
		_time = 1;
	}
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{

			GetComponent<AudioSource>().Play();
			_isTrigger = true;


		}

		if (_isTrigger == true)
		{
			_time -= Time.deltaTime;
			Debug.Log(_time);
		}

		if (_time < 0)
		{
			SceneManager.LoadScene("Lvl Design");
		}
	}
}
