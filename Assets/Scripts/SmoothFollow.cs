using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    private Transform target;
    private float distance = 10.0f;
    private float height = 5.0;
    private float rotationDamping;
    private float heightDamping;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!target)
        {
            return;
        }
    }
}
