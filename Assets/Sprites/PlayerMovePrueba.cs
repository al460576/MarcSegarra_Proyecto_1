using UnityEngine;

public class PlayerMovePrueba : MonoBehaviour
{ public float velocidad = 2;
    public float salto = 3;

    private Rigidbody2D rb2D;
    public CheckGround checkGround;

    public bool betterJump = false;
    public float fallMultiplier = 1.5f;
    public float lowJumpMultiplier = 2f;

    private float inputX = 0f;
    private bool jumpHeld = false;
    private bool jumpRequested = false;

    // --- Controles UI ---
    private float uiInputX = 0f;
    private bool uiJumpRequested = false;
    private bool uiJumpHeld = false;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        checkGround = GetComponentInChildren<CheckGround>();
        inputX = 0f;
        rb2D.gravityScale = 1f;
    }

    void Update()
    {
        // Teclado
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            inputX = velocidad;
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            inputX = -velocidad;
        else
            inputX = uiInputX;

        // Salto teclado
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && checkGround.isGrounded)
            jumpRequested = true;

        // Salto UI
        if (uiJumpRequested && checkGround.isGrounded)
        {
            jumpRequested = true;
            uiJumpRequested = false;
        }

        jumpHeld = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space) || uiJumpHeld;
    }

    void FixedUpdate()
    {
        rb2D.linearVelocity = new Vector2(inputX, rb2D.linearVelocity.y);

        if (jumpRequested)
        {
            if (checkGround.isGrounded)
                rb2D.AddForce(Vector2.up * salto, ForceMode2D.Impulse);
            jumpRequested = false;
        }

        if (betterJump)
        {
            if (rb2D.linearVelocity.y < 0)
                rb2D.gravityScale = fallMultiplier;
            else if (rb2D.linearVelocity.y > 0 && !jumpHeld)
                rb2D.gravityScale = lowJumpMultiplier;
            else
                rb2D.gravityScale = 1f;
        }
    }

    // --- Métodos para los botones UI ---
    public void OnLeftDown()  { uiInputX = -velocidad; }
    public void OnLeftUp()    { uiInputX = 0; }
    public void OnRightDown() { uiInputX = velocidad; }
    public void OnRightUp()   { uiInputX = 0; }
    public void OnJumpDown()  { uiJumpRequested = true; uiJumpHeld = true; }
    public void OnJumpUp()    { uiJumpHeld = false; }

}