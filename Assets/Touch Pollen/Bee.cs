using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
	[SerializeField] private bool Active;
	[SerializeField] private Transform target;
	[SerializeField] private float speed = 0.25f;
	[SerializeField] private float damping = 0.1f;


	private void Start()
	{
		Active = false;

	}

	private void Update()
	{
		if(!Active && target.GetComponent<Pollen>().Active)
		{
			Active = true;
		}
	}

	private void FixedUpdate()
	{
		if(Active)
		{
			transform.position = Vector2.LerpUnclamped(transform.position, target.position, speed * Time.fixedDeltaTime);

			if(Vector2.Distance(transform.position, target.position) < target.GetComponent<Pollen>().Radius / 2)
			{
				Active = false;
			//	target.GetComponent<Pollen>().Active = false;
			}

			if(!Active)
			{
				StartCoroutine(StopBee());
			}
		}
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
