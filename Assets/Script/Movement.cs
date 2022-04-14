using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private GameObject joyStick;

    [Header("Tower Crane")]
    [SerializeField]
    private Transform towerCrane_cabine;

    [SerializeField]
    private float towerCrane_speed = 0.4f;

    [Header("Point Track")]
    [SerializeField]
    private float point_track_speed = 0.4f;

    [SerializeField] 
    private float xBorderPointTrack = 3f;

    [SerializeField]
    private Transform point_truck;

    [Header("Hook")]
    [SerializeField] private Transform hook;

    [SerializeField] private float hookLowerBorder = 10f;

    private Vector3 _initialPositionHook;
    private Vector3 _initialPositionPointTrack;

    protected void Start()
    {
        _initialPositionHook = hook.position;
        _initialPositionPointTrack = point_truck.position;
    }

    protected void Update()
    {
        if (joyStick.transform.localRotation.eulerAngles.z > 0 && joyStick.transform.localRotation.eulerAngles.z < 90)
        {
            towerCrane_cabine.Rotate(Vector3.up * towerCrane_speed * Time.deltaTime);
        }

        if (joyStick.transform.localRotation.eulerAngles.z > 270 && joyStick.transform.localRotation.eulerAngles.z < 360)
        {
            towerCrane_cabine.Rotate(Vector3.down * towerCrane_speed * Time.deltaTime);
        }

        if (joyStick.transform.localRotation.eulerAngles.x > 0 && joyStick.transform.localRotation.eulerAngles.x < 90)
        {
            if (point_truck.position.x < xBorderPointTrack) return;
            point_truck.Translate(Vector3.right * point_track_speed * Time.deltaTime);
        }

        if (joyStick.transform.localRotation.eulerAngles.x > 270 && joyStick.transform.localRotation.eulerAngles.x < 360)
        {
            if (point_truck.position.x - _initialPositionPointTrack.x > float.Epsilon) return;
            point_truck.Translate(Vector3.left * point_track_speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (hook.position.y < hookLowerBorder) return;
            hook.Translate(Vector3.back * point_track_speed * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            if (hook.position.y - _initialPositionHook.y > float.Epsilon) return;
            hook.Translate(Vector3.forward * point_track_speed * Time.deltaTime);
        }
    }
}
