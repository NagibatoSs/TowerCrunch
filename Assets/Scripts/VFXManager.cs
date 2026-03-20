using UnityEngine;

public class VFXManager : MonoBehaviour
{
    [SerializeField] GameStateMachine gameStateMachine;
    [SerializeField] VFXPool winPool;

    private void OnEnable()
    {
        gameStateMachine.OnWin += PlayWinVFX;
    }

    private void OnDisable()
    {
        gameStateMachine.OnWin -= PlayWinVFX;
    }
    public void PlayWinVFX()
    {
        var vfx = winPool.GetFromPool();
        vfx.transform.position = Vector3.zero;
    }

}
