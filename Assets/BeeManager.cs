using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeManager : MonoBehaviour
{
	public static List<Vector3> Path = new List<Vector3>();
	public static bool Following = false;
	public static bool PathComplete = false;


	public GameObject BeePrefab;
	public Rigidbody2D BeePrefabRB;


	private int pathID = 0;
	private int prevPathID = 0;


		private void OnEnable()
		{
				HandleDrag.dragActive += HandlePath;
		}

		private void OnDisable()
		{
				HandleDrag.dragActive -= HandlePath;
		}

	private void Start()
	{
			BeePrefabRB = BeePrefab.GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
			if(!PathComplete) return;

			var target = Path[pathID];

			var direction = (target - BeePrefab.transform.position).normalized;
			BeePrefabRB.velocity += new Vector2(direction.x, direction.y) * Time.deltaTime;

//BeePrefab.transform.position = Vector3.Slerp(BeePrefab.transform.position, target, Time.deltaTime);

			if(Vector3.Distance(BeePrefab.transform.position, target) <= 0.1f)
				pathID++;

			if(pathID >= Path.Count)
				PathComplete = false;

	}


	private bool HandlePath(HandleDrag.State _state, Vector3 _worldPos)
	{
			switch(_state)
			{
					case HandleDrag.State.Begin:
						break;

					case HandleDrag.State.Moving:
					Path.Add(new Vector3(_worldPos.x, _worldPos.y, BeePrefab.transform.position.z));
						break;

					case HandleDrag.State.End:
					// Path = new List<Vector3>();
					PathComplete = true;
						break;

					default:
						break;
			}
			return true;
	}
}
