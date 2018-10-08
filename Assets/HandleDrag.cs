using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleDrag : ScriptableObject
{
		public enum State { None, Begin, Moving, End }

		public delegate bool DragActive(State _state, Vector3 _worldPos);
		public static event DragActive dragActive;

		public static Vector3 DragWorldPos = Vector3.zero;
		public static float ChangeDelta = 0.5f;



		public static bool Begin(Vector3 _pixelPos)
		{
				Debug.Log("Drag Begin");
				// Validate start position
				// Validate drag direction

				//var worldPos = Camera.main.ScreenToWorldPoint(_pixelPos);
				//DragWorldPos = worldPos;

				// if(dragActive != null) dragActive(State.Begin, DragWorldPos);

				return true;
		}


		public static bool Move(Vector3 _pixelPos)
		{
				Debug.Log("Drag Move");

				var worldPos = Camera.main.ScreenToWorldPoint(_pixelPos);

				if((worldPos.x > DragWorldPos.x + ChangeDelta || worldPos.x < DragWorldPos.x - ChangeDelta) ||
					(worldPos.y > DragWorldPos.y + ChangeDelta || worldPos.y < DragWorldPos.y - ChangeDelta))
				{
						DragWorldPos = worldPos;

						Debug.Log("World position - " + worldPos);
				}

				if(dragActive != null) dragActive(State.Moving, DragWorldPos);




				return true;
		}

		public static bool End(Vector3 _pixelPos)
		{
			Debug.Log("Drag End");

				// Validate end position
				// Validate line length

				var worldPos = Camera.main.ScreenToWorldPoint(_pixelPos);


				DragWorldPos = Vector3.zero;

if(dragActive != null) dragActive(State.End, DragWorldPos);
					return true;
		}
}
