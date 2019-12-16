using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
	#region Declaration public
	public string _tagPlayer;
	#endregion

	#region Declaration private
	float _horizontalLimit;
	Camera _camera;
	#endregion

	private void Start()
	{
		#region Initialize
		_camera = Camera.main;
		_horizontalLimit = _camera.orthographicSize * _camera.aspect;
		#endregion
	}

	private void Update()
	{
		#region Mouvements
		_horizontalLimit = (_camera.orthographicSize * _camera.aspect) - _camera.transform.position.x;
		#endregion

		#region Actions
		SelfDestroy();
		#endregion
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == _tagPlayer)
		{
			//Destroy(collision.gameObject);
			Destroy(gameObject);
		}
	}

	#region Helper
	public void SelfDestroy()
	{
		
		if (transform.position.x < -_horizontalLimit)
		{
			Destroy(gameObject, 1);
		}
	}
	#endregion
}
