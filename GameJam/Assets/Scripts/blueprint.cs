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
        if (organ != null)
        {
            organ.SetActive(false);
        }
        switch (num)
        {
            case 0:
                GetComponent<SpriteRenderer>().sprite = brainBPPrefab;
                organ = FindInactiveByTag("brain");
                break;
            case 1:
                GetComponent<SpriteRenderer>().sprite = stomachBPPrefab;
                organ = FindInactiveByTag("stomach");
                break;
            case 2:
                GetComponent<SpriteRenderer>().sprite = lungsBPPrefab;
                organ = FindInactiveByTag("lung");
                break;
            case 3:
                GetComponent<SpriteRenderer>().sprite = skinBPPrefab;
                organ = FindInactiveByTag("skin");
                break;
            case 4:
                GetComponent<SpriteRenderer>().sprite = heartBPPrefab;
                organ = FindInactiveByTag("heart");
                break;
        }

        if (organ != null)
        {
            organ.SetActive(true);
            Debug.Log($"Activated organ: {organ.name}");
        }
        else
        {
            Debug.LogWarning("No GameObject found with the expected tag!");
        }
    }

    /// <summary>
    /// Finds inactive tag.
    /// </summary>
    /// <param name="tag"></param>
    /// <returns></returns>
    private GameObject FindInactiveByTag(string tag)
    {
        foreach (GameObject obj in Resources.FindObjectsOfTypeAll<GameObject>())
        {
            if (obj.CompareTag(tag))
                return obj;
        }
        return null;
    }
}
