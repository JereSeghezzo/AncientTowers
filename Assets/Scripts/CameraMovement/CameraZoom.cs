using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float minZoomFOV = 20f; // Valor mínimo del FOV para el zoom
    public float maxZoomFOV = 60f; // Valor máximo del FOV para el zoom
    public float zoomSpeed = 1f; // Velocidad de zoom

    private Vector2 initialFingerPosition1; // Posición inicial del primer dedo
    private Vector2 initialFingerPosition2; // Posición inicial del segundo dedo
    private float initialDistance; // Distancia inicial entre los dedos
    private float initialFOV; // FOV inicial de la cámara

    private void Start()
    {
        initialFOV = Camera.main.fieldOfView;
    }

    private void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            if (touch2.phase == TouchPhase.Began)
            {
                initialFingerPosition1 = touch1.position;
                initialFingerPosition2 = touch2.position;
                initialDistance = Vector2.Distance(initialFingerPosition1, initialFingerPosition2);
            }
            else if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
            {
                Vector2 currentFingerPosition1 = touch1.position;
                Vector2 currentFingerPosition2 = touch2.position;
                float currentDistance = Vector2.Distance(currentFingerPosition1, currentFingerPosition2);

                float zoomAmount = (currentDistance - initialDistance) * zoomSpeed;

                Vector2 midPoint = (currentFingerPosition1 + currentFingerPosition2) / 2f;
                Vector3 zoomCenter = Camera.main.ScreenToWorldPoint(new Vector3(midPoint.x, midPoint.y, Camera.main.nearClipPlane));

                float newFOV = Mathf.Clamp(Camera.main.fieldOfView - zoomAmount, minZoomFOV, maxZoomFOV);

                Camera.main.fieldOfView = newFOV;
                transform.position += (zoomCenter - transform.position) * zoomAmount;
            }
        }
    }
}
