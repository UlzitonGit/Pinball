using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class GatesInputHandler 
{
    private Gameplay gameplay;
    public float inputZ { get; private set; }
    public float inputX { get; private set; }
    
    public float inputSpace { get; private set; }
    public void Enable()
    {
        gameplay = new Gameplay();
        gameplay.gates.StretchingZ.Enable();
        gameplay.gates.StretchingZ.performed += OnPressedZ;
        gameplay.gates.StretchingZ.canceled += OnCanceledZ; 
        
        gameplay.gates.StretchingX.Enable();
        gameplay.gates.StretchingX.performed += OnPressedX;
        gameplay.gates.StretchingX.canceled += OnCanceledX;
        
        gameplay.gates.StretchingSpace.Enable();
        gameplay.gates.StretchingSpace.performed += OnPressedSpace;
        gameplay.gates.StretchingSpace.canceled += OnPressedSpace;

    }
    
   
    public void Disable()
    {
        gameplay.gates.StretchingZ.performed -= OnPressedZ;
        gameplay.gates.StretchingZ.canceled -= OnCanceledZ;
        gameplay.gates.StretchingZ.Disable();
        
        gameplay.gates.StretchingX.performed -= OnPressedX;
        gameplay.gates.StretchingX.canceled -= OnCanceledX;
        gameplay.gates.StretchingX.Disable();
        
        gameplay.gates.StretchingSpace.performed -= OnPressedSpace;
        gameplay.gates.StretchingSpace.canceled -= OnPressedSpace;
        gameplay.gates.StretchingSpace.Disable();
    }
    
    private void OnPressedZ(InputAction.CallbackContext context)
    {
        inputZ = context.ReadValue<float>();
    }
    
    private void OnPressedX(InputAction.CallbackContext context)
    {
        inputX = context.ReadValue<float>();
    }
    private void OnCanceledZ(InputAction.CallbackContext context)
    {
        inputZ = 0;
    }
    private void OnCanceledX(InputAction.CallbackContext context)
    {
        inputX = 0;
    }
    private void OnPressedSpace(InputAction.CallbackContext context)
    {
        inputSpace = context.ReadValue<float>();
    }
    private void OnCanceledSpace(InputAction.CallbackContext context)
    {
        inputSpace = 0;
    }
}
