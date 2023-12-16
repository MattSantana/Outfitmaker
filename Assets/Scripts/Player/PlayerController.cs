using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    private PlayerControls playerControls;
    private Vector2 movement;
    private Vector2 lastMoveDirection;
    private Rigidbody2D rb;
    private Animator playerAnimator;

    private void Awake() {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    private void Update() {
        PlayerInput();
        Animate();
    }
    private void FixedUpdate() {
        Move();
    }
    private void PlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();  

        if (movement.x != 0 || movement.y != 0)
        {
            lastMoveDirection = movement;
        }      
    }

    private void Animate()
    {
        playerAnimator.SetFloat("moveX", movement.x);
        playerAnimator.SetFloat("moveY", movement.y);
        playerAnimator.SetFloat("lastMoveX", lastMoveDirection.x);
        playerAnimator.SetFloat("lastMoveY", lastMoveDirection.y);
        playerAnimator.SetFloat("speed", movement.magnitude);
    }

    private void Move()
    {
        rb.MovePosition( rb.position + movement * (moveSpeed * Time.fixedDeltaTime) );
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
