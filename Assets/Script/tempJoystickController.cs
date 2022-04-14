using UnityEngine;

public class tempJoystickController : MonoBehaviour
{
    public GameObject controller;

    public Rigidbody pivot;

    protected void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (pivot.rotation.eulerAngles.y < 90)
            {
                this.transform.Rotate(0.10f, 0.0f, 0.0f, Space.Self);
            }
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            this.transform.eulerAngles = new Vector3(
                this.transform.eulerAngles.x * 0,
                this.transform.eulerAngles.y * 0,
                this.transform.eulerAngles.z * 0
                );
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (pivot.rotation.eulerAngles.z < 90)
            {
                this.transform.Rotate(-0.10f, 0.0f, 0.0f, Space.Self);
            }
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            this.transform.eulerAngles = new Vector3(
               this.transform.eulerAngles.x * 0,
               this.transform.eulerAngles.y * 0,
               this.transform.eulerAngles.z * 0
               );
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if ((pivot.rotation.eulerAngles.z > 270) || (pivot.rotation.eulerAngles.z == 0))
            {
                this.transform.Rotate(0.0f, 0.0f, -0.10f, Space.Self);
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            this.transform.eulerAngles = new Vector3(
               this.transform.eulerAngles.x * 0,
               this.transform.eulerAngles.y * 0,
               this.transform.eulerAngles.z * 0
               );
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if ((pivot.rotation.eulerAngles.z < 90) || (pivot.rotation.eulerAngles.z == 0))
            {
                this.transform.Rotate(0.0f, 0.0f, 0.10f, Space.Self);
            }
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            this.transform.eulerAngles = new Vector3(
               this.transform.eulerAngles.x * 0,
               this.transform.eulerAngles.y * 0,
               this.transform.eulerAngles.z * 0
               );
        }
    }
}