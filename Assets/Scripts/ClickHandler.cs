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
        // Обрабатываем все активные "первичные" действия Pointer (мышь или тач)
        if (Pointer.current != null && Pointer.current.press.wasPressedThisFrame)
        {
            Vector2 clickPosition = Pointer.current.position.ReadValue();

            // Проверяем, не по UI ли клик
            if (IsPointerOverUI(clickPosition))
                return;

            // Если в Menu, стартуем игру
            if (stateMachine.CurrentState == GameState.Menu)
            {
                stateMachine.SetGame();
                return;
            }

            OnScreenClick?.Invoke();
            Debug.Log("CLICK ACCEPTED");
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


