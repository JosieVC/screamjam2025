using UnityEngine;

public class partsText : MonoBehaviour
{
    [SerializeField]
    TextMesh partText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        partText.text = "Bolts: " + partsManager.boltCount + "\n"
            + "Screws" + partsManager.screwCount + "\n"
            + "Pipes" + partsManager.pipeCount + "\n"
            + "Chips" + partsManager.chipCount;
    }
}
