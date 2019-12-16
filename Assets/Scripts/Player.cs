using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	#region Declaration public
	public float _speed = 1;
	public string _tagBullet;
	public GameObject _prefabSprited;
	public GameObject _light;
	#endregion

	#region Declaration private
	Camera _camera;
	float _horizontalLimit;
	float _verticalLimit;
	Vector2 _directionHorizontal;
	Vector2 _directionVertical;
	Animator _explosionAnimation;
	float _time = 0.79f;
	bool _trigger= false;
	AudioSource[] _audioSources;
	#endregion


	void Start()
    {
		#region Initialization
		_camera = Camera.main; 
		_horizontalLimit = _camera.orthographicSize * _camera.aspect;
		_verticalLimit = _camera.orthographicSize;
		_explosionAnimation = GetComponent<Animator>();
		_audioSources = GetComponents<AudioSource>();
		_audioSources[0].Play();
		#endregion
	}

	void Update()
    {
		#region Mouvements
		_directionHorizontal = horizontalDirection2D();
		_directionVertical = verticalDirection2D();
		transform.Translate(_directionHorizontal);
		transform.Translate(_directionVertical);
		#endregion

		#region Contraintes
		// permet de contrainte le vaisseau a ne pas dépasser les limites horizontal de la caméra
		transform.position = HorizontalLimit();
		transform.position = VerticalLimit();
		#endregion

		if(_trigger == true)
		{
			if(_time<0)
			{
				Destroy(gameObject);
				SceneManager.LoadScene("Game_Over");
			}
			else
			{
				_time -= Time.deltaTime;
			}
		}

	}

	#region Helper
	public Vector2 horizontalDirection2D() //permet le déplacement horizontal en 2D
	{
		Vector2 direction2D = new Vector2(-Input.GetAxis("Horizontal") * _speed * -Time.deltaTime, 0);
		return direction2D;
	}

	public Vector2 verticalDirection2D() //permet le déplacement vertical en 2D
	{
		Vector2 direction2D = new Vector2(0, -Input.GetAxis("Vertical") * _speed * -Time.deltaTime);
		return direction2D;
	}

	public Vector3 HorizontalLimit() //permet de fixer une limite à la caméra sur l'axe des X
	{
		float minHorizontalLimit = _camera.transform.position.x - _horizontalLimit;
		float maxHorizontalLimit = _camera.transform.position.x + _horizontalLimit;
		Vector3 hLimit = new Vector3(Mathf.Clamp(transform.position.x, minHorizontalLimit, maxHorizontalLimit), transform.position.y, transform.position.z);
		return hLimit;
	}

	public Vector3 VerticalLimit() //permet de fixer une limite à la caméra sur l'axe des Y
	{
		float minVerticalLimit = _camera.transform.position.y - _verticalLimit; ;
		float maxVerticalLimit = _camera.transform.position.y + _verticalLimit; ;
		Vector3 vLimit = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -_verticalLimit, _verticalLimit), transform.position.z);
		return vLimit;
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == _tagBullet || collision.tag == "Mine")
		{
			//Destroy(gameObject);
			_explosionAnimation.enabled=true;
			_audioSources[1].Play();
			Destroy(_light);
			GetComponent<SpriteRenderer>().enabled = true;
			_prefabSprited.GetComponent<SpriteRenderer>().enabled = false;
			_explosionAnimation.Play("Fx_Exploxion");
			_trigger = true;
			//SceneManager.LoadScene("Game_over");
		}

		if(collision.tag == "Portal")
		{
			collision.GetComponent<AudioSource>().Play();
			SceneManager.LoadScene("Victory");
		}
	}
	#endregion


}
