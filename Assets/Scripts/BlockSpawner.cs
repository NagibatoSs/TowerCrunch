using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BlockSpawner : MonoBehaviour
{
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
    void Start()
    {
        towerManager.OnBlockAdded += SpawnNewBlock;
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
            var block = Instantiate(prefabs[idx], transform.position, Quaternion.identity);
            towerManager.SetDependencies(block.GetComponent<LandingDetector>());
            idx++;
        }
    }
}
