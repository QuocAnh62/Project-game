using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_LookRotation : MonoBehaviour
{
    [SerializeField] protected FixedJoystick joystick;
    public float turnSmooth = 0.01f;
    float turnSmoothVelocity;

    protected void LookRotation()
    {
        Vector3 dir = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
        if (dir.magnitude >= 0.01f)
        {
            float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
            float angle =
                Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmooth);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
    }
}
