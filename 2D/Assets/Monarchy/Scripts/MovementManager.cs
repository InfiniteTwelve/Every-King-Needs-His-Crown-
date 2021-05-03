using UnityEngine;
using UnityEngine.InputSystem;

public class MovementManager : MonoBehaviour
{   
    [Header("Physics settings")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;

    [Header("Collision Detection")]
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundCheckRadius;
    [SerializeField] private LayerMask _collisionLayers;


    private InputActions _controls;
    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;
    private Vector2 _walkInput;
    private Vector3 _velocity = Vector3.zero;
    private bool _isGrounded = true;

    // ################# INITIALISATION ####################

    private void Awake()
    {
        _controls = new InputActions();
        _controls.Player.Movement.performed += Move;
        _controls.Player.Movement.canceled += Move;
        _controls.Player.Jump.performed += Jump;

        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        _controls.Enable();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }

    // #################### UPDATE ###############################"

    private void FixedUpdate()
    {
        CheckIfGrounded();
        ApplyMovement();
    }

    // ################### METHODS #############################"

    private void Move(InputAction.CallbackContext obj)
    {
        _walkInput = obj.ReadValue<Vector2>();
        Debug.Log("Player wants to move " + _walkInput);
    }
    private void ApplyMovement()
    {    
        float horizontalMovement = _walkInput.x * _moveSpeed * Time.deltaTime;
        Vector3 targetVelocity = new Vector2(horizontalMovement, _rb.velocity.y);
        _rb.velocity = Vector3.SmoothDamp(_rb.velocity, targetVelocity, ref _velocity, 0.05f);
    }

    private void Jump(InputAction.CallbackContext obj)
    {
        if (!_isGrounded)
            return;
      
        _rb.AddForce(new Vector2(0f, _jumpForce));
    }

    private void CheckIfGrounded() => _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _collisionLayers);

    private void Flip(float velocity)
    {
        if (velocity > 0.1f)
            _spriteRenderer.flipX = false;
        else if (velocity < -0.1f)
            _spriteRenderer.flipX = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(_groundCheck.position, _groundCheckRadius);
    }
}
