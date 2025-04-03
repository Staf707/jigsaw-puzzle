using UnityEngine;

public class CanvasSlider : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the object movement
    public float damping = 5f;  // Damping factor to smooth the movement

    private Vector3 lastMousePosition;
    private float currentVelocity = 0f; // Current velocity of the object

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastMousePosition = Input.mousePosition; // Initialize the last mouse position
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = 0f;

        if (Input.GetMouseButton(0)) // Check if the left mouse button is held down
        {
            Vector3 currentMousePosition = Input.mousePosition;
            deltaX = currentMousePosition.x - lastMousePosition.x;

            lastMousePosition = currentMousePosition; // Update the last mouse position
        } else{ lastMousePosition = Input.mousePosition; }

        // Smoothly update the velocity
        currentVelocity = Mathf.Lerp(currentVelocity, deltaX * moveSpeed, Time.deltaTime * damping);

        // Move the object horizontally based on the velocity
        transform.Translate(currentVelocity * Time.deltaTime, 0, 0);
    }
}
