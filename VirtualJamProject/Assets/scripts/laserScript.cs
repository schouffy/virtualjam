using UnityEngine;
using System.Collections;

public class laserScript : MonoBehaviour {


    public Transform Player;
    public Transform Tracteur;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 dist = Tracteur.position - Player.position;
        transform.position = Player.position + dist * 0.5f;
        transform.localScale = new Vector3(1,dist.magnitude,1);
	}
}
