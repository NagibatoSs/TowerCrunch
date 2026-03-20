using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] GameStateMachine stateMachine;
    [SerializeField] Tower tower;
    public static ClickHandler Instance { get; private set; }
    public event Action OnScreenClick;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (Pointer.current != null && Pointer.current.press.wasPressedThisFrame)
        {
            Vector2 clickPosition = Pointer.current.position.ReadValue();

            if (IsPointerOverUI(clickPosition))
                return;

            if (stateMachine.CurrentState == GameState.Menu)
            {
                stateMachine.SetGame();
                return;
            }

            OnScreenClick?.Invoke();
        }
    }
    private bool IsPointerOverUI(Vector2 screenPosition)
    {
        if (EventSystem.current == null)
            return false;

        PointerEventData eventData = new PointerEventData(EventSystem.current)
        {
            position = screenPosition
        };

        var results = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        foreach (var r in results)
        {
            if (r.gameObject.layer == LayerMask.NameToLayer("UI"))
                return true;
        }

        return false;
    }
}


