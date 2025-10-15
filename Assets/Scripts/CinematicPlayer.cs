using UnityEngine;
using UnityEngine.Playables;

public class CinematicPlayer : MonoBehaviour 
{
    [SerializeField] private PlayableDirector director;
    private PlayerMovementSystem playerMove;
    void Start()
    {
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementSystem>();
        director = GetComponent<PlayableDirector>();
    }
    private void OnEnable()
    {
        director.played += StartCinematic;
        director.stopped += EndCinematic;
    }
    private void OnDisable()
    {
        director.played -= StartCinematic;
        director.stopped -= EndCinematic;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            director.Play(director.playableAsset);
        }
    }

    private void StartCinematic(PlayableDirector aDirector)
    {
        GetComponent<Collider2D>().enabled = false;
        playerMove.enabled = false;
    }
    private void EndCinematic(PlayableDirector aDirector)
    {
        playerMove.enabled = true;
    }
}

