using UnityEngine;

public class PlayEnemySounds : MonoBehaviour {
    public void PlaySound(SoundTypes type) {
        GameAudioManager.PlaySound(type);
    }
}
