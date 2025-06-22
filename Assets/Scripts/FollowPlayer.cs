using System.Threading.Tasks;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform Target;
    Vector3 pos;
    [SerializeField] int Position;
    public bool CanFollowY;
    void Update() {
        FollowX();
        if (CanFollowY) {
            pos.y = Mathf.Lerp(pos.y, Target.position.y, Time.deltaTime*5);
        }
        if (transform.position.x < pos.x) {
            transform.position = pos;
        }
    }

    void FollowX() {
        pos.x = Target.position.x;
    }

    public async void FollowY() {
        await Task.Delay(150 * Position);
        CanFollowY = true;
    }
}
