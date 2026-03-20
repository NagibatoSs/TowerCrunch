using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    public TowerManager towerManager;  
    public float smoothTime = 0.3f;
    [SerializeField] float cameraOffset = 0f;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] float spawnOffset = 4f;

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (towerManager == null) return;
        if (towerManager.BlocksCount == 0) return;

        GameObject topBlock = towerManager.TowerPeek;

        Vector3 targetPosition = new Vector3(transform.position.x, topBlock.transform.position.y+cameraOffset, transform.position.z);
        Vector3 targetPositionSpawn = new Vector3(spawnPoint.transform.position.x, topBlock.transform.position.y + spawnOffset, spawnPoint.transform.position.z);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        spawnPoint.transform.position = targetPositionSpawn;
    }
}
