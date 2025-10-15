using UnityEngine;

public class playerControl : MonoBehaviour
{
    private Vector2 mousePosition;

    [SerializeField]
    private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        player.transform.position = mousePosition;

    }

}
