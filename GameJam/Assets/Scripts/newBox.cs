using UnityEngine;
using UnityEngine.InputSystem;

public class newBox : MonoBehaviour
{
    [SerializeField]
    private GameObject boltPrefab;
    [SerializeField]
    private GameObject screwPrefab;
    [SerializeField]
    private GameObject pipePrefab;
    [SerializeField]
    private GameObject meshPrefab;
    [SerializeField]
    private GameObject chipPrefab;

    [SerializeField]
    private Sprite boltBox;
    [SerializeField]
    private Sprite screwBox;
    [SerializeField]
    private Sprite pipeBox;
    [SerializeField]
    private Sprite meshBox;
    [SerializeField]
    private Sprite chipBox;

    private Collider2D collider;
    private GameObject part;
    private int numOfParts;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPos.z = 0f;

            if (collider.OverlapPoint(worldPos) && numOfParts > 0)
            {
                Instantiate(part, worldPos, Quaternion.identity);
                numOfParts--;
            }
        }
    }

    /// <summary>
    /// Assigns box sprite and what GameObject it creates.
    /// </summary>
    /// <param name="num"></param>
    public void AssignBox(int num)
    {
        switch (num)
        {
            case 0:
                GetComponent<SpriteRenderer>().sprite = boltBox;
                part = boltPrefab;
                gameObject.tag = "bolt";
                numOfParts = partsManager.boltCount;
                break;
            case 1:
                GetComponent<SpriteRenderer>().sprite = screwBox;
                part = screwPrefab;
                gameObject.tag = "screw";
                numOfParts = partsManager.screwCount;
                break;
            case 2:
                GetComponent<SpriteRenderer>().sprite = pipeBox;
                part = pipePrefab;
                gameObject.tag = "pipe";
                numOfParts = partsManager.pipeCount;
                break;
            case 3:
                GetComponent<SpriteRenderer>().sprite = meshBox;
                part = meshPrefab;
                gameObject.tag = "mesh";
                numOfParts = partsManager.meshCount;
                break;
            case 4:
                GetComponent<SpriteRenderer>().sprite = chipBox;
                part = chipPrefab;
                gameObject.tag = "chip";
                numOfParts = partsManager.chipCount;
                break;
        }
    }
}
