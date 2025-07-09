using System.Threading.Tasks;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public bool CanFollowY;

    [SerializeField] private Transform target;
    [SerializeField] private int index;

    private Vector3 pos;

    void Update() {
        FollowX();
        if (CanFollowY) {
            pos.y = Mathf.Lerp(pos.y, target.position.y, Time.deltaTime*5);
        }
        if (transform.position.x < pos.x) {
            transform.position = pos;
        }
    }

    private void FollowX() {
        pos.x = target.position.x;
    }

    public async void FollowY() {
        await Task.Delay(150 * index);
        CanFollowY = true;
    }
}
