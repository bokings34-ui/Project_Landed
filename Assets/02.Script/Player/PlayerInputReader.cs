using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerInputReader : MonoBehaviour
{
    private PlayerInput playerInput;

    InputAction jumpAction;
    InputAction slideAction;
    InputAction resetPositionAction;

    public bool JumpPressedThisFrame { get; private set; }
    public bool SlideHeldPressed { get; private set; }
    public bool ResetPositionPressedThisFrame { get; private set; }

    private string jumpActionName = "Jump";
    private string slideActionName = "Slide";
    private string resetPositionActionName = "ResetPosition";

    private void Awake()
    {
        if(playerInput == null) playerInput = GetComponent<PlayerInput>();
        ResloveAction();
    }

    private void Update()
    {
        JumpPressedThisFrame = jumpAction != null && jumpAction.WasPressedThisFrame();
        SlideHeldPressed = slideAction != null && slideAction.IsPressed();
        ResetPositionPressedThisFrame = resetPositionAction != null && resetPositionAction.WasPressedThisFrame();
    }

    private void ResloveAction()
    {
        if (playerInput == null || playerInput.actions == null)
        {
            Debug.LogWarning("[PlayerInput Action Asset] 확인 필요");
            return;
        }

        jumpAction = FindAction(jumpActionName);
        slideAction = FindAction(slideActionName);
        resetPositionAction = FindAction(resetPositionActionName);
    }

    private InputAction FindAction(string actionName)
    {
        //방어코드 
        if (string.IsNullOrWhiteSpace(actionName))
        {
            return null;
        }

        InputAction action = playerInput.actions.FindAction(actionName, false);
        if (action == null)
        {
            Debug.LogWarning($"[PlayerInputReader] Action 못 찾음:{actionName} ");
        }
        return action;
    }
}

