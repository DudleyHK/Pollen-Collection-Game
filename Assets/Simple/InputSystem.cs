using EventSystem;
using UnityEngine;


namespace InputSystem
{
    public enum TouchType
    {
        None,
        Begun,
        Release
    }

    public struct InputData
    {
        public Vector3 WorldPos;
        public Vector2 PixelPos;
        public TouchType TouchType;
    }

    [System.Serializable]
    public class InputManager
    {

        public void Start()
        {
        }


        public void Update()
        {
            var buttonDown = Input.GetMouseButtonDown(0);
            var buttonUp = Input.GetMouseButtonUp(0);
            var tmp = TouchType.None;


            if (buttonDown) tmp = TouchType.Begun;
            if (buttonUp) tmp = TouchType.Release;


            if (buttonDown || buttonUp)
            {
                EventManager.Trigger(Events.Input, new
                {
                    _data = new InputData
                    {
                        PixelPos = Input.mousePosition,
                        WorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition),
                        TouchType = tmp
                    }
                });
            }
        }
    }
}