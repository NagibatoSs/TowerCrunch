using System.Collections;
using TMPro;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    [SerializeField] GameObject spawnPoint;
    [SerializeField] TowerManager towerManager;
    [SerializeField] float cameraOffset = 0f;
    [SerializeField] float spawnOffset = 4f;
    [SerializeField] float smoothTime = 0.3f;

    private void OnEnable()
    {
        if (towerManager != null)
            towerManager.OnBlockAdded += UpdatePosition;
    }

    private void OnDisable()
    {
        if (towerManager != null)
            towerManager.OnBlockAdded -= UpdatePosition;
    }

    public void ResetPosition(Vector3 cameraPos, Vector3 spawnPos)
    {
        transform.position = cameraPos;
        spawnPoint.transform.position = spawnPos;
    }

    private void UpdatePosition(GameObject newBlock)
    {
        StartCoroutine(UpdateCameraPositionSmoothly(newBlock));
    }
    private IEnumerator UpdateCameraPositionSmoothly(GameObject block)
    {
        float duration = 0.3f;
        float elapsed = 0f;

        Vector3 startCam = transform.position;
        Vector3 targetCam = new Vector3(transform.position.x, block.transform.position.y + cameraOffset, transform.position.z);

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(startCam, targetCam, elapsed / duration);
            yield return null;
        }

        transform.position = targetCam;
    }

}
