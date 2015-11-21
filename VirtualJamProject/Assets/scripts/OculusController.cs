using UnityEngine;
using System.Collections;

public class OculusController : MonoBehaviour {

    public float PlayerMoveMultiplier;

    // Use this for initialization
    void Start () {
        Input.gyro.enabled = true;
    }

    void FixedUpdate()
    {
        var pos = UnityEngine.VR.InputTracking.GetLocalPosition(UnityEngine.VR.VRNode.Head);
       // Debug.Log("Player head pos " + pos);
        if (Mathf.Abs(pos.x) > 0.05)
        {
            var force = new Vector3(pos.x * PlayerMoveMultiplier, 0, 0);
            //Debug.Log("Player moves to " + force);
            //Debug.DrawRay(transform.position, force, Color.red, 5f);
            this.GetComponent<Rigidbody>().AddRelativeForce(force, ForceMode.Acceleration);
        }
    }
}
