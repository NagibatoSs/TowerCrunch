using System.Collections.Generic;
using UnityEngine;

public class Tower
{
    Stack<GameObject> tower = new Stack<GameObject>();

    public int Count => tower.Count;
    public GameObject Peek => tower.Peek();

    public void ClearAndDestroy()
    {
        while (tower.Count > 0)
        {
            var block = tower.Pop();
            Object.Destroy(block);
        }
    }

    public void Push(GameObject block)
    {
        tower.Push(block);
    }
    public void Pop()
    {
        tower.Pop();
    }

    
}
