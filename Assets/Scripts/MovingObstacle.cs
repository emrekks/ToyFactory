using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public float movementSpeed = 2.0f;
    public float upperLimit = 3.0f;
    public float lowerLimit = -3.0f;

    private bool moveUp = true;

    private void Update()
    {
        if (transform.position.y >= upperLimit)
        {
            moveUp = false;
        }
        else if (transform.position.y <= lowerLimit)
        {
            moveUp = true;
        }

        if (moveUp)
        {
            transform.Translate(Vector3.up * movementSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.down * movementSpeed * Time.deltaTime);
        }
    }
}
