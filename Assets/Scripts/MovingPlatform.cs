using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 1f;
    public bool moveVertically = true;
    public float verticalRange = 2f;
    public bool moveHorizontally = false;
    public float horizontalRange = 2f;

    private Vector3 startPosition;
    private Rigidbody rb;

    private void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float verticalMovement = moveVertically ? Mathf.Sin(Time.time * speed) * verticalRange : 0f;
        float horizontalMovement = moveHorizontally ? Mathf.Sin(Time.time * speed) * horizontalRange : 0f;
        Vector3 movement = new Vector3(horizontalMovement, verticalMovement, 0f);
        rb.MovePosition(startPosition + movement);
    }
}
