using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BlockSpawner : MonoBehaviour
{
    //[SerializeField] Transform blocksRoot;
    [SerializeField] GameStateMachine stateMachine;
    [SerializeField] TowerManager towerManager;
    [SerializeField] Pool[] pools;
    private int poolIdx;
    private void OnEnable()
    {
        towerManager.OnBlockAdded += SpawnNewBlock;
    }
    private void OnDisable()
    {
        towerManager.OnBlockAdded -= SpawnNewBlock;
    }
    public void StartGame()
    {
        poolIdx = 0;
        Spawn();
    }

    private void SpawnNewBlock(GameObject newBlock)
    {
        Spawn();
    }

    private void Spawn()
    {
        if (poolIdx == pools.Length)
        {
            poolIdx = 0;
        }
        var block = pools[poolIdx].GetFromPool();
        block.transform.SetParent(pools[poolIdx].transform);
        block.transform.position = transform.position;
        block.transform.rotation = Quaternion.identity;
        towerManager.SetDependencies(block.GetComponent<LandingDetector>());
        poolIdx++;

    }
}
