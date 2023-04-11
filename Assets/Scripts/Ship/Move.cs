using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject obj;
    [SerializeField] private float maxMinRotationAngle;
    [SerializeField] private Joystick joystick;


    private void Update()
    {
        MoveShip();
    }

    private void LateUpdate()
    {
        float planeAngle = LimitAngle(obj.transform.eulerAngles.z);
        float planeNewAngle = Mathf.Clamp(Mathf.LerpAngle(Camera.main.transform.rotation.z, planeAngle, 0.25f), -10, 10);

        Camera.main.transform.rotation = Quaternion.Inverse(Quaternion.Euler(obj.transform.rotation.eulerAngles.x,
                                                                             obj.transform.rotation.eulerAngles.y,
                                                                             planeNewAngle));
    }

    private void MoveShip()
    {
        Vector2 moveTo = joystick.Direction;

        if (moveTo.x < 0)
        {
            RortateShip(maxMinRotationAngle, Time.deltaTime * 2);
        }
        else if (moveTo.x > 0)
        {
            RortateShip(-maxMinRotationAngle, Time.deltaTime * 2);
        }
        else
        {
            RortateShip(0, Time.deltaTime * 4);
        }

        ShipMoving(moveTo);
    }

    private float LimitAngle(float angle)
    {
        return (angle > 180) ? angle - 360 : angle;
    }

    private void ShipMoving(Vector3 moveTo)
    {
        obj.transform.position += moveTo * speed * Time.deltaTime;
    }

    private void RortateShip(float angle, float speed)
    {
        float currentAngle = LimitAngle(obj.transform.rotation.eulerAngles.z);
       

        transform.rotation = Quaternion.Euler(obj.transform.rotation.eulerAngles.x,
                                              obj.transform.rotation.eulerAngles.y,
                                              Mathf.Clamp(Mathf.LerpAngle(currentAngle, angle, speed),
                                              -maxMinRotationAngle,
                                              maxMinRotationAngle));
    }
}
