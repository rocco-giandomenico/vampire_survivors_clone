using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private int targetFPS = 60;

    public Vector2 touchPosition;

    private PlayerInputActions playerInputActions;

    // -------------------------------------------------------------------------
    // FUNCTIONS

    void Awake() {
        DontDestroyOnLoad(gameObject);
        playerInputActions = new PlayerInputActions();
    }

    private void Start() {
        Application.targetFrameRate = targetFPS;
    }

    private void OnEnable() {
        playerInputActions.Enable();

        playerInputActions.UI.BackButton.performed += OnBackPressed;
        playerInputActions.UI.Touch.performed += OnTouchPerformed;
    }

    private void OnDisable() {
        playerInputActions.Disable();

        playerInputActions.UI.BackButton.performed -= OnBackPressed;
        playerInputActions.UI.Touch.performed -= OnTouchPerformed;
    }

    // -------------------------------------------------------------------------
    // PUBLIC

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

    private void OnTouchPerformed(InputAction.CallbackContext context) {
        touchPosition = context.ReadValue<Vector2>();
    }
}
