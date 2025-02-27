using UnityEngine;

public class MobileJoystick : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private RectTransform joystickOutline;

    public InputManager inputManager;

    void Start() {
        // RectTransform rectTransform = GetComponent<RectTransform>();
        // rectTransform.anchoredPosition = new Vector2(0, -Screen.height / 4f);
        inputManager = FindAnyObjectByType<InputManager>();
    }

    void Update() {
        
    }

    public void ClickedOnJoystickAreaCallback() {
        joystickOutline.position = inputManager.touchPosition;
    }
}
