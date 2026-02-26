using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    Stack<GameObject> tower = new Stack<GameObject>();

    public int Count => tower.Count;
    public GameObject Peek => tower.Peek();

    public void Push(GameObject block)
    {
        tower.Push(block);
    }
    public void Pop()
    {
        tower.Pop();
    }

    
}
