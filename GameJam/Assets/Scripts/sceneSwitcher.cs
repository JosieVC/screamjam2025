using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneSwitcher : MonoBehaviour

{
    private Vector2 mousePosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) && mousePosition.x > 6 && mousePosition.x < 10 && mousePosition.y > -3.8 && mousePosition.y < -2.5)
        {
            SceneManager.LoadScene("Assembly");
        }
        else if (SceneManager.GetActiveScene().name == "Assembly" && 
            Input.GetMouseButtonDown(0) && mousePosition.x > -3.8 && mousePosition.x < -0.2 && mousePosition.y > -4.5 && mousePosition.y < -3.6)
        {
            SceneManager.LoadScene("Factory");
        }
    }
}
