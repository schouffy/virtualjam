using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour {

    public static bool HasSeenIntro = false;
    private GameObject _player;

    public bool PlayIntro;

    public SpriteRenderer BlackOverlay;

    public SpriteRenderer Img1;
    public SpriteRenderer Img2;
    public SpriteRenderer Img3;
    public SpriteRenderer Img4;
    public SpriteRenderer Img5;
    public SpriteRenderer Img6;
    public SpriteRenderer Img7;

    public AudioClip StartupSound;
    public AudioClip BackgroundMusic;

    // Use this for initialization
    void Start () {
        _player = GameObject.FindGameObjectWithTag("Player");
        if (PlayIntro)
            StartCoroutine(SeeIntro());
	}

    public void ReloadScene()
    {
        StartCoroutine(DoReloadScene());
    }

    IEnumerator DoReloadScene()
    {
        yield return StartCoroutine(FadeToBlack());
        yield return new WaitForSeconds(1.5f);
        Application.LoadLevel(0);
    }

    IEnumerator FadeToBlack()
    {
        Debug.Log("fade to black");
        Color c = new Color(0, 0, 0, 0);
        BlackOverlay.color = c;
        while (BlackOverlay.color.a < 1)
        {
            c.a += 0.05f;
            BlackOverlay.color = c;
            yield return new WaitForSeconds(0.025f);
        }
    }

    IEnumerator FadeToGame()
    {
        Debug.Log("fade to game");
        Color c = new Color(0, 0, 0, 1);
        BlackOverlay.color = c;
        while (BlackOverlay.color.a > 0)
        {
            c.a -= 0.05f;
            BlackOverlay.color = c;
            yield return new WaitForSeconds(0.025f);
        }
    }

    IEnumerator SeeIntro()
    {
        if (!HasSeenIntro)
        {
            BlackOverlay.color = new Color(0, 0, 0, 1);
            _player.GetComponent<MoveOnPath>().enabled = false;
            _player.GetComponent<AudioSource>().enabled = false;

            // écran noir + explication controles
            yield return new WaitForSeconds(1f);

            // demarrer sons
            GetComponent<AudioSource>().PlayOneShot(StartupSound);

            // titl 1
            Img1.enabled = true;
            yield return new WaitForSeconds(1f);
            
            // tilt 2
            Img1.enabled = false;
            Img2.enabled = true;
            yield return new WaitForSeconds(1f);

            Img2.enabled = false;

            StartCoroutine(FadeToGame());
            yield return new WaitForSeconds(0.5f);

            // premier feu
            Img3.enabled = true;
            yield return new WaitForSeconds(0.5f);

            // 2 feu
            Img3.enabled = false;
            Img4.enabled = true;
            yield return new WaitForSeconds(0.5f);

            // 3 feu
            Img4.enabled = false;
            Img5.enabled = true;
            yield return new WaitForSeconds(0.5f);

            // 4 feu
            Img5.enabled = false;
            Img6.enabled = true;
            yield return new WaitForSeconds(0.5f);

            // 5 feu
            Img6.enabled = false;
            Img7.enabled = true;
            yield return new WaitForSeconds(0.5f);

            Img7.enabled = false;

            _player.GetComponent<MoveOnPath>().enabled = true;
            _player.GetComponent<AudioSource>().enabled = true;


            // Demarrage loop musique
            GetComponent<AudioSource>().clip = BackgroundMusic;
            GetComponent<AudioSource>().Play();

        }
        else
        {
            GetComponent<AudioSource>().clip = BackgroundMusic;
            GetComponent<AudioSource>().Play();
        }
        HasSeenIntro = true;
    }
	
}
