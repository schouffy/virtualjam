using UnityEngine;
using System.Collections;

public class RopeLeader : MonoBehaviour {

    public Transform RopeFollower;

    private float _distance;
    public float CloseForce;
    public float OffRangeRatio = 1.5f;
    public ForceMode Forcemode;

    // Use this for initialization
    void Start () {
        _distance = Vector3.Distance(transform.position, RopeFollower.position);
	}
	
	// Update is called once per frame
	void Update () {
        var dist = Vector3.Distance(transform.position, RopeFollower.position);
        if (dist > _distance * OffRangeRatio)
        {
            var force = transform.position - RopeFollower.position;
            RopeFollower.GetComponent<Rigidbody>().AddForce(force  * CloseForce, Forcemode);
        }
	}

    

}
