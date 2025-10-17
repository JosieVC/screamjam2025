using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class blueprint : MonoBehaviour
{
    [SerializeField]
    private Sprite brainBPPrefab;
    [SerializeField]
    private Sprite stomachBPPrefab;
    [SerializeField]
    private Sprite lungsBPPrefab;
    [SerializeField]
    private Sprite skinBPPrefab;
    [SerializeField]
    private Sprite heartBPPrefab;

    [SerializeField]
    private GameObject brain;
    [SerializeField]
    private GameObject stomach;
    [SerializeField]
    private GameObject lungs;
    [SerializeField]
    private GameObject skin;
    [SerializeField]
    private GameObject heart;

    private GameObject organ;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeOrgan()
    {

    }

    /// <summary>
    /// Sets which blueprint it displays.
    /// </summary>
    /// 
    /// <param name="num"></param>
    public void SetBlueprint(int num)
    {
        switch (num)
        {
            case 0:
                GetComponent<SpriteRenderer>().sprite = brainBPPrefab;
                //organ = brain;
                break;
            case 1:
                GetComponent<SpriteRenderer>().sprite = stomachBPPrefab;
                //organ = stomach;
                break;
            case 2:
                GetComponent<SpriteRenderer>().sprite = lungsBPPrefab;
                //organ = lungs;
                break;
            case 3:
                GetComponent<SpriteRenderer>().sprite = skinBPPrefab;
                //organ = skin;
                break;
            case 4:
                GetComponent<SpriteRenderer>().sprite = heartBPPrefab;
                //organ = heart;
                break;
        }
    }
}
