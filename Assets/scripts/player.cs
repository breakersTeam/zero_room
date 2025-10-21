using UnityEngine;

public class player : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;

    [Header("References")]
    public Camera mainCamera;
    public Animator animator; // optional

    public Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 mousePos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (mainCamera == null)
            mainCamera = Camera.main;
    }

    void Update()
    {
        // --- Movement input ---
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // --- Look toward mouse ---
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        // --- Optional animation parameters ---
        if (animator)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
    }

    void FixedUpdate()
    {
        // --- Apply movement ---
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);

        // --- Rotate to face mouse ---
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
