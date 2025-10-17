using UnityEngine;
using UnityEngine.SceneManagement;

public class playerControl : MonoBehaviour
{
    private Vector2 mousePosition;

    [SerializeField]
    private GameObject player;

    enum LifeState
    {
        Normal,
        Decaying,
        Dying,
        Dead
    }

    LifeState lifeState; 

    public static int aliveOrgans;

    public static bool brainFailing;

    public static bool heartFailing;

    public static bool lungsFailing;

    public static bool skinFailing;

    public static bool stomachFailing;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
            aliveOrgans = 5;
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        player.transform.position = mousePosition;

        if (aliveOrgans == 5)
        {
            lifeState = LifeState.Normal;
        }
        if(aliveOrgans >= 2 && aliveOrgans <= 4)
        {
            lifeState = LifeState.Decaying;
        }
        if(aliveOrgans < 2 && aliveOrgans > 0)
        {
            lifeState = LifeState.Dying;
        }
        if(aliveOrgans == 0)
        {
            lifeState = LifeState.Dead;
        }

        switch (lifeState)
        {
            case LifeState.Normal:
                break;
            case LifeState.Decaying:
                break;
            case LifeState.Dying:
                break;
            case LifeState.Dead:
                SceneManager.LoadScene("Game Over");
                break;
            default:
                break;
        }
    }

}
