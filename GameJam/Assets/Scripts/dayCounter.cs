using UnityEngine;

public class dayCounter : MonoBehaviour
{
    [SerializeField]
    TextMesh DayCounter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DayCounter.text = "End of Day " + sceneManager.day; 
    }
}
