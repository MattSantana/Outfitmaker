using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float interecationDistance = 1f;
    private PlayerControls playerControls;
    private Vector2 movement;
    private Vector2 lastMoveDirection;
    private Rigidbody2D rb;
    private Animator playerAnimator;
    private Transform storeOwner;
    private bool canMove = true;

    //Singleton
    public static PlayerController Instance { get; private set ; }

    public delegate bool OnPlayerInteraction();
    public static OnPlayerInteraction onPlayerInteraction;
    private void Awake() {
        Instance = this;
        playerControls = new PlayerControls();

        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        storeOwner = GameObject.FindGameObjectWithTag("StoreOwner").transform;
    }
    private void Start() {
        DialogManager.Instance.onClosingDialog += EnablelingActions;
    }
    private void Update() {
        
        if(canMove)
        {
            PlayerMovementInputReader();
        }
   
        Animate();

        if(InteractableFinder())
        {
            playerControls.PlayerActions.Interaction.performed += PlayerInteractionReader;    
        }
        else
        {
            playerControls.PlayerActions.Interaction.performed -= PlayerInteractionReader;
        }
    }
    private void FixedUpdate() 
    {
        Move();
    }

    #region movement section
    private void PlayerMovementInputReader()
    {
        movement = playerControls.PlayerActions.Move.ReadValue<Vector2>();  

        if (movement.x != 0 || movement.y != 0)
        {
            lastMoveDirection = movement;
        } 
    }
    private void Move()
    {
        rb.MovePosition( rb.position + movement * (moveSpeed * Time.fixedDeltaTime) );
    }
    private void Animate()
    {
        playerAnimator.SetFloat("moveX", movement.x);
        playerAnimator.SetFloat("moveY", movement.y);
        playerAnimator.SetFloat("lastMoveX", lastMoveDirection.x);
        playerAnimator.SetFloat("lastMoveY", lastMoveDirection.y);
        playerAnimator.SetFloat("speed", movement.magnitude);
    }
    #endregion

    #region interaction section

    private void PlayerInteractionReader(InputAction.CallbackContext context)
    {
        DialogManager.onPlayerInteract.Invoke();
        canMove = false;
    }

    private void EnablelingActions()
    {
        canMove = true;
    }
    public bool IsInteractionPressed()
    {
        return playerControls.PlayerActions.Interaction.triggered;
    }

    private bool InteractableFinder()
    {
        float distance = Vector2.Distance(transform.position, storeOwner.position );

        return distance < interecationDistance;
    }

    #endregion

    #region // enablaling inputs
    private void OnEnable() {
        playerControls.Enable();
    }

    private void OnDisable() {
        playerControls.Disable();
    }
    #endregion
}
