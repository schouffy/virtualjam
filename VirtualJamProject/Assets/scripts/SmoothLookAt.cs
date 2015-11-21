using UnityEngine;
using System.Collections;

public class SmoothLookAt : MonoBehaviour
{

    public Transform ObjectToLook;
    public float SmoothSpeed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       // transform.LookAt(Vector3.Lerp(transform.forward, ObjectToLook.position, Time.deltaTime * SmoothSpeed));
        transform.LookAt(ObjectToLook.position, transform.up);
    }

}
