using UnityEngine;

public class PlayerInput
{
    private KeyCode keyToMoveUp { get; }
    private KeyCode keyToMoveDown { get; }

    public PlayerInput(KeyCode moveUp, KeyCode moveDown)
    {
        keyToMoveUp = moveUp;
        keyToMoveDown = moveDown;
    }
}
