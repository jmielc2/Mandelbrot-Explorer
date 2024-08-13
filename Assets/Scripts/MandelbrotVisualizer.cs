using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MandelbrotVisualizer : MonoBehaviour {
    Camera sceneCamera;
    Vector2 mousePoint;
    Vector2 focusPoint;
    float zoom;

    const float maxZoom = 0.996f;
    const float maxZoomSensitivity = 0.01f;
    const float maxMoveSensitivity = 0.75f;

    [SerializeField]
    Material mandelbrotMaterial;
    [SerializeField]
    Transform startCenterPoint;
    [SerializeField, Range(1f, 5f)]
    float maxWidth = 2f;
    [SerializeField, Range(0f, maxZoom)]
    float zoomAmount = 0f;
    [SerializeField, Range(0f, maxZoomSensitivity)]
    float zoomSensitivity = 0.1f;
    [SerializeField, Range(0f, maxMoveSensitivity)]
    float moveSensitivity = 0.1f;

    Vector2 GetMouseOffset() {
        Vector2 mouseOffset = new Vector2(
            Input.mousePosition.x / Screen.width,
            Input.mousePosition.y / Screen.height
        );
        float w = zoom * maxWidth;
        float h = w / sceneCamera.aspect;
        mouseOffset.x *= w;
        mouseOffset.y *= h;
        mouseOffset.x -= 0.5f * w;
        mouseOffset.y -= 0.5f * h;
        return mouseOffset;
    }

    void UpdateZoom() {
        zoom = Mathf.Pow(zoomAmount - 1f, 2);
    }

    void Start() {
        sceneCamera = GetComponent<Camera>();
        focusPoint = startCenterPoint.position;
        mousePoint = focusPoint + GetMouseOffset();
        UpdateZoom();
    }

    void Update() {
        float zoomDelta = -Input.mouseScrollDelta.y;
        if (zoomDelta != 0) {
            zoomAmount += zoomDelta * zoomSensitivity;
            zoomAmount = Mathf.Clamp(zoomAmount, 0f, maxZoom);
            UpdateZoom();

            focusPoint = mousePoint - GetMouseOffset();
            return;
        } else if (Input.GetMouseButton(0)) {
            Vector2 movement = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * -1f;
            Vector2 movementDelta = movement * moveSensitivity * zoom * maxWidth;
            focusPoint += movementDelta;
        }
        mousePoint = focusPoint + GetMouseOffset();
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination) {
        mandelbrotMaterial.SetFloat("_MaxWidth", maxWidth);
        mandelbrotMaterial.SetFloat("_Zoom", zoom);
        mandelbrotMaterial.SetFloat("_AspectRatio", sceneCamera.aspect);
        mandelbrotMaterial.SetVector("_CenterPoint", focusPoint);
        Graphics.Blit(source, destination, mandelbrotMaterial);
    }
}
