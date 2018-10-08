using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenLibrary
{
	public static Vector2 LinearTween(Vector2 _pos, Vector2 _target, float _t)
	{
		return _pos + (_target - _pos) * _t;
	}
}
