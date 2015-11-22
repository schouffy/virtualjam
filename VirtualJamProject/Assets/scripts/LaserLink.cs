using UnityEngine;
using System.Collections;

public class LaserLink : MonoBehaviour {

    private LineRenderer _renderer;

    public Transform StartPos;
    public Transform EndPos;

    // Use this for initialization
    void Start () {
        _renderer = GetComponent<LineRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        _renderer.SetPosition(0, StartPos.position);
        _renderer.SetPosition(1, EndPos.position);
    }
}
