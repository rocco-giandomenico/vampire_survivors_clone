using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI clickPosition;
    [SerializeField] private int targetFPS = 60;

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

    private void OnTouchPerformed(InputAction.CallbackContext context)
    {
        Vector2 touchPosition = context.ReadValue<Vector2>();
        clickPosition.text = touchPosition.x.ToString() + "\n" + touchPosition.y.ToString();
    }
}
