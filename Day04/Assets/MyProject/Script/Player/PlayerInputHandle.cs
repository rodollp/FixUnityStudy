using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputHandle : MonoBehaviour
{
    public Vector2 moveInput {  get; private set; }
    public bool jumpPressed { get; private set; }



    private void Update()
    {
        ResetOneFrameInput();
        if(Keyboard.current == null) return;
        ReadMoveInput();
        ReadJumpInput();
        
    }

    void ReadMoveInput()
    {
        float h = 0;
        float v = 0;

        if (Keyboard.current.aKey.isPressed) h = -1f;
        if (Keyboard.current.dKey.isPressed) h =  1f;
        if (Keyboard.current.sKey.isPressed) v = -1f;
        if (Keyboard.current.wKey.isPressed) v =  1f;

        moveInput = new Vector2(h, v);  
        if(moveInput.magnitude > 1f)
        {
            moveInput = moveInput.normalized;
        }

    }
    void ReadJumpInput()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame) 
        { 
            jumpPressed = true;
        }
    }

    private void ResetOneFrameInput()
    {
        jumpPressed = false;
        
    }
}
