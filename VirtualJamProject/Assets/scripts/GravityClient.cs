using UnityEngine;
using System.Collections;

public class GravityClient : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.F))
        {
            // modify gravity to what is aimed
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 1000, Color.red, 5f);
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 500f))
            {
                Physics.gravity = 
                //GameObject.FindGameObjectWithTag("GravityManager").GetComponent<CustomGravity>().Gravity =
                Camera.main.transform.forward * 4f;
            }
        }
    }
}
