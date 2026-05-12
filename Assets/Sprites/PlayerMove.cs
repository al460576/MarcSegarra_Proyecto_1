using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float velocidad = 2;
    public float salto = 3;

    private Rigidbody2D rb2D;
    public CheckGround checkGround;

    public bool betterJump = false;
    public float fallMultiplier = 1.5f;
    public float lowJumpMultiplier = 2f;

    private bool isPaused = false;
    private float inputX = 0f;
    private bool jumpHeld = false;

    // ✅ Flag para detectar el salto en Update y aplicarlo en FixedUpdate
    private bool jumpRequested = false;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        checkGround = GetComponentInChildren<CheckGround>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
                OpenOptions();
            else
                CloseOptions();
        }

        if (!isPaused && (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D)))
        {
          inputX = velocidad;
        }else if (!isPaused && (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A)))
        {
          inputX = -velocidad;
        }else{
            inputX =0;
        }
        if (!isPaused && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)))
        {
            if (checkGround.isGrounded)
                jumpRequested = true;
        }
        if (!isPaused)
        {
            jumpHeld = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        }else
        {
            jumpHeld = false;
        }
    }
    void FixedUpdate()
    {
        if (isPaused) return;

        rb2D.linearVelocity = new Vector2(inputX, rb2D.linearVelocity.y);

        if (jumpRequested)
        {
            if (checkGround.isGrounded)
                rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, salto);
            jumpRequested = false;
        }

        if (betterJump)
        {
            if (rb2D.linearVelocity.y < 0)
                rb2D.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            else if (rb2D.linearVelocity.y > 0 && (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)))
                rb2D.linearVelocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void OpenOptions()
    {
        isPaused = true;
        Time.timeScale = 0f;
        SceneManager.LoadScene("Opciones", LoadSceneMode.Additive);
    }

    void CloseOptions()
    {
        isPaused = false;
        Time.timeScale = 1f;
        if (SceneManager.GetSceneByName("Opciones").isLoaded)
            SceneManager.UnloadSceneAsync("Opciones");
    }
}