using UnityEngine;

public class ControlCamara : MonoBehaviour
{
    public Transform cameraBody;
    public float sensibilidad = 180;
    public float rotX;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidad * Time.deltaTime -20;
    }
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilidad ;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidad *Time.deltaTime;
        
        rotX = Mathf.Clamp(rotX, -90, 90);

        
        cameraBody.Rotate(Vector3.up * mouseX);
        cameraBody.Rotate(Vector3.right * (mouseY)*-1 );

    }   

    
}
