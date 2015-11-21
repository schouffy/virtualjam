using UnityEngine;
using System.Collections;

public class SticksOnGround : MonoBehaviour {

    Vector3 _target;
    public float SmoothSpeed;
    public LayerMask Track;
    
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        Debug.DrawRay(transform.position, -transform.up, Color.red, 15f);
	    if (Physics.Raycast(transform.position, -transform.up, out hit, 15f, Track.value))
        {
            _target = hit.normal.normalized;
            Debug.DrawRay(transform.position, _target, Color.yellow, 15f);
        }
        if (_target != Vector3.zero)
        {
            transform.up = Vector3.Lerp(transform.up, _target, Time.deltaTime * SmoothSpeed);
        }
	}
}
