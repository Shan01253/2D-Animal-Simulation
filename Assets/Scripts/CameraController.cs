using UnityEngine;

public class CameraController : MonoBehaviour {

    public float panSpeed = 20f;
    public float panBoarderThickness = 10f;
    public float zoomSpeed;
    public float zoomSize;
    public int maxZoom;
    public int minZoom;

    private Camera mycamera;

    public BoxCollider2D panZone;
    GameObject panArea;
    public Vector2 minPanPoint;
    public Vector2 maxPanPoint;

    private void Start()
    {
        mycamera = GetComponent<Camera>();

        panArea = GameObject.FindWithTag("PanArea");
        panZone = panArea.GetComponent<BoxCollider2D>();

        if(panZone != null)
        {
            minPanPoint = panZone.bounds.min;
            maxPanPoint = panZone.bounds.max;
        }
    }

    // Update is called once per frame
    void Update () {
        Vector3 pos = transform.position;

        if (Input.mousePosition.y >= Screen.height - panBoarderThickness)//up
        {
            if(transform.position.y < maxPanPoint.y)
                pos.y += panSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.y <= panBoarderThickness)//down
        {
            if (transform.position.y > minPanPoint.y)
                pos.y -= panSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.x >= Screen.width - panBoarderThickness)//right
        {
            if (transform.position.x < maxPanPoint.x)
                pos.x += panSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.x <= panBoarderThickness)//left
        {
            if (transform.position.x > minPanPoint.x)
                pos.x -= panSpeed * Time.deltaTime;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (zoomSize < maxZoom)
                zoomSize += zoomSpeed * Time.deltaTime;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if(zoomSize > minZoom)
                zoomSize -= zoomSpeed * Time.deltaTime;
        }
        mycamera.orthographicSize = zoomSize;
        transform.position = pos;
	}
}
