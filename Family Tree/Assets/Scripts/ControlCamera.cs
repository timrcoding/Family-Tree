
using UnityEngine;

public class ControlCamera : MonoBehaviour
{
    public Camera cam;
    public float dragSpeed = 2;
    private Vector3 dragOrigin;

    void ZoomOrthoCamera(Vector3 zoomTowards, float amount)
    {
        // Calculate how much we will have to move towards the zoomTowards position
        float multiplier = (1.0f / cam.orthographicSize * amount);

        // Move camera
        cam.transform.position += (zoomTowards - transform.position) * multiplier;

        // Zoom camera
        cam.orthographicSize -= amount;

        // Limit zoom
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, 2, 5);
    }

    private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            ZoomOrthoCamera(Camera.main.ScreenToWorldPoint(Input.mousePosition), 1);
        }

        // Scroll back
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            ZoomOrthoCamera(Camera.main.ScreenToWorldPoint(Input.mousePosition), -1);
        }
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(0)) return;

        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        Vector3 move = new Vector3(pos.x * dragSpeed, 0, pos.y * dragSpeed);

        transform.Translate(move, Space.World);
    }
}

