using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    [SerializeField]
    private TextMesh QuotaText;

    [SerializeField]
    private TextMesh TimerText;

    [SerializeField]
    private TextMesh recipeText;

    [SerializeField]
    private TextMesh partsText;

    [SerializeField]
    private GameObject cbPrefab;

    [SerializeField]
    private float timeGap;
    private float newTime;
    public static int day;
    private List<GameObject> cbParts;
    private bool isGenerated;

    private float timer;

    enum QuotaType
    {
        Heart,
        Lungs,
        Brain,
        Stomach,
        Skin
    }

    QuotaType quotaType;

    int quotaNum;

    //stores all of the quotas for easy access
    Dictionary<QuotaType, int> quotaDict = new Dictionary<QuotaType, int>();

    #region recipes
    string heartRecipe = "heart: 2 bolts, 1 screw, 4 pipes, 1 chip";
    string lungRecipe = "lung: 2 mesh, 1 pipe, 3 screws, 1 chip";
    string brainRecipe = "brain: 3 mesh, 3 chips";
    string stomachRecipe = "stomach: 2 pipes, 3 screws, 1 bolt, 1 chip";
    string skinRecipe = "skin: 5 mesh, 1 chip";
    #endregion 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Screen.SetResolution(2560, 1600, 0);
        timer = 300;
        newTime = 300;
        day = 1;
        cbParts = new List<GameObject>();
        FindAllCB();
    }

    // Update is called once per frame
    void Update()
    {
        TimerText.text = timer.ToString("F2");

        timer -= Time.deltaTime;

        if (newTime - timer >= timeGap)
        {
            newTime = timer;
            SpawnCB();
        }

        if(isGenerated == false)
        {
            GenerateQuota();
            ReadQuota();
            PrintRecipes();
            isGenerated = true;
        }

        if(timer < 0)
        {
            SceneManager.LoadScene("Day End");
            newTime = timer;
            timer = 300;
            isGenerated = false;
        }

        if (cbParts.Count > 6)
        {
            Destroy(cbParts[0]);
        }

    }

    //generates the correct quota based on the day
    void GenerateQuota()
    {
        if(day == 1)
        {
            quotaDict.Add(QuotaType.Heart, 3);
        }
        if (day == 2)
        {
            quotaDict.Add(QuotaType.Stomach, 2);
        }
        if(day == 3)
        {
            quotaDict[QuotaType.Heart] = 4;
            quotaDict[QuotaType.Stomach] = 3;
            quotaDict.Add(QuotaType.Brain, 1);
        }
        if(day == 4)
        {
            quotaDict.Add(QuotaType.Lungs, 2);
        }
        if(day == 5)
        {
            quotaDict.Add(QuotaType.Skin, 1);
        }
        if(day == 6)
        {
            quotaDict[QuotaType.Heart]++;
            quotaDict[QuotaType.Stomach]++;
            quotaDict[QuotaType.Brain]++;
            quotaDict[QuotaType.Lungs] += 2;
            quotaDict[QuotaType.Skin]++;
        }
        if(day > 6 && (day % 3 == 0))
        {
            quotaDict[QuotaType.Heart]++;
            quotaDict[QuotaType.Stomach]++;
            quotaDict[QuotaType.Brain]++;
            quotaDict[QuotaType.Lungs] += 2;
            quotaDict[QuotaType.Skin]++;
        }
    }

    //TODO: Bug fix needed here - right now this only prints out the last element read from the dictionary
    //We need it to read out every element of the dictionary
    void ReadQuota()
    {
        QuotaText.text = "Quota \n";


        foreach(KeyValuePair<QuotaType, int> entry in quotaDict)
        {
            QuotaText.text = entry.Key.ToString() + ": " + entry.Value.ToString() + "\n";
        }
    }

    //prints out all of the avaialable recipes
    void PrintRecipes()
    {
        if (day == 1)
        {
            recipeText.text = heartRecipe;
        }
        if (day == 2)
        {
            recipeText.text = heartRecipe + "\n" +
                stomachRecipe;

        }
        if (day == 3)
        {
            recipeText.text = heartRecipe + "\n" +
                stomachRecipe + "\n" +
                brainRecipe;
        }
        if (day == 4)
        {
            recipeText.text = heartRecipe + "\n" +
                stomachRecipe + "\n" +
                brainRecipe + "\n" +
                lungRecipe;
        }
        if (day >= 5)
        {
            recipeText.text = heartRecipe + "\n" +
                stomachRecipe + "\n" +
                brainRecipe + "\n" +
                lungRecipe + "\n" +
                skinRecipe;
        }
    }

    /// <summary>
    /// Spawns new converyor belt section.
    /// </summary>
    private void SpawnCB()
    {
        GameObject newCB = Instantiate(cbPrefab, new Vector3(-13.66f, -2.83f, 4f), Quaternion.identity);
        cbParts.Add(newCB);
    }

    /// <summary>
    /// Finds all the conveyor belt parts.
    /// </summary>
    private void FindAllCB()
    {
        cbParts.Clear(); // clear old references first
        GameObject[] foundParts = GameObject.FindGameObjectsWithTag("CB");

        foreach (GameObject part in foundParts)
        {
            cbParts.Add(part);
        }
    }
}
