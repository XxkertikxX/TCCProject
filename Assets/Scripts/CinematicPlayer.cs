using UnityEngine;
using UnityEngine.Playables;

public class CinematicPlayer : MonoBehaviour 
{
    [SerializeField] private PlayableDirector director;
    private PlayerMovementSystem playerMove;
    private AnimationSrc playerAnim;

    void Awake() {
        Transform player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        director = GetComponent<PlayableDirector>();
        playerMove = player.GetComponent<PlayerMovementSystem>();
        playerAnim = player.GetComponentInChildren<AnimationSrc>();
    }

    private void OnEnable() {
        director.played += StartCinematic;
        director.stopped += EndCinematic;
    }
    private void OnDisable()
    {
        director.played -= StartCinematic;
        director.stopped -= EndCinematic;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") { 
            director.Play();
        }
    }

    private void StartCinematic(PlayableDirector aDirector) {
        GetComponent<Collider2D>().enabled = false;
        playerMove.enabled = false;
        playerAnim.enabled = false;
    }

    private void EndCinematic(PlayableDirector aDirector) {
        playerMove.enabled = true;
        playerAnim.enabled = true;
        gameObject.SetActive(false);
    }
}

