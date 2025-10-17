using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DayEndManager : MonoBehaviour
{
    [Header("UI References")]
    public TextMesh dayCounterText;
    public TextMesh moneyCounterText;

    [Header("Organ Costs")]
    public int brainCost = 10;
    public int heartCost = 15;
    public int lungsCost = 12;
    public int stomachCost = 8;
    public int skinCost = 5;

    private int earnedMoney = 30; // TEMP — replace with actual gameplay value later

    [Header("Organ Checkboxes")]
    public Toggle brainCheckbox;
    public Toggle heartCheckbox;
    public Toggle lungsCheckbox;
    public Toggle stomachCheckbox;
    public Toggle skinCheckbox;

    public Button newDayButton;

    private void Start()
    {
        int currentDay = 1; // Will later be pulled from another script

        // Assigns values for other scripts
        organList.brainCost = brainCost;
        organList.heartCost = heartCost;
        organList.lungCost = lungsCost;
        organList.stomachCost = stomachCost;
        organList.skinCost = skinCost;

        assemblyManager.money = assemblyManager.moneyEarnedToday;
        moneyCounterText.text = $"Money Earned: {assemblyManager.money}"; // gives the player their earnings to spend

        // Updates UI
        dayCounterText.text = $"End of Day {currentDay}";
        moneyCounterText.text = $"Money Earned: {earnedMoney}";

        // Initializes all checkboxes ON
        brainCheckbox.isOn = true;
        heartCheckbox.isOn = true;
        lungsCheckbox.isOn = true;
        stomachCheckbox.isOn = true;
        skinCheckbox.isOn = true;

        // Adds button listener
        newDayButton.onClick.AddListener(OnNextDay);
    }

   private void OnNextDay()
{
    sceneManager.day++; // Progress to the next day
    SceneManager.LoadScene("Factory");
}
}

