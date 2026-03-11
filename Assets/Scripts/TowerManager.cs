using System;
using System.Collections;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    [SerializeField] Transform blocksRoot;
    public GameObject TowerRoot => towerRoot;
    private GameObject towerRoot;

    private Tower tower = new Tower();
    private LandingDetector currentDetector;

    public event Action OnCrunch;
    public event Action OnBlockAdded;

    public void ResetTower()
    {
        tower.ClearAndDestroy();

        foreach (Transform child in blocksRoot)
        {
            Destroy(child.gameObject);
        }

        towerRoot = null;
    }

    public void SetDependencies(LandingDetector detector)
    {
        if (currentDetector != null)
        {
            currentDetector.OnLanded -= HandleBlockLanded;
        }

        currentDetector = detector;
        currentDetector.OnLanded += HandleBlockLanded;

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
            currentDetector.enabled = false;
            currentDetector = null;
        }

        var anim = newBlock.GetComponent<BlockAnimateColor>();
        if (anim != null)
            anim.Animate();

        OnBlockAdded?.Invoke();
        tower.Push(newBlock);
    }

    private IEnumerator CrunchPeekBlock(GameObject peek)
    {
        OnCrunch?.Invoke();       
        tower.Pop();


        yield return new WaitForSeconds(0.015f); 
        Destroy(peek);
    }
}
