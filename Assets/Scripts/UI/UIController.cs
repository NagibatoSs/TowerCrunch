using Unity.VisualScripting;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject safeAreaUi;
    [SerializeField] private GameStateMachine stateMachine;
    [SerializeField] GameObject menuCanvas;
    [SerializeField] GameObject gameCanvas;
    [SerializeField] GameObject loseCanvas;
    [SerializeField] GameObject winCanvas;
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
        currentCanvas = menuCanvas;
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

            case GameState.Lose:
                OpenEndGameUI();
                break;

            case GameState.Win:
                OpenWinGameUI();
                break;
        }
    }
    private void OpenMenuUI()
    {
        SetCanvasActive(menuCanvas);
    }

    private void OpenGameUI()
    {
        SetCanvasActive(gameCanvas);
    }

    private void OpenEndGameUI()
    {
        SetCanvasActive(loseCanvas);
    }

    private void OpenWinGameUI()
    {
        SetCanvasActive(winCanvas);
    }

    private void SetCanvasActive(GameObject canvas)
    {
        canvas.SetActive(true);
        currentCanvas = canvas;
    }

    private void HideCurrentCanvas()
    {
        currentCanvas.SetActive(false);
    }
}
