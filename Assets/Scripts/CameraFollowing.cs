using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    public Tower tower;  
    public float smoothTime = 0.3f;
    [SerializeField] float cameraOffset = 0f;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] float spawnOffset = 4f;

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (tower == null) return;
        if (tower.Count == 0) return;

        GameObject topBlock = tower.Peek;

        Vector3 targetPosition = new Vector3(transform.position.x, topBlock.transform.position.y+cameraOffset, transform.position.z);
        Vector3 targetPositionSpawn = new Vector3(spawnPoint.transform.position.x, topBlock.transform.position.y + spawnOffset, spawnPoint.transform.position.z);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        spawnPoint.transform.position = targetPositionSpawn;
    }
}
