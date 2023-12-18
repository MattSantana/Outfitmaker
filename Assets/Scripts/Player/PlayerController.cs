using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    public float interecationDistance = 1f;
    private PlayerControls playerControls;
    private Vector2 movement;
    private Vector2 lastMoveDirection;
    private Rigidbody2D rb;
    private Animator playerAnimator;
    public Transform sellerOwner;
    public Transform buyerOwner;
    private bool canMove = true;

    //Singleton
    public static PlayerController Instance { get; private set ; }

    public delegate bool OnPlayerInteraction();
    public static OnPlayerInteraction onPlayerInteraction;
  
    public float sellerDistance;
    public float buyerDistance;
    private void Awake() {
        Instance = this;
        playerControls = new PlayerControls();

        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        sellerOwner = GameObject.FindGameObjectWithTag("SellerOwner").transform;
        buyerOwner = GameObject.FindGameObjectWithTag("BuyerOwner").transform;
    }
    private void Start() {
        DialogManager.Instance.onClosingDialog += EnablelingActions;
    }
    private void Update()
    {

        if (canMove)
        {
            PlayerMovementInputReader();
        }

        Animate();

        Interactions();

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
    private void Interactions()
    {
        if (SellerInteractFinder())
        {
            playerControls.PlayerActions.Interaction.performed += SelllerInteraction;
        }
        else if (BuyerInteractFinder())
        {
            playerControls.PlayerActions.Interaction.performed += BuyerInteraction;
        }
        else
        {
            playerControls.PlayerActions.Interaction.performed -= SelllerInteraction;
            playerControls.PlayerActions.Interaction.performed -= BuyerInteraction;
        }
    }
    private void SelllerInteraction(InputAction.CallbackContext context)
    {
        DialogManager.onSellerInteract.Invoke();
        canMove = false;
    }

    private void BuyerInteraction(InputAction.CallbackContext context)
    {
        DialogManager.onBuyerInteract.Invoke();
        canMove = false;
    }

    private void EnablelingActions()
    {
        canMove = true;
    }

    private bool SellerInteractFinder()
    {
        float distance = Vector2.Distance(transform.position, sellerOwner.position );

        sellerDistance = distance;

        return distance < interecationDistance;
    }

    private bool BuyerInteractFinder()
    {
        float distance = Vector2.Distance(transform.position, buyerOwner.position );

        buyerDistance = distance;

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
