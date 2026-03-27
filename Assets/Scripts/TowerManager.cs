using System;
using System.Collections;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    [SerializeField] Transform blocksRoot;
    public GameObject TowerRoot => towerRoot;
    private GameObject towerRoot;

    private Tower tower = new Tower();
    public GameObject TowerPeek => tower.Peek;
    public int BlocksCount => tower.Count;

    private LandingDetector currentDetector;

    public event Action<GameObject> OnCrunch;
    public event Action<GameObject> OnBlockAdded;

    public void SetDependencies(LandingDetector detector)
    {
        if (currentDetector != null)
        {
            currentDetector.OnLanded -= HandleBlockLanded;
        }
        currentDetector = detector;
        currentDetector.OnLanded += HandleBlockLanded;
    }
    public void ResetTower()
    {
        tower.ClearAndDestroy();

        foreach (var poolItem in blocksRoot.GetComponentsInChildren<PoolItem>(true))
        {
            if (poolItem.gameObject.activeSelf)
                poolItem.ReturnToPool();
        }

        towerRoot = null;
    }
    private void HandleBlockLanded(GameObject block)
    {
        StartCoroutine(PushWithCrunchSequence(block));
    }

    private IEnumerator PushWithCrunchSequence(GameObject newBlock)
    {
        while (tower.Count > 0)
        {
            GameObject peek = tower.Peek;
            if (newBlock.transform.localScale.x > peek.transform.localScale.x)
            {
                yield return CrunchPeekBlock(peek);
            }
            else break;
        }
        if (tower.Count == 0)
        {
            towerRoot = newBlock;
        }
        
        if (currentDetector != null)
        {
            currentDetector.OnLanded -= HandleBlockLanded;
            currentDetector = null;
        }
        tower.Push(newBlock);
        OnBlockAdded?.Invoke(newBlock);
    }

    private IEnumerator CrunchPeekBlock(GameObject peek)
    {
        OnCrunch?.Invoke(peek);
        tower.Pop();

        yield return new WaitForSeconds(0.015f);
        peek.GetComponent<PoolItem>().ReturnToPool();
    }
}
