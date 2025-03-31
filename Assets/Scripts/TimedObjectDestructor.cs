using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedObjectDestructor : MonoBehaviour
{
    public float timeOut = 1.0f;
    public bool detachChildren = false;

    void Awake() {
        Invoke ("DestroyNow", timeOut);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DestroyNow ()
    {
        if (detachChildren) {
            transform.DetachChildren (); 
        }
        Destroy (gameObject);
    }
}
