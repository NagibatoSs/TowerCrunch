using Unity.VisualScripting;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject safeAreaUi;
    [SerializeField] private GameStateMachine stateMachine;
    private GameObject currentCanvas;

    private void OnEnable()
    {
        stateMachine.OnStateChanged += OpenGameStateUI;
    }
    private void OnDisable()
    {
        stateMachine.OnStateChanged -= OpenGameStateUI;
    }

    private void Start()
    {
        currentCanvas = safeAreaUi.transform.Find("MenuCanvas").gameObject;
    }

    private void OpenGameStateUI(GameState state)
    {
        if (currentCanvas != null)
            HideCurrentCanvas();
        switch (state)
        {
            case GameState.Menu:
                OpenMenuUI();
                break;

            case GameState.Game:
                OpenGameUI();
                break;

            case GameState.EndGame:
                OpenEndGameUI();
                break;

            case GameState.Pause:
                OpenPauseGameUI();
                break;
        }
    }
    private void OpenMenuUI()
    {
        SetCanvasActive("MenuCanvas");
    }

    private void OpenGameUI()
    {
        SetCanvasActive("GameCanvas");
    }

    private void OpenEndGameUI()
    {
        SetCanvasActive("EndGameCanvas");
    }

    private void OpenPauseGameUI()
    {
        SetCanvasActive("PauseCanvas");
    }

    private void SetCanvasActive(string canvasName)
    {
        var canvas = safeAreaUi.transform.Find(canvasName).gameObject;
        canvas.SetActive(true);
        currentCanvas = canvas;
    }

    private void HideCurrentCanvas()
    {
        currentCanvas.SetActive(false);
    }

    private void SetAllCanvasesNonActiveBesides(string activeCanvasName)
    { 
        for (int i = 0; i < safeAreaUi.transform.childCount; i++)
        {
            var canvas = safeAreaUi.transform.GetChild(i).gameObject;
            if (activeCanvasName != canvas.name)
                canvas.SetActive(false);
        }   
    }
}
