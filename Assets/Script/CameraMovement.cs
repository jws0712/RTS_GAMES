using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 Dir = Vector3.zero;

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Dir = new Vector3 (x, 0f ,z);
    }

    private void LateUpdate()
    {
        transform.Translate(Dir * speed * Time.deltaTime);
    }
}
