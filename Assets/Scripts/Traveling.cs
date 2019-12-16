using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traveling : MonoBehaviour
{
	#region Declaration public
	public float _speed;
	#endregion

	
	void Update()
	{
		#region Traveling
		Vector2 vector = new Vector2(_speed * Time.deltaTime, transform.position.y);
		transform.Translate(vector);
		#endregion
	}
}
