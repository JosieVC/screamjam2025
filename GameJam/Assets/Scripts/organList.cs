using UnityEngine;

public class organList : MonoBehaviour
{
    // Static organ costs (accessible from other scripts like DayEndManager)
    public static int brainCost = 10;
    public static int heartCost = 15;
    public static int lungCost = 12;
    public static int stomachCost = 8;
    public static int skinCost = 5;

    [SerializeField]
    private TextMesh organText; // Reference to the UI TextMesh that displays costs

    private int currentDay = 1; // This should eventually come from a global day counter

    void Start()
    {
        SetCost(); // Calculate costs and update UI
    }

    void SetCost()
    {
        // Increase costs slightly per day
        brainCost += currentDay * 2;
        heartCost += currentDay * 3;
        lungCost += currentDay * 2;
        stomachCost += currentDay * 1;
        skinCost += currentDay * 1;

        // Update the organ cost text in the scene
        organText.text =
            "Organ Costs:\n" +
            $"- Brain: ${brainCost}\n" +
            $"- Heart: ${heartCost}\n" +
            $"- Lungs: ${lungCost}\n" +
            $"- Stomach: ${stomachCost}\n" +
            $"- Skin: ${skinCost}";
    }
}
