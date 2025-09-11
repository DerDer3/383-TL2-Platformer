using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    public float parallaxSpeed;
    
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    
    void Start()
    {
        // Find the Main Camera in the scene
        cameraTransform = Camera.main.transform;
        // Remember its starting position
        lastCameraPosition = cameraTransform.position;
    }
    
    void LateUpdate()
    {
        // 1. Calculate how much the camera has MOVED since the last frame
        Vector3 cameraMovement = cameraTransform.position - lastCameraPosition;
        
        // 2. IGNORE the Y movement! Only use the X movement.
        // This creates the vector: (cameraMovement.x, 0, 0)
        Vector3 horizontalMovement = new Vector3(cameraMovement.x, 0, 0);
        
        // 3. Move this object only based on the horizontal movement
        transform.position += new Vector3(horizontalMovement.x * parallaxSpeed, 0, 0);
        
        // 4. Remember the camera's new position for the next frame
        lastCameraPosition = cameraTransform.position;
    }
}