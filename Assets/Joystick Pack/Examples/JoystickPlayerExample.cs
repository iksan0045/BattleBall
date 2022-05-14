using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public VariableJoystick variableJoystick;
    public Rigidbody rb;

    public void FixedUpdate()
    {
        Vector3 movement = new Vector3(variableJoystick.Horizontal,0,variableJoystick.Vertical) * speed * Time.deltaTime;
        transform.Translate(movement, Space.Self);
    }
}