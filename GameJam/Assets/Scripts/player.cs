using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    [SerializeField] private Sprite relaxed;
    [SerializeField] private Sprite grab;

    [SerializeField]
    private float maxY;

    private SpriteRenderer sr;

    private bool isGrabbing = false;

    // Offset so mouse is top-left of the hand
    private Vector3 handOffset = new Vector3(2.8f, -1f, 0f);

    // Additional small grab offset
    private Vector3 grabOffset = new Vector3(0.16f, -0.4f, 0f);

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = relaxed;
    }

    void Update()
    {
        // Get mouse position in world space
        Vector3 mousePos = Mouse.current.position.ReadValue();
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        worldPos.z = 0f;

        // Clamp Y axis
        if (worldPos.y >= maxY) 
        { 
            worldPos.y = maxY; 
        }

        // Start with mouse + hand offset
        Vector3 finalPos = worldPos + handOffset;

        // Apply grabbing offset if grabbing
        if (isGrabbing)
            finalPos += grabOffset;

        transform.position = finalPos;
    }

    /// <summary>
    /// When attack button is pressed, the hand grabs.
    /// </summary>
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            sr.sprite = grab;
            isGrabbing = true;
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            sr.sprite = relaxed;
            isGrabbing = false;
        }
    }
}
