using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private InputActionReference backAction;

    // -------------------------------------------------------------------------
    // FUNCTIONS

    void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable() {
        backAction.action.Enable();
        backAction.action.performed += OnBackPressed;
    }

    private void OnDisable() {
        backAction.action.Disable();
        backAction.action.performed -= OnBackPressed;
    }

    // -------------------------------------------------------------------------
    // PRIVATE

    private void OnBackPressed(InputAction.CallbackContext context) {
        QuitApplication();
    }

    private void QuitApplication() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
