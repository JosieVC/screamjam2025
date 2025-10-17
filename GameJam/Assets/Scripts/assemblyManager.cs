using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class assemblyManager : MonoBehaviour
{
    [SerializeField]
    private GameObject boxPrefab;
    [SerializeField]
    private GameObject notePad;
    [SerializeField]
    private GameObject notePadButton;
    [SerializeField]
    private GameObject brainButton;
    [SerializeField]
    private GameObject stomachButton;
    [SerializeField]
    private GameObject lungsButton;
    [SerializeField]
    private GameObject skinButton;
    [SerializeField]
    private GameObject heartButton;
    [SerializeField]
    private GameObject blueprintPrefab;

    private List<GameObject> boxes;
    private List<Vector3> boxPositions;
    private List<Vector3> buttonPositions;
    public static int money;
    private GameObject currentBlueprint;

    private Vector3 buttonStartPos = new Vector3(6.11f, 4.1f, 3f);
    private Vector3 notePadStartPos = new Vector3(5.96f, 10.93f, 2f);
    private Vector3 notePadDropPos = new Vector3(5.96f, -0.54f, 2f);
    private bool isNotePadDropped = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Screen.SetResolution(2560, 1600, 0);
        // Adds a list of boxes.
        boxes = new List<GameObject>();
        for (int i = 0; i < 5; i++)
        {
            boxes.Add(Instantiate(boxPrefab));
            boxes[i].GetComponent<box>().AssignBox(i);
        }
        AddBoxPositions();
        AddButtonPositions();
        PullUpButtons();

        // positions notepads.
        notePadButton.transform.position = buttonStartPos;
        notePad.transform.position = notePadStartPos;
    }

    // Update is called once per frame
    void Update()
    {
        // Get mouse position
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = 0f;

        if (Input.GetMouseButtonDown(0)) // old system
        {
            // Notepad button
            if (!isNotePadDropped)
            {
                Collider2D buttonCollider = notePadButton.GetComponent<Collider2D>();
                if (buttonCollider != null && buttonCollider.OverlapPoint(worldPos))
                {
                    notePad.transform.position = notePadDropPos;
                    DropDownButtons();
                    isNotePadDropped = true;
                    return;
                }
            }

            // Organ buttons
            GameObject[] buttons = { brainButton, stomachButton, lungsButton, skinButton, heartButton };
            for (int i = 0; i < buttons.Length; i++)
            {
                Collider2D col = buttons[i].GetComponent<Collider2D>();
                if (col != null && col.OverlapPoint(worldPos))
                {
                    OnOrganButtonPressed(i);
                    return;
                }
            }

            // Collapse notepad if clicked outside
            if (isNotePadDropped)
            {
                Collider2D notePadCollider = notePad.GetComponent<Collider2D>();
                if (notePadCollider != null && !notePadCollider.OverlapPoint(worldPos))
                {
                    notePad.transform.position = notePadStartPos;
                    PullUpButtons();
                    isNotePadDropped = false;
                }
            }
        }
    }


    /// <summary>
    /// Add the positions to each box.
    /// </summary>
    private void AddBoxPositions()
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

    /// <summary>
    /// Add positions to each button.
    /// </summary>
    private void AddButtonPositions()
    {
        buttonPositions = new List<Vector3>(); 
        buttonPositions.Add(new Vector3(4.07f, 2.5f, 1f)); 
        buttonPositions.Add(new Vector3(8.04f, 2.42f, 1f)); 
        buttonPositions.Add(new Vector3(4.19f, -0.71f, 1f)); 
        buttonPositions.Add(new Vector3(6.3f, -3.72f, 1f)); 
        buttonPositions.Add(new Vector3(8.15f, -0.97f, 1f)); 
        buttonPositions.Add(new Vector3(28f, 28f, 1f));
    }
    
    /// <summary>
    /// Shows the buttons.
    /// </summary>
    private void DropDownButtons()
    {
        brainButton.transform.position = buttonPositions[0];
        stomachButton.transform.position = buttonPositions[1];
        lungsButton.transform.position = buttonPositions[2];
        skinButton.transform.position = buttonPositions[3];
        heartButton.transform.position = buttonPositions[4];
    }

    /// <summary>
    /// Removes the buttons from the scene.
    /// </summary>
    private void PullUpButtons()
    {
        brainButton.transform.position = buttonPositions[5];
        stomachButton.transform.position = buttonPositions[5];
        lungsButton.transform.position = buttonPositions[5];
        skinButton.transform.position = buttonPositions[5];
        heartButton.transform.position = buttonPositions[5];
    }

    /// <summary>
    /// When one of the organ buttons is pressed.
    /// </summary>
    /// <param name="organIndex"></param>
    private void OnOrganButtonPressed(int organIndex)
    {
        // Collapse the notePad
        notePad.transform.position = notePadStartPos;
        PullUpButtons();
        isNotePadDropped = false;

        if (currentBlueprint == null)
        {
            currentBlueprint = Instantiate(blueprintPrefab, new Vector3(4f, -2.54f, 4f), Quaternion.identity);
        }
        // Set the blueprint to the correct organ
        currentBlueprint.GetComponent<blueprint>().SetBlueprint(organIndex);
        Debug.Log("Pressed organ: " + organIndex);
    }

    public static int moneyEarnedToday; 

}
