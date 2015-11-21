using UnityEngine;
using System.Collections;

public class RopeLeader : MonoBehaviour {

    public Transform RopeFollower;

    private float _distance;
    public float CloseForce;
    public float OffRangeRatio = 1.5f;
    public float OffRangeVelocityDamping = 0.7f;
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
            //RopeFollower.transform.position = (transform.position - RopeFollower.position).normalized * 
            //Debug.Log("too far away").
            var force = transform.position - RopeFollower.position;
            //RopeFollower.GetComponent<Rigidbody>().velocity
            //RopeFollower.GetComponent<Rigidbody>().velocity *= OffRangeVelocityDamping;
            RopeFollower.GetComponent<Rigidbody>().AddForce(force  * CloseForce, Forcemode);

            //RopeFollower.GetComponent<Rigidbody>().AddForce(-RopeFollower.GetComponent<Rigidbody>().velocity * CloseForce, ForceMode.Acceleration);

        }
        else
        {
            //RopeFollower.GetComponent<Rigidbody>().velocity *= OffRangeVelocityDamping;
        }
	}

    

}
