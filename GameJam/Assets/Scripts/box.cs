using UnityEngine;
using static UnityEngine.UI.Image;

public class box : MonoBehaviour
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
    private int num = 0;

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

    private GameObject part;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AssignBox(num);
    }

    // Update is called once per frame
    void Update()
    {
        
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
                break;
            case 1:
                GetComponent<SpriteRenderer>().sprite = screwBox;
                part = screwPrefab;
                break;
            case 2:
                GetComponent<SpriteRenderer>().sprite = pipeBox;
                part = pipePrefab;
                break;
            case 3:
                GetComponent<SpriteRenderer>().sprite = meshBox;
                part = meshPrefab;
                break;
            case 4:
                GetComponent<SpriteRenderer>().sprite = chipBox;
                part = chipPrefab;
                break;
        }
    }
}
