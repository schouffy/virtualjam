using UnityEngine;
using System.Collections;

public class Booster : MonoBehaviour {

    private float _defaultSpeed;
    private GameObject _player;
    public bool RestoreDefaultSpeed;
    public float NewSpeed;

    // Use this for initialization
    void Start () {
        _player = GameObject.FindGameObjectWithTag("Player");
        _defaultSpeed = _player.GetComponent<MoveOnPath>().Speed;
    }
	
	
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
            _player.GetComponent<MoveOnPath>().Speed = RestoreDefaultSpeed ? _defaultSpeed : NewSpeed;
        }
    }
}
