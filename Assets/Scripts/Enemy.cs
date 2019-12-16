using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	#region Declaration public
	public GameObject _bulletPrefab;
	public float _bulletSpeed;
	public float _bulletLife;
	public float _speed;
	public float _timeShoot;
	
	#endregion

	#region Declarations private
	float _lastShoot;
	float _horizontalLimit;
	Camera _camera;
	
	#endregion

	private void Start()
	{
		#region Initialize
		_lastShoot = _timeShoot;
		_camera = Camera.main;
		_horizontalLimit = _camera.orthographicSize * _camera.aspect;
		#endregion
	}
	private void Update()
	{
		#region Constraintes
		_horizontalLimit = (_camera.orthographicSize * _camera.aspect) - _camera.transform.position.x;
		#endregion

		#region Timer
		_timeShoot = _timeShoot - Time.deltaTime;
		
		#endregion

		#region Mouvements
		transform.Translate(horizontalDirection2D());
		#endregion

		#region Action
		Shoot();
		SelfDestroy();
		#endregion
	}

	#region Helper
	public Vector2 horizontalDirection2D()
	{
		Vector2 direction2D = new Vector2(-1 * _speed * Time.deltaTime, 0);
		return direction2D;
	}
	public void Shoot()
	{
		if (_timeShoot < 0)
		{
			GetComponent<AudioSource>().Play();
			GameObject tempBullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
			Bullet bullet = tempBullet.GetComponent<Bullet>();
			bullet.setLifeTImeAndSpeed(_bulletSpeed, _bulletLife);
			_timeShoot = _lastShoot;

		}
	}
	public void SelfDestroy()
	{
		if (transform.position.x < -_horizontalLimit)
		{
			Destroy(gameObject,1);
		}
	}
	#endregion

}
