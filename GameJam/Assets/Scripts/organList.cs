using UnityEngine;

public class organList : MonoBehaviour
{
    static int brainCost;
    static int heartCost;
    static int lungCost;
    static int stomachCost;
    static int skinCost;

    [SerializeField]
    TextMesh organText; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetCost()
    {
        //find a way to slowly increment cost per day (values are up to you here)
        //update text appropriately with new costs (use the organText text mesh)
    }
}
