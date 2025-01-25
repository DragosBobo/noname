using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Vector3 GetCameraForward()
    {
        var forwardDir = transform.forward;
        forwardDir.y = 0;
        forwardDir.Normalize();
        return forwardDir;
    }

    public Vector3 GetCameraRight()
    {
        var rightDir = transform.right;
        rightDir.y = 0;
        rightDir.Normalize();
        return rightDir;
    }
}
