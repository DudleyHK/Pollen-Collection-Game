using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
	public delegate void Press(Vector2 _pos);
	public static event Press press;

	public delegate void Hold(Vector2 _pos);
	public static event Hold hold;

	public delegate void Release(Vector2 _pos);
	public static event Release release;


	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{
			var mouseDown = Input.GetMouseButtonDown(0);
			var mouseUp = Input.GetMouseButtonUp(0);
			var mouseMoving = Input.GetMouseButton(0);

			var input = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			if(mouseDown && press != null)
				press(new Vector2(input.x, input.y));

			if(mouseMoving && hold != null)
				hold(new Vector2(input.x, input.y));

		  if(mouseMoving && release != null)
				release(new Vector2(input.x, input.y));
	}
}
