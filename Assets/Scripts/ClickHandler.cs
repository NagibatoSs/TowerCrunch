using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.EnhancedTouch;

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
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                {
                    if (stateMachine.CurrentState == GameState.Menu)
                    {
                        stateMachine.SetGame();
                        return;
                    }
                    OnScreenClick?.Invoke();
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                if (stateMachine.CurrentState == GameState.Menu)
                {
                    stateMachine.SetGame();
                    return;
                }
                OnScreenClick?.Invoke();
            }
        }
    }

    //private bool IsPointerOverUI()
    //{
    //    if (Input.touchCount > 0)
    //        return EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId);
    //    return EventSystem.current.IsPointerOverGameObject();
    //}
}
