using UnityEngine;
using System.Collections;

public class LookForward : MonoBehaviour {
    
    private Vector3 _lastFramePos;
    public float lerp;

    // Use this for initialization
    void Start () {
        _lastFramePos = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.Lerp(
            transform.rotation, Quaternion.LookRotation((transform.position - _lastFramePos) * 100f, transform.up), Time.deltaTime * lerp);

        //transform.LookAt((transform.position - _lastFramePos) * 100f, transform.up);
        //Debug.DrawRay(transform.position, (transform.position - _lastFramePos) * 100f, Color.magenta, 1f);
        _lastFramePos = transform.position;
    }
}
