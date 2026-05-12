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
            {
            OpenOptions();
            }
        }
        if (!isPaused){
             Debug.Log("inputX: " + inputX + " | D: " + Input.GetKey(KeyCode.D) + " | RightArrow: " + Input.GetKey(KeyCode.RightArrow));
            if(Input.GetKey(KeyCode.RightArrow)||Input.GetKey(KeyCode.D))
            {
                inputX = velocidad;
            }else if(Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.A)) 
            {
                inputX = -velocidad;
            }else{
                inputX = 0;
            }
            if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.Space)) && checkGround.isGrounded)
            {
                jumpRequested = true;
            }
            jumpHeld = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.Space);    
        }else{
            inputX = 0;
            jumpHeld = false;
        }
    }
    
    void FixedUpdate()
    {
        if (isPaused) return;

        rb2D.linearVelocity = new Vector2(inputX, rb2D.linearVelocity.y);
         Debug.Log("Velocidad aplicada: " + rb2D.linearVelocity + " | inputX: " + inputX);

        if (jumpRequested)
        {
            if (checkGround.isGrounded)
                rb2D.AddForce(Vector2.up * salto, ForceMode2D.Impulse);
            jumpRequested = false;
        }

        if (betterJump)
        {
            if (rb2D.linearVelocity.y < 0)
                rb2D.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            else if (rb2D.linearVelocity.y > 0 && jumpHeld)
                rb2D.linearVelocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    public void OpenOptions()
    {
        isPaused = true;
        Time.timeScale = 0f;
        SceneManager.LoadScene("Opciones", LoadSceneMode.Additive);
    }

    public void CloseOptions()
    {
        isPaused = false;
        Time.timeScale = 1f;
        if (SceneManager.GetSceneByName("Opciones").isLoaded)
            SceneManager.UnloadSceneAsync("Opciones");
    }
}