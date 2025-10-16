using UnityEngine;
using static UnityEngine.UI.Image;

public class player : MonoBehaviour
{
    [SerializeField]
    private Sprite relaxed;
    [SerializeField]
    private Sprite grab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = relaxed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
