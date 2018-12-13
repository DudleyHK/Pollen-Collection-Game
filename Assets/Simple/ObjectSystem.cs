using System.Collections.Generic;
using UnityEngine;
using EventSystem;
using InputSystem;


namespace ObjectSystem
{
    public struct ObjectData
    {
        public string name;
        public Vector3 pos;
    }


    [System.Serializable]
    public class ObjectManager
    {
        [SerializeField] private List<GameObject> ObjectList = new List<GameObject>();
        [SerializeField] private readonly float clickDistThreshold = .5f;


        public void Start()
        {
            EventManager.AddListener(Events.Input, new System.Action<InputData>(OnClickEvent));

            CreateSphere("Bee", Color.yellow, new Vector3(-5, 0, 0), Vector3.one);
            CreateSphere("Pollen Cap", Color.red, new Vector3(5, 3, 0), Vector3.one);
            CreateSphere("Pollen Cap", Color.red, new Vector3(5, 0, 0), Vector3.one);
            CreateSphere("Pollen Cap", Color.red, new Vector3(5, -3, 0), Vector3.one);
        }


        public void Update(float _dt)
        {
        }


        private bool CreateSphere(string _name, Color _color, Vector3 _pos, Vector3 _scale)
        {
            var go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            go.name = _name;
            go.GetComponent<Renderer>().material.color = _color;
            go.transform.position = _pos;
            go.transform.localScale = _scale;

            ObjectList.Add(go);

            return true;
        }

        private void OnClickEvent(InputData _data)
        {
            // Debug.Log("ON CLICK DETECTED @worldPos - " + _data.worldPos);

            if (_data.TouchType == InputSystem.TouchType.Begun)
            {
                foreach (var obj in ObjectList)
                {
                    if (DistanceSqrt(obj.transform.position, _data.WorldPos) <= clickDistThreshold)
                    {
                        Debug.Log("Object hit - " + obj.name);

                        EventManager.Trigger(Events.ObjectSelected, new
                        {
                            _data = new ObjectData
                            {
                                name = obj.name,
                                pos = obj.transform.position
                            }
                        });
                    }
                }
            }
        }

        private float DistanceSqrt(Vector3 _a, Vector3 _b)
        {
            return Mathf.Sqrt(Mathf.Pow(_a.x - _b.x, 2f) + Mathf.Pow(_a.y - _b.y, 2f));
        }
    }
}