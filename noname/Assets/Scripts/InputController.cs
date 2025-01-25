using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{




    [Header("Context")]
    public Vector2 moveDirection { get; private set; }
    public bool isRunning { get; private set; }

    //Chestii Private
    private InputSystem_Actions input;

    private void Awake()
    {
        input = new InputSystem_Actions();
    }



    private void OnEnable()
    {
        input.Enable();
        input.Player.Move.performed += moveDirectionPerfomed;
        input.Player.Move.canceled += moveDirectionCanceled;
        input.Player.Sprint.performed += isRunningPerfomed;
        input.Player.Sprint.canceled += isRunningCanceled;

    }


    private void OnDisable()
    {

        input.Player.Move.performed -= moveDirectionPerfomed;
        input.Player.Move.canceled -= moveDirectionCanceled;
        input.Player.Sprint.performed -= isRunningPerfomed;
        input.Player.Sprint.canceled -= isRunningCanceled;
        input.Disable();
    }


    
    private void moveDirectionPerfomed(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue <Vector2>();
    }
    private void moveDirectionCanceled(InputAction.CallbackContext context)
    {
        moveDirection = Vector2.zero;
    }


    private void isRunningPerfomed(InputAction.CallbackContext context)
    {
        isRunning = true;
    }

    private void isRunningCanceled(InputAction.CallbackContext context)
    {
        isRunning = false;
    }

}
