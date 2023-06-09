using UnityEngine;


// +=========================================+
// |                                         |
// | This script returns the stars according |
// |         to the user's devices           |
// |                                         |
// +=========================================+

public class ParalaxForStar : MonoBehaviour
{
    private Vector3 smoothedAcceleration;
    private float smoothFactor = 0.1f;


    private void Update()
    {
        Vector3 rawAcceleration = Input.acceleration;


        smoothedAcceleration = Vector3.Lerp(smoothedAcceleration, rawAcceleration, smoothFactor);


        float horizontalRotation = Mathf.Atan2(smoothedAcceleration.x, smoothedAcceleration.z) * Mathf.Rad2Deg;

        float verticalRotation = Mathf.Atan2(smoothedAcceleration.y, smoothedAcceleration.z) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0f);
    }

}