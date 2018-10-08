using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pollen : MonoBehaviour
{
	public bool Active;
	public float Radius;

	[SerializeField] private float drain;
	[SerializeField] private float recharge;

	private void OnEnable()
	{
		InputManager.press += Select;
		InputManager.hold += Hold;
		InputManager.release += Deselect;
	}

	private void OnDisable()
	{
		InputManager.press -= Select;
		InputManager.hold -= Hold;
		InputManager.release -= Deselect;
	}

	private void Start()
	{
		Active = false;
	}

	private void Select(Vector2 _pos)
	{
		// 	Debug.Log("_pos " + _pos);
		if(Active) return;
		if(Vector2.Distance(this.transform.position, _pos) > Radius)
				return;

		Debug.Log("Pollen Selected and Active");
			Active = true;
	}

	private void Hold(Vector2 _pos)
	{

	}

	private void Deselect(Vector2 _pos)
	{

	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere(transform.position, Radius);
	}
}
