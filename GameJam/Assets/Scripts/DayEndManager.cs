using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro; 

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

    [Header("Organ Checkboxes")]
    public Toggle brainCheckbox;
    public Toggle heartCheckbox;
    public Toggle lungsCheckbox;
    public Toggle stomachCheckbox;
    public Toggle skinCheckbox;

    [Header("Organ Labels")]
    public TMP_Text brainLabel;
    public TMP_Text heartLabel;
    public TMP_Text lungsLabel;
    public TMP_Text stomachLabel;
    public TMP_Text skinLabel;

    [Header("UI Buttons")]
    public Button newDayButton;

    private void Start()
    {
        int currentDay = sceneManager.day;

        // Assign costs for use by other scripts
        organList.brainCost = brainCost;
        organList.heartCost = heartCost;
        organList.lungCost = lungsCost;
        organList.stomachCost = stomachCost;
        organList.skinCost = skinCost;

        // Set player's money for spending
        // This should ideally be the real value earned from the gameplay
        assemblyManager.money = 30; // TEMP VALUE

        // Update UI text
        dayCounterText.text = $"End of Day {currentDay}";
        moneyCounterText.text = $"Money Earned: {assemblyManager.money}";

        // Update label texts with names and costs
        brainLabel.text = $"Brain (${brainCost})";
        heartLabel.text = $"Heart (${heartCost})";
        lungsLabel.text = $"Lungs (${lungsCost})";
        stomachLabel.text = $"Stomach (${stomachCost})";
        skinLabel.text = $"Skin (${skinCost})";

        // Set all checkboxes on by default
        brainCheckbox.isOn = true;
        heartCheckbox.isOn = true;
        lungsCheckbox.isOn = true;
        stomachCheckbox.isOn = true;
        skinCheckbox.isOn = true;

        // Button listener to proceed to next day
        newDayButton.onClick.AddListener(OnNextDay);
    }

    private void OnNextDay()
    {
        sceneManager.day++;
        SceneManager.LoadScene("Factory");
    }
}


