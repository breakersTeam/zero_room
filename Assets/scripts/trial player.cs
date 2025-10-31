using UnityEngine;

public class trialplayer : MonoBehaviour
{
    public Rigidbody2D rb;
    void Update()
    {
        rb.linearVelocity = new Vector2(Input.GetAxis("Horizontal"), rb.linearVelocityY);
        
    }
}
