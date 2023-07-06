using UnityEngine;

public class ClampMovement : MonoBehaviour
{
    public float minX = -10f; // Valor mínimo del eje X
    public float maxX = 10f; // Valor máximo del eje X
    public float minY = 0f; // Valor mínimo del eje Y
    public float maxY = 10f; // Valor máximo del eje Y
    public float minZ = -10f; // Valor mínimo del eje Z
    public float maxZ = 10f; // Valor máximo del eje Z
    public float minFOV = 20f; // Valor mínimo del FOV
    public float maxFOV = 60f; // Valor máximo del FOV

    private Camera mainCamera;
    private float initialFOV;

    private void Start()
    {
        mainCamera = GetComponent<Camera>();
        initialFOV = mainCamera.fieldOfView;
    }

    private void Update()
    {
        float clampedX = Mathf.Clamp(transform.position.x, minX * (initialFOV / mainCamera.fieldOfView), maxX * (initialFOV / mainCamera.fieldOfView));
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        float clampedZ = Mathf.Clamp(transform.position.z, minZ * (initialFOV / mainCamera.fieldOfView), maxZ * (initialFOV / mainCamera.fieldOfView));
        transform.position = new Vector3(clampedX, clampedY, clampedZ);
    }
}
