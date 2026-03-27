using UnityEngine;

public class VFXManager : MonoBehaviour
{
    [SerializeField] GameStateMachine gameStateMachine;
    [SerializeField] TowerManager towerManager;
    [SerializeField] Pool winPool;
    [SerializeField] Pool crunchPool;
    [SerializeField] Pool blockAddedPool;

    private void OnEnable()
    {
        gameStateMachine.OnWin += PlayWinVFX;
        towerManager.OnBlockAdded += PlayBlockAddedVFX;
        towerManager.OnCrunch += PlayCrunchVFX;
    }

    private void OnDisable()
    {
        gameStateMachine.OnWin -= PlayWinVFX;
        towerManager.OnBlockAdded -= PlayBlockAddedVFX;
        towerManager.OnCrunch -= PlayCrunchVFX;
    }
    public void PlayWinVFX()
    {
        var vfx = winPool.GetFromPool();
        vfx.transform.localPosition = Vector3.zero;
    }

    public void PlayCrunchVFX(GameObject newBlock)
    {
        var vfx = crunchPool.GetFromPool();
        vfx.transform.position = newBlock.transform.position;
    }

    public void PlayBlockAddedVFX(GameObject newBlock)
    {
        var vfx = blockAddedPool.GetFromPool();
        vfx.transform.position = newBlock.transform.position;
    }
}
