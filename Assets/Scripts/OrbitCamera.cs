using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ControlCamara : MonoBehaviour
{



    [Tooltip("Speed multiplier for horizontal & vertical rotation.")]
    public Vector2 turnSpeed = new Vector2(1, 1);

    [Tooltip("Maximum rotation from the initial orientation.")]
    public Vector2 degreeClamp = new Vector2(90, 80);

    [Tooltip("Check this box if you want forward input to look downward.")]
    public bool invertY;

    // Orientation state.
    Quaternion _initialOrientation;
    Vector2 _currentAngles;

    // Cached cursor state.
    CursorLockMode _previousLockState;
    bool _wasCursorVisible;

    void OnEnable()
    {
        // Cache our starting orientation as our center point.
        _initialOrientation = transform.localRotation;

        // Cache the previous cursor state so we can restore it later.
        _previousLockState = Cursor.lockState;
        _wasCursorVisible = Cursor.visible;

        // Hide & lock the cursor for that FPS experience
        // and to avoid distractions / accidental clicks
        // from the mouse cursor moving around.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Collect relative motion of mouse since last frame.
        Vector2 motion = new Vector2(
                            Input.GetAxis("Mouse X"),
                            Input.GetAxis("Mouse Y"));

        // Scale it by the turn speed, add it to our current angle, and clamp.
        motion = Vector2.Scale(motion, turnSpeed);
        _currentAngles += motion;
        _currentAngles = Vector2.Min(_currentAngles, degreeClamp);
        _currentAngles = Vector2.Max(_currentAngles, -degreeClamp);

        // Rotate to look in this direction, relative to our initial orientation.
        Quaternion look = Quaternion.Euler(
                            -_currentAngles.y,                       // Yaw
                            (invertY ? -1f : 1f) * _currentAngles.x, // Pitch
                            0);                                      // Roll

        transform.localRotation = _initialOrientation * look;
    }

    void OnDisable()
    {
        // When switched off, put everything back the way we found it.
        //Cursor.visible = _wasCursorVisible;
        Cursor.lockState = _previousLockState;
        transform.localRotation = _initialOrientation;
    }
}   

    

