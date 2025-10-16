using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DayEndManager : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI dayCounterText;
    public TextMeshProUGUI moneyCounterText;

    [Header("Organ Checkboxes")]
    public Toggle brainCheckbox;
    public Toggle heartCheckbox;
    public Toggle lungsCheckbox;
    public Toggle stomachCheckbox;
    public Toggle skinCheckbox;

    public Button newDayButton;

    private void Start()
    {
        // Example values (replace these with actual game data)
        int currentDay = 1;  // can get this from our dayCounter script later
        int earnedMoney = 0; // can connect this to our player or manager script

        // Update UI
        dayCounterText.text = $"End of Day {currentDay}";
        moneyCounterText.text = $"Money Earned: {earnedMoney}";

        // Checkboxes start all ON
        brainCheckbox.isOn = true;
        heartCheckbox.isOn = true;
        lungsCheckbox.isOn = true;
        stomachCheckbox.isOn = true;
        skinCheckbox.isOn = true;

        // When player clicks "Next Day"
        newDayButton.onClick.AddListener(OnNextDay);
    }

    private void OnNextDay()
    {
        // When pressed, loads next scene (replace name below)
        SceneManager.LoadScene("Factory");
    }
}
