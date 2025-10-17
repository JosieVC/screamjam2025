using UnityEngine;

public class conveyorMove : MonoBehaviour
{
    //speed at which objects move
    [SerializeField]
    private int speed = 5;
    private Rigidbody2D rBody;

    [SerializeField]
    Vector3 velocity;

    [SerializeField]
    Vector3 position;

    //it'll only ever be moving right
    Vector3 direction = Vector3.right;

    private Vector3 offset;
    private float zCoord;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //adjust velocity and move object appropriately
        velocity = direction * speed;
        position = transform.position;
        position += velocity * Time.fixedDeltaTime;
        rBody.MovePosition(position);
    }

    void OnMouseDown()
    {
        zCoord = Camera.main.WorldToScreenPoint(this.transform.position).z;
        offset = this.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + offset;
    }
}
