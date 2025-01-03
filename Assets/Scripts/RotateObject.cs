using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{   
    [SerializeField] private float rotateSpeed = 1.5f;
    private void Update()
    {
        transform.Rotate(0, 0, 360 * rotateSpeed * Time.deltaTime );
    }
}
