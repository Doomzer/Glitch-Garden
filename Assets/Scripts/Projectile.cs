using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] bool needRotate = false;
    [SerializeField] float rotateSpeed = 180f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime, Space.World);
        if(needRotate)
            transform.Rotate(0, 0, -rotateSpeed * Time.deltaTime);
    }
}
