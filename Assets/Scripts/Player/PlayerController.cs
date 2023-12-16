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
    private bool shouldDrawGizmos;
    private bool canMove = true;
    private void Awake() {
        playerControls = new PlayerControls();

        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        storeOwner = GameObject.FindGameObjectWithTag("StoreOwner").transform;
    }

    private void Update() {
        PlayerMovementInputReader();
        Animate();

        if(InteractableFinder())
        {
            playerControls.PlayerActions.Interaction.performed += PlayerInteractionReader;
            shouldDrawGizmos = true;
        }
        else
        {
            playerControls.PlayerActions.Interaction.performed -= PlayerInteractionReader;
            shouldDrawGizmos = false;
        }
    }
    private void FixedUpdate() {
        Move();
    }
    private void PlayerMovementInputReader()
    {
        if(canMove)
        {
            movement = playerControls.PlayerActions.Move.ReadValue<Vector2>();  

            if (movement.x != 0 || movement.y != 0)
            {
                lastMoveDirection = movement;
            } 
        }
    }

    private void PlayerInteractionReader(InputAction.CallbackContext context)
    {
        DialogManager.onPlayerInteract.Invoke();
        canMove = false;
    }
    private void Animate()
    {
        playerAnimator.SetFloat("moveX", movement.x);
        playerAnimator.SetFloat("moveY", movement.y);
        playerAnimator.SetFloat("lastMoveX", lastMoveDirection.x);
        playerAnimator.SetFloat("lastMoveY", lastMoveDirection.y);
        playerAnimator.SetFloat("speed", movement.magnitude);
    }

    private bool InteractableFinder()
    {
        float distance = Vector2.Distance(transform.position, storeOwner.position );

        return distance < interecationDistance;
    }
    private void Move()
    {
        rb.MovePosition( rb.position + movement * (moveSpeed * Time.fixedDeltaTime) );
    }
    private void OnDrawGizmos()
    {
        
        if (shouldDrawGizmos)
        {
            Gizmos.color = Color.green; // Cor dos gizmos
            Gizmos.DrawWireSphere(storeOwner.position, 3f);
        }
    }
    #region // enablaling inputs
    private void OnEnable() {
        playerControls.Enable();
    }

    private void OnDisable() {
        playerControls.Disable();
    }
    #endregion
}
