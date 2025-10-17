using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneSwitcher : MonoBehaviour

{
    [SerializeField] private string sceneA = "Assembly";
    [SerializeField] private string sceneB = "Factory";

    private Collider2D col;

    void Start()
    {
        col = GetComponent<Collider2D>();
        if (col == null)
        {
            Debug.LogError("ToggleSceneButton requires a 2D Collider!");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f;

            if (col != null && col.OverlapPoint(mouseWorldPos))
            {
                string currentScene = SceneManager.GetActiveScene().name;
                if (currentScene == sceneA)
                    SceneManager.LoadScene(sceneB);
                else if (currentScene == sceneB)
                    SceneManager.LoadScene(sceneA);
            }
        }
    }
}
