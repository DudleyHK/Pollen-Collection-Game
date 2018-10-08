using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
	[SerializeField] private bool Active;
	[SerializeField] private Transform target;
	[SerializeField] private float speed = 0.25f;
	[SerializeField] private float damping = 0.1f;
	[SerializeField] private float gravity = -0.15f;
	[SerializeField] private float antiGravity = 0.15f;
	[SerializeField] private float gravityZone = 2f;





	private void Start()
	{
		Active = false;
	}

	private void Update()
	{
		if(!Active && target.GetComponent<Pollen>().Active)
			Active = true;
	}

	private void FixedUpdate()
	{
		if(Active)
		{
			transform.position = TweenLibrary.LinearTween(transform.position, target.position, speed * Time.fixedDeltaTime);
			transform.position = ApplyGravity(transform.position);

			if(Vector2.Distance(transform.position, target.position) < target.GetComponent<Pollen>().Radius / 2)
				Active = false;

			if(!Active)
			{
				StartCoroutine(StopBee());
			}
		}
	}

	private Vector2 ApplyGravity(Vector2 _pos)
	{
			if(_pos.y < target.position.y - gravityZone)
			{
				// switch to pos
				gravity = Mathf.Abs(gravity);
			}
			else if(_pos.y > target.position.y + gravityZone)
			{
				gravity = -gravity;
			}
			else
			{
					// Do nothing
			}


		return new Vector2(_pos.x, _pos.y + gravity * Time.fixedDeltaTime);
	}

	private IEnumerator StopBee()
	{
		var temp = damping;
		var rate = damping / 2f;

		while(temp >= 0f)
		{
			var dir = target.position - transform.position;

			temp -= rate * Time.fixedDeltaTime;
			transform.position += dir * temp  * Time.fixedDeltaTime;

			yield return false;
		}

		yield return true;
	}
}
