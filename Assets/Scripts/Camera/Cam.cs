using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    #region Zooming Variables
    float scroll;
    float zoom;
    float minZoom = 100f;
    float maxZoom = 300f;
    float zoomMultiplier = 10f;
    float velocity = 0f;
    float smoothTime = 0.25f;
    #endregion

    #region Panning Variables
    Vector3 startPoint;
    #endregion

    [SerializeField] new Camera camera;
    Vector3 previousPos;
    // Start is called before the first frame update
    void Start()
    {
        zoom = camera.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        Zooming();
        Panning();
        CamOrbit();
    }
    void Zooming()
    {
        scroll = Input.GetAxis("Mouse ScrollWheel");
        zoom -= scroll * zoomMultiplier;
        zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
        camera.orthographicSize = Mathf.SmoothDamp(camera.orthographicSize, zoom, ref velocity, smoothTime);
    }
    void Panning()
    {
        if(Input.GetMouseButtonDown(0))
        {
            startPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if(Input.GetMouseButton(0))
        {
            Vector3 direction = startPoint - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Camera.main.transform.position += direction;
        }
    }
    void CamOrbit()
    {
        if(Input.GetMouseButtonDown(1))
        {
            previousPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        }
        if(Input.GetMouseButton(1))
        {
            Vector3 direction = previousPos - Camera.main.ScreenToViewportPoint(Input.mousePosition);
            Camera.main.transform.position = new Vector3();
            Camera.main.transform.Rotate(new Vector3(1, 0, 0), direction.y * 180);
            Camera.main.transform.Rotate(new Vector3(0, 1, 0), -direction.x * 180, Space.World);
            Camera.main.transform.Translate(new Vector3(0, 0, -10));
            previousPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            if(Camera.main.transform.eulerAngles.x < 16)
            {
                Camera.main.transform.eulerAngles = new Vector3(16, Camera.main.transform.eulerAngles.y, Camera.main.transform.eulerAngles.z);
            }
        }
    }
}
