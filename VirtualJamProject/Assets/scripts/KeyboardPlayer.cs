using UnityEngine;
using System.Collections;

public class KeyboardPlayer : MonoBehaviour {

    public LayerMask Track;

    private Rigidbody _rb;

    // Use this for initialization
    void Start ()
    {
        _rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("left");
            transform.Rotate(transform.up, -2);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("right");
            transform.Rotate(transform.up, 2);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("forward");
            _rb.AddRelativeForce(transform.forward * 20f);
        }

    }
}
