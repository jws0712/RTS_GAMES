using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float nomalSpeed;
    [SerializeField] private float shiftSpeed;

    private float speed = default;
    private Vector3 Dir = Vector3.zero;

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Dir = new Vector3 (x, 0f ,z);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = shiftSpeed;
        }
        else
        {
            speed = nomalSpeed;
        }
            

        transform.Translate(Dir * speed * Time.deltaTime);
    }
}
