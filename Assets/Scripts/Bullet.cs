using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DirerctionBullet
{
	Left,
	Right,
    Up,
    Down
}

public class Bullet : MonoBehaviour
{
	#region Declarations public
	public float _speed = 0;
	public float _lifeTime = 0;
	public DirerctionBullet _directionBullet;
	#endregion

	#region Declaration private
	float _x;
    float _y;
	#endregion

	void Start()
	{
		#region Initialize
		Destroy(gameObject, _lifeTime);
		BulletDirection();
		#endregion
	}

	void Update()
	{
		#region Mouvement
		transform.Translate(new Vector3(_x, 0, 0) * _speed * Time.deltaTime);
		#endregion
	}

	#region Helper
	public void setLifeTImeAndSpeed(float speed,float lifeTime)
	{
		_speed = speed;
		_lifeTime = lifeTime;
	}

	public void BulletDirection()
	{
		if(_directionBullet == DirerctionBullet.Left)
		{
			_x = -1;
		}
		else if(_directionBullet == DirerctionBullet.Right)
		{
			_x = 1;
		}
        else if(_directionBullet == DirerctionBullet.Up)
        {
            _x = -1;
            transform.Rotate(new Vector3(0,0,-90));
        }
        else if (_directionBullet == DirerctionBullet.Down)
        {
            _x = 1;
            transform.Rotate(new Vector3(0, 0, 90));
        }
    }
	#endregion
}
