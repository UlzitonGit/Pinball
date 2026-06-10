using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneController 
{
    Gameplay gameplay;

    public SceneController()
    {
        gameplay = new Gameplay();
        gameplay.gates.Restart.Enable();
        gameplay.gates.Restart.performed += OnPressedRestart;
    }

    private void OnPressedRestart(InputAction.CallbackContext context)
    {
        Disable();
        SceneManager.LoadScene(0);
    }

    public void RestartGame()
    {
        Disable();
        SceneManager.LoadScene(0);
    }

    public void Disable()
    {
        gameplay.gates.Restart.Disable();
        gameplay.gates.Restart.performed -= OnPressedRestart;
    }
}
