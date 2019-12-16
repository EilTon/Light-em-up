using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
	#region Declarations public
	public Transform _target;
	public float _orbitDistance;
	public float _orbitDegree;
	public float _shootLight;
	public string _tagEnemy;
	public string _tagBullet;
	public GameObject _prefabSprited;
	public GameObject _prefabEnemy;
	#endregion

	#region Declaration private
	float _limitMaxOrbit;
	float _limitMinOrbit;
	Vector3 _distance;
	Animator _explosionAnimation;
	float _time = 0.79f;
	bool _trigger = false;
	#endregion

	// Use this for initialization
	void Start()
	{
		#region Initialize
		_limitMaxOrbit = _orbitDistance * _shootLight;
		_limitMinOrbit = _orbitDistance;
		_explosionAnimation = _prefabSprited.GetComponent<Animator>();
		#endregion
	}

	void LateUpdate()
	{
		if (_trigger == true)
		{
			if (_time < 0)
			{
				Destroy(_prefabSprited);
			}
			else
			{
				_time -= Time.deltaTime;
			}
		}
		Orbit();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == _tagBullet)
		{
			Destroy(collision.gameObject);
		}
		else if(collision.tag == _tagEnemy)
		{
			Destroy(collision.gameObject);
		}
	}

	#region Helper
	void Orbit()
	{
		if (_target != null)
		{
			if (Input.GetKey(KeyCode.Space))
			{
				if (_orbitDistance < _limitMaxOrbit)
				{
					_orbitDistance = _limitMaxOrbit;
				}
			}
			else
			{
				if (_orbitDistance > _limitMinOrbit)
				{
					_orbitDistance = _limitMinOrbit;
				}
			}
			_distance = _target.position + (transform.position - _target.position).normalized * _orbitDistance;
			transform.position = _distance;
			transform.RotateAround(_target.position, Vector3.forward, _orbitDegree * Time.deltaTime);
		}
	}
	#endregion
}
