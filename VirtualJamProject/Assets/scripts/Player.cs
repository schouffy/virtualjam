using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public LayerMask Track;
    public LayerMask Obstacles;
    public RopeLeader RopeLeader;

    void Update()
    {
        RaycastHit hit;
        if (!Physics.Raycast(transform.position, -transform.up, out hit, 30f, Track.value))
        {
            Debug.Log("Die fall");
        }
        RaycastHit hit2;
        if (Physics.Raycast(transform.position, transform.forward, out hit2, 1f, Obstacles.value))
        {
            Debug.Log("Die obstacle");
        }
    }

    IEnumerator Die()
    {
        Debug.Log("Die");
        RopeLeader.enabled = false;
        yield return new WaitForSeconds(2f);
        Application.LoadLevel(0);
    }
}
