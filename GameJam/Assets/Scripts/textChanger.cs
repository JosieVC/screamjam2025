using UnityEngine;

public class textChanger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    TextMesh textMesh;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(textMesh.tag == "bolt")
        {
            textMesh.text = "Bolts: " + partsManager.boltCount.ToString();
        }
        if (textMesh.tag == "screw")
        {
            textMesh.text = "Screws: " + partsManager.screwCount.ToString();
        }
        if (textMesh.tag == "pipe")
        {
            textMesh.text = "Pipes: " + partsManager.pipeCount.ToString();
        }
        if (textMesh.tag == "chip")
        {
            textMesh.text = "Chips: " + partsManager.chipCount.ToString();
        }
        if (textMesh.tag == "mesh")
        {
            textMesh.text = "Mesh: " + partsManager.meshCount.ToString();
        }
    }
}
