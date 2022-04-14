using UnityEngine;

public class Hook : MonoBehaviour
{

    public float speed = 2;

    public double CraneLevel = 14.2;
    public double FloorLevel = 0;

    public GameObject crane;


    protected void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (this.transform.position.y > FloorLevel)
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (this.transform.position.y < CraneLevel)
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
        }
    }
}
