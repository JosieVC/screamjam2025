using System.Collections.Generic;
using UnityEngine;

public class assemblyManager : MonoBehaviour
{
    [SerializeField]
    private GameObject boxPrefab;

    private List<GameObject> boxes;
    private List<Vector3> boxPositions;
    public static int money;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Adds a list of boxes.
        boxes = new List<GameObject>();
        for (int i = 0; i < 5; i++)
        {
            boxes.Add(Instantiate(boxPrefab));
            boxes[i].GetComponent<box>().AssignBox(i);
        }
        AddPositions();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Add the positions to each box.
    /// </summary>
    private void AddPositions()
    {
        boxPositions = new List<Vector3>();
        boxPositions.Add(new Vector3(-6.49f, -1.34f, 9f));
        boxPositions.Add(new Vector3(-7.07f, -2.37f, 8f));
        boxPositions.Add(new Vector3(-7.91f, -3.87f, 7f));
        boxPositions.Add(new Vector3(-2.91f, -2.01f, 6f));
        boxPositions.Add(new Vector3(-3.31f, -3.28f, 5f));

        for (int i = 0; i < 5; i++)
        {
            boxes[i].transform.position = boxPositions[i];
        }
    }
}
