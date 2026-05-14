using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public bool isGrounded;
    public float distancia = 1f;
    public LayerMask groundLayer;

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distancia, groundLayer);
        isGrounded = hit.collider != null;
        Debug.Log("isGrounded: " + isGrounded + " | hit: " + (hit.collider != null ? hit.collider.name : "null") + " | groundLayer: " + groundLayer.value);
    }
}
