using UnityEngine;
using System.Collections;

public class CameraRotate : MonoBehaviour
{
    float speed = 0.5f;

    // Use this for initialization
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, -speed, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, speed, 0);
        }
    }
}