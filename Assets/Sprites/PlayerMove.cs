using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class PlayerMove : MonoBehaviour
{

    public float velocidad = 2;
    public float salto=3;
    private Rigidbody2D rb2D;
    private CheckGround checkGround;
    private float movimiento;
    public bool betterJump = false;
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 1f;
    private bool isPaused = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        checkGround= GetComponentInChildren<CheckGround>();

    }
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Escape))
       {
        if (!isPaused){
            OpenOptions();
        }else{
            CloseOptions();
        }
       }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isPaused)return;
        if (Input.GetKey("d")|| Input.GetKey("right"))
        {
            rb2D.linearVelocity= new Vector2(velocidad, rb2D.linearVelocity.y);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2D.linearVelocity= new Vector2(-velocidad, rb2D.linearVelocity.y);
        }
        else
        {
            rb2D.linearVelocity = new Vector2(0, rb2D.linearVelocity.y);
        }
        if((Input.GetKey("w") || Input.GetKey("up")) && checkGround.isGrounded)
        {
            rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, salto);
        }
        if (betterJump)
        {
            if (rb2D.linearVelocity.y < 0)
            {
                rb2D.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
            else if (rb2D.linearVelocity.y > 0 && (Input.GetKey("w") || Input.GetKey("up")))
            {
                rb2D.linearVelocity+= Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
        }
    }
    void OpenOptions(){
        isPaused=true;
        Time.timeScale = 0f;
        SceneManager.LoadScene("Opciones",LoadSceneMode.Additive);
        
    }
    void CloseOptions(){
         isPaused = false;
        Time.timeScale = 1f;
        SceneManager.UnloadSceneAsync("Opciones");
    }
}

