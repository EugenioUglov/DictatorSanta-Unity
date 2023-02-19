using UnityEngine;
using UnityEngine.InputSystem;

public class Game : MonoBehaviour
{
    [SerializeField] private DialogueBuilder _dialogueBuilder;
    // [SerializeField] private AudioManager _audioManager;
    [SerializeField] private Music _music;
    private TouchControls _touchControls;
    
    
    private void Awake()
    {
        _touchControls = new TouchControls();
    }

    private void OnEnable() 
    {
        _touchControls.Enable();
    }

    private void OnDisable()
    {
        _touchControls.Disable();
    }
    
    
    private void Start()
    {
        _touchControls.Touch.TouchPress.started += ctx => OnStartTouch(ctx);
        _touchControls.Touch.TouchPress.canceled += ctx => OnEndTouch(ctx);
        _dialogueBuilder.CreateAppealsToSanta();

        _music.PlayBackgroundMusic();
    }

    private void OnStartTouch(InputAction.CallbackContext context)
    {
        print("touch");
    }

    private void OnEndTouch(InputAction.CallbackContext context)
    {
        print("end touch");
    }
}
