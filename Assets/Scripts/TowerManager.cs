using System;
using System.Collections;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    //[SerializeField] LandingDetector detector;
    [SerializeField] Tower tower;
    [SerializeField] GameObject towerRoot;
    public GameObject TowerRoot => towerRoot;
    public event Action OnCrunch;
    public event Action OnBlockAdded;
    private LandingDetector currentDetector;

    private void OnDisable()
    {
        //if (detector != null)
        //    detector.OnLanded -= PushNewBlockToTower;
    }
    public void SetDependencies(LandingDetector detector)
    {
        //this.detector = detector;
        //detector.OnLanded += HandleBlockLanded;
        // Отписываемся от старого detector
        if (currentDetector != null)
        {
            currentDetector.OnLanded -= HandleBlockLanded;
        }

        // Сохраняем новый
        currentDetector = detector;

        // Подписываемся
        currentDetector.OnLanded += HandleBlockLanded;

    }
    private void HandleBlockLanded(GameObject block)
    {

        StartCoroutine(PushWithCrushSequence(block));
    }


    private void Start()
    {
        tower.Push(towerRoot);
    }

    //private void PushNewBlockToTower(GameObject newBlock)
    //{
    //    while (tower.Count > 0)
    //    {
    //        GameObject peek = tower.Peek;
    //        if (newBlock.transform.localScale.x > peek.transform.localScale.x)
    //            CrunchPeekBlock(peek);
    //        else break;
    //    }
    //    if (tower.Count == 0)
    //    {
    //        towerRoot = newBlock;
    //    }
    //    OnBlockAdded?.Invoke();
    //    tower.Push(newBlock);
    //}

    //private void CrunchPeekBlock(GameObject peek)
    //{
    //    OnCrunch?.Invoke();
    //    Destroy(peek);
    //    tower.Pop();
    //}

    private void PushNewBlockToTower(GameObject newBlock)
    {
        //detector.OnLanded -= PushNewBlockToTower;
        StartCoroutine(PushWithCrushSequence(newBlock));
    }

    private IEnumerator PushWithCrushSequence(GameObject newBlock)
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
            //var anim = newBlock.GetComponent<BlockAnimateColor>();
            //if (anim != null)
            //anim.Animate();
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
