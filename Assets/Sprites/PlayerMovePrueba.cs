using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovePrueba : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidad = 5f;

    [Header("Salto")]
    public float salto = 20f;
    public float coyoteTime = 0.15f;
    public float jumpBufferTime = 0.15f;

    [Header("Suelo")]
    public float groundCheckDistance = 0.1f;
    public LayerMask groundLayer;

    [Header("Ataque")]
    public float dañoGolpe = 25f;
    public float tiempoEntreGolpes = 0.5f;

    private float timerGolpe = 0f;
    private float coyoteCounter;
    private float jumpBufferCounter;

    private Rigidbody2D rb2D;
    private CapsuleCollider2D capsuleCollider;

    private InputAction moveAction;
    private InputAction jumpAction;

    private float inputX = 0f;
    private bool isJumpPressed = false;
    private bool isGrounded = false;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    private void OnEnable()
    {
        moveAction = new InputAction("Move", InputActionType.Value);
        var composite = moveAction.AddCompositeBinding("1DAxis");
        composite.With("Negative", "<Keyboard>/a");
        composite.With("Negative", "<Keyboard>/leftArrow");
        composite.With("Positive", "<Keyboard>/d");
        composite.With("Positive", "<Keyboard>/rightArrow");

        jumpAction = new InputAction("Jump", InputActionType.Button);
        jumpAction.AddBinding("<Keyboard>/space");
        jumpAction.AddBinding("<Keyboard>/upArrow");
        jumpAction.AddBinding("<Keyboard>/w");

        moveAction.Enable();
        jumpAction.Enable();
        jumpAction.performed += OnJump;
        jumpAction.canceled += OnJump;
    }

    private void OnDisable()
    {
        jumpAction.performed -= OnJump;
        jumpAction.canceled -= OnJump;
        jumpAction.Disable();
        moveAction.Disable();
    }

    private void Update()
    {
        inputX = moveAction.ReadValue<float>() * velocidad;

        isGrounded = Physics2D.OverlapBox(
            new Vector2(capsuleCollider.bounds.center.x, capsuleCollider.bounds.min.y - 0.05f),
            new Vector2(capsuleCollider.bounds.size.x * 0.9f, 0.1f),
            0f,
            groundLayer
        ) != null;

        if (isJumpPressed)
            jumpBufferCounter = jumpBufferTime;
        else
            jumpBufferCounter -= Time.deltaTime;

        if (isGrounded)
            coyoteCounter = coyoteTime;
        else
            coyoteCounter -= Time.deltaTime;

        if (timerGolpe > 0)
            timerGolpe -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        rb2D.linearVelocity = new Vector2(inputX, rb2D.linearVelocity.y);
        if (rb2D.linearVelocity.y < 0)
            rb2D.linearVelocity += Vector2.up * Physics2D.gravity.y * 1.5f * Time.fixedDeltaTime;

        HandleJump();
    }

    private void HandleJump()
    {
        if (jumpBufferCounter > 0 && coyoteCounter > 0)
        {
            rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, salto);
            jumpBufferCounter = 0;
            coyoteCounter = 0;
            isJumpPressed = false;
        }

        if (!isJumpPressed && rb2D.linearVelocity.y > 0)
            rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, rb2D.linearVelocity.y * 0.5f);
    }

    private void OnJump(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
            isJumpPressed = true;
        else if (ctx.canceled)
            isJumpPressed = false;
    }

    // --- Ataque automático al tocar al enemigo ---

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy") && timerGolpe <= 0)
        {
            col.GetComponent<VidaEnemigo>()?.RecibirDaño(dañoGolpe);
            timerGolpe = tiempoEntreGolpes;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Enemy") && timerGolpe <= 0)
        {
            col.GetComponent<VidaEnemigo>()?.RecibirDaño(dañoGolpe);
            timerGolpe = tiempoEntreGolpes;
        }
    }
}