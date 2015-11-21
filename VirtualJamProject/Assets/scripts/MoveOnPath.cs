using UnityEngine;
using System.Collections;

public class MoveOnPath : MonoBehaviour {

    public GameObject waypointArrayContainer;
    private Transform[] _waypoints;
    public float Speed = 0.02f; // %2 of the path moved per second
    float currentPathPercent = 0.0f; //min 0, max 1

    void Start()
    {
        GetWaypoints();
    }

    void GetWaypoints()
    {
        var wps = waypointArrayContainer.GetComponentsInChildren<Transform>();
        _waypoints = new Transform[wps.Length - 1];

        int i = 0;
        foreach (var waypoint in wps)
        {
            if (waypoint.name == "Track")
                continue;
            _waypoints[i] = waypoint;
            i++;
        }
    }


    void Update()
    {
        currentPathPercent += Speed * Time.deltaTime;
        if (currentPathPercent > 1)
            currentPathPercent = 0;
        iTween.PutOnPath(gameObject, _waypoints, currentPathPercent);
    }

    void OnDrawGizmos()
    {
        GetWaypoints();
        //Visual. Not used in movement
        iTween.DrawPath(_waypoints);
    }
}
