using UnityEngine;

public class CameraFOVInitializer : MonoBehaviour
{
    [SerializeField] Transform fieldCenter;
    [SerializeField] float planeY = 8f;
    [SerializeField] float planeZ = 8f;

    void Start()
    {
        Camera cam = GetComponent<Camera>();

        float aspect = (float)Screen.width / Screen.height;

        float distance = Vector3.Distance(transform.position, fieldCenter.position);

        float fovY = 2f * Mathf.Atan((planeY / 2f) / distance) * Mathf.Rad2Deg;

        float fovZ = 2f * Mathf.Atan((planeZ / 2f) / distance) * Mathf.Rad2Deg;
        float fovZVertical = 2f * Mathf.Atan(Mathf.Tan(fovZ * Mathf.Deg2Rad / 2f) / aspect) * Mathf.Rad2Deg;

        cam.fieldOfView = Mathf.Max(fovY, fovZVertical);
    }
}
