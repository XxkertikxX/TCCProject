using UnityEngine.UI;
using UnityEngine;


public class PlayVoiceAudio : MonoBehaviour
{
    [SerializeField] private Text actualCharacter;
    public void PlayVoice()
    {
        GameAudioManager.PlaySound(CharacterTalking());
    }

    private SoundTypes CharacterTalking()
    {
        switch (actualCharacter.text)
        {
            case "Liora":
                return SoundTypes.LioraTalking;
            case "Alon":
                return SoundTypes.AlonTalking;
            case "Amber":
                return SoundTypes.AmberTalking;
            case "Clementime":
                return SoundTypes.ClementimeTalking;
            case "Rei":
                break;
            case "Fang":
                break;
            case "NPC2":
                break;
            case "NPC3":
                break;
        }
        return SoundTypes.LioraTalking;
    }
}
