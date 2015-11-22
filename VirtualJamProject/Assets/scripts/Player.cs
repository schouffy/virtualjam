using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public LayerMask Track;
    public LayerMask Obstacles;
    public RopeLeader RopeLeader;
    private float _lostTrackTime = -1;

    private IntroManager _gameManager;

    public AudioClip DeathSound;
    public AudioClip DeathObstacleSound;

    void Awake()
    {
        _gameManager = Camera.main.GetComponent<IntroManager>();
    }

    void Update()
    {
        RaycastHit hit;
        if (!Physics.Raycast(transform.position, -transform.up, out hit, 30f, Track.value))
        {
            if (_lostTrackTime == -1)
                _lostTrackTime = Time.time;
        }
        else
        {
            _lostTrackTime = -1;
        }

        if (_lostTrackTime > 0 && _lostTrackTime < Time.time - 1 && !_isDead)
        {
            Die();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Obstacles") && !_isDead)
        {
            GetComponent<AudioSource>().PlayOneShot(DeathObstacleSound);
            Die();
        }
    }

    bool _isDead = false;
    void Die()
    {
        GetComponent<AudioSource>().PlayOneShot(DeathSound);
        _isDead = true;
        Debug.Log("Die");

        RopeLeader.enabled = false;
        _gameManager.ReloadScene();
    }
}
