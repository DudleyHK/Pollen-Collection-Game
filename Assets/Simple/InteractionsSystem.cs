using System;
using System.Collections.Generic;
using EventSystem;
using ObjectSystem;
using UnityEngine;


namespace InteractionsSystem
{
	[System.Serializable]
	public class InteractionsManager
	{
		[SerializeField] private List<ObjectData> SelectedList;
		
		
		
		public void Start()
		{
			EventManager.AddListener(Events.ObjectSelected, new System.Action<ObjectData>(HandleSelected));

			SelectedList = new List<ObjectData>(2)
			{
				new ObjectData {name = String.Empty, pos = Vector3.zero},
				new ObjectData {name = String.Empty, pos = Vector3.zero}
			};
		}

		
		public void Update()
		{

		}
		

		private void HandleSelected(ObjectData _data)
		{
			ObjectData tmp;
			
			if (_data.name.Contains("Bee"))
			{
				if (SelectedList[0].name.Contains("Bee"))
					return;

				if (!SelectedList[0].name.Contains("Bee"))
				{
					tmp = SelectedList[0];
					tmp.name = _data.name;
					tmp.pos = _data.pos;
					SelectedList[0] = tmp;
				}
			}

			if (_data.name.Contains("Pollen"))
			{
				if (SelectedList[0].name.Contains("Bee"))
					SelectedList[1] = _data;
			}
			
			
		}
	}
}
