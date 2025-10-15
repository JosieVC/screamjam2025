using UnityEngine;

public class spawnManager : MonoBehaviour
{
    //serialized fields for all of the parts to assign prefabs
    [SerializeField]
    private GameObject bolt;
    [SerializeField]
    private GameObject screw;
    [SerializeField]
    private GameObject pipe;
    [SerializeField]
    private GameObject chip;
    //the location parts will spawn at - should be left side of screen
    [SerializeField]
    private Vector2 spawnLoc;

    //variable to hold currently spawned obj
    GameObject currentSpawn;
    //timer to delay spawns
    [SerializeField]
    float timer;

    void Start()
    {
        //timer set to 2 seconds
        timer = 2;
    }

    // Update is called once per frame
    void Update()
    {
        //decrease time continually
        timer -= Time.deltaTime;

        //if timer runs out, generate a new object
        if (timer < 0)
        {
            GenerateSpawnObject();
            //reset timer
            timer = 2;
        }
        
    }

    //generate a new object to spawn & spawn it
    void GenerateSpawnObject()
    {
        //picks which object will be spawned
        int spawnNum = Random.Range(0, 4);
        
        //sets currentSpawn to appropriate prefab
        switch (spawnNum)
        {
            case 0:
                currentSpawn = bolt;
                break;
            case 1:
                currentSpawn = screw;
                break;
            case 2:
                currentSpawn = pipe;
                break;
            case 3:
                currentSpawn = chip;
                break;
            default:
                break;
        }

        //creates the new object
        Instantiate(currentSpawn, spawnLoc, Quaternion.identity);
    }
}
