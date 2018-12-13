using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using InputSystem;
using InteractionsSystem;


public class GameManager : MonoBehaviour
{
    [SerializeField] private InputSystem.InputManager inputManager;
    [SerializeField] private ObjectSystem.ObjectManager objectManager;
    [SerializeField] private InteractionsSystem.InteractionsManager interactionsManager;

    

    private void Awake()
    {
        inputManager = new InputSystem.InputManager();
        objectManager = new ObjectSystem.ObjectManager();
        interactionsManager = new InteractionsManager();
        
        DontDestroyOnLoad(this.gameObject);
        
    }


    private void Start()
    {
        inputManager.Start();
        objectManager.Start();
        interactionsManager.Start();
    }


    private void Update()
    {
        inputManager.Update();
        objectManager.Update(Time.deltaTime);
        interactionsManager.Update();
    }
}
