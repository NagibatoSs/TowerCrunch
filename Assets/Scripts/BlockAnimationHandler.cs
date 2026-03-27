using UnityEngine;

public class BlockAnimationHandler : MonoBehaviour
{
    [SerializeField] TowerManager towerManager;

    private void OnEnable()
    {
        towerManager.OnBlockAdded += SetAnimationEvent;
    }
    private void OnDisable()
    {
        towerManager.OnBlockAdded -= SetAnimationEvent;
    }

    private void SetAnimationEvent(GameObject newBlock)
    {
        newBlock.GetComponent<BlockAnimateColor>()?.Animate();
    }
}
