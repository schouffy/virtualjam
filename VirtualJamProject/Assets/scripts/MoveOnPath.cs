using UnityEngine;
using System.Collections;

public class MoveOnPath : MonoBehaviour {

    public GameObject[] waypointArrayContainers;
    private Transform[][] _waypoints;
    public float Speed = 0.02f; // %2 of the path moved per second
    float currentPathPercent = 0.0f; //min 0, max 1
    public int CurrentTrackIndex;

    void Start()
    {
        GetWaypoints();
    }

    void GetWaypoints()
    {
        _waypoints = new Transform[waypointArrayContainers.Length][];
        int i = 0;
        foreach (var item in waypointArrayContainers)
        {
            var wps = item.GetComponentsInChildren<Transform>();
            _waypoints[i] = new Transform[wps.Length - 1];

            int j = 0;
            foreach (var waypoint in wps)
            {
                if (waypoint.name.StartsWith("Track"))
                    continue;
                _waypoints[i][j] = waypoint;
                j++;
            }
            i++;
        }
        
    }


    void Update()
    {
        
        currentPathPercent += Speed * Time.deltaTime;
        if (currentPathPercent > 1)
            currentPathPercent = 0;
        iTween.PutOnPath(gameObject, _waypoints[CurrentTrackIndex], currentPathPercent);
    }

    void OnDrawGizmos()
    {
        GetWaypoints();
        //Visual. Not used in movement
        int i = 0;
        foreach (var item in _waypoints)
        {
            iTween.DrawPath(item, GetRandomColor(i++));
        }
        
    }

    Color GetRandomColor(int? i = null)
    {
        int rnd = i ?? Random.Range(0, 10);
        switch (rnd)
        {
            case 0: return Color.white;
            case 1: return Color.black;
            case 2: return Color.blue;
            case 3: return Color.clear;
            case 4: return Color.cyan;
            case 5: return Color.gray;
            case 6: return Color.green;
            case 7: return Color.magenta;
            case 8: return Color.red;
            default: return Color.yellow;
        }
    }

    public void DecrementTrack()
    {
        if (CurrentTrackIndex > 0)
            CurrentTrackIndex--;
    }

    public void IncrementTrack()
    {
        if (CurrentTrackIndex < waypointArrayContainers.Length - 1)
            CurrentTrackIndex++;
    }
}
