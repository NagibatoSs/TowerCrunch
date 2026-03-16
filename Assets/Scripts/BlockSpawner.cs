using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] Transform blocksRoot;
    [SerializeField] GameObject[] prefabs;
    [SerializeField] GameStateMachine stateMachine;
    [SerializeField] float spawnDelayInSeconds = 1;
    [SerializeField] TowerManager towerManager;
    private int lastSpawnFrame = -1;
    private int idx;

    private void OnDisable()
    {
        towerManager.OnBlockAdded -= SpawnNewBlock;
    }

    private void OnEnable()
    {
        towerManager.OnBlockAdded += SpawnNewBlock;
    }

    public void StartGame()
    {
        idx = 0;
        Spawn();
    }


    private void SpawnNewBlock()
    {
        if (lastSpawnFrame == Time.frameCount)
            return;
        lastSpawnFrame = Time.frameCount;
        Spawn();
    }


    private void Spawn()
    {
        if (idx == prefabs.Length)
        {
            idx = 0;
        }
        if (prefabs[idx] != null)
        {
            var block = Instantiate(prefabs[idx], transform.position, Quaternion.identity, blocksRoot);
            towerManager.SetDependencies(block.GetComponent<LandingDetector>());
            idx++;
        }
    }
}
