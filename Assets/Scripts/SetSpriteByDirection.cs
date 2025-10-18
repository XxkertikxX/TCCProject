using UnityEngine;

public class SetSpriteByDirection : MonoBehaviour
{
    [SerializeField] private Sprite[] directionSprites;

    public void SetSprite(NoteMovement movement)
    {
        GetComponent<SpriteRenderer>().sprite = texturebyDirection(movement);
    }
    private Sprite texturebyDirection(NoteMovement movement)
    {
        for(int i = 0; i <= movement.Direction.Input.Count; i++)
        {
            if (movement.Direction.Input[i] == "Left2")
                return directionSprites[2];
            if(movement.Direction.Input[i] == "Right2")
                return directionSprites[3];
            if (movement.Direction.Input[i] == "Up")
                return directionSprites[0];
            if (movement.Direction.Input[i] == "Down")
                return directionSprites[1];
        }
            return null;
    }
}
