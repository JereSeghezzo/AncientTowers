using UnityEngine;

public class MobileZoom : MonoBehaviour
{
    public float zoomSpeed = 0.0000001f;   // Velocidad de zoom

    void Update()
    {
        if (Input.touchCount == 2)
        {
            // Obtener los dos toques
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Obtener las posiciones anteriores de los dos toques
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Calcular la magnitud de los vectores de los toques anteriores y actuales
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Calcular la diferencia de magnitud
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            // Calcular el factor de zoom basado en la diferencia de magnitud
            float zoomFactor = 1f - deltaMagnitudeDiff * zoomSpeed;

            // Aplicar el zoom en la posición de la cámara
            Camera.main.fieldOfView *= zoomFactor;

            // Limitar el campo de visión para evitar zoom excesivo
            Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 10f, 60f);
        }
    }
}
