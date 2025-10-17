using UnityEngine;
using UnityEngine.UI;

public class checkbox : MonoBehaviour
{
    [Header("Set this in Inspector")]
    public string organName; // Example: "Brain", "Heart"

    private Toggle toggle;
    private bool isInitialized = false; // To prevent counting aliveOrgans multiple times

    void Start()
    {
        toggle = GetComponent<Toggle>();

        if (toggle != null)
        {
            toggle.onValueChanged.AddListener(OnToggleChanged);
        }
        else
        {
            Debug.LogError("No Toggle component found on: " + gameObject.name);
        }

        // Initialize toggle state
        toggle.isOn = true;
        SetOrganState(false); // Organ is working by default
        isInitialized = true;
    }

    void OnToggleChanged(bool isOn)
    {
        if (!isInitialized) return;

        int organCost = GetOrganCost();

        if (isOn)
        {
            // Trying to activate organ — check if we can afford it
            if (assemblyManager.money >= organCost)
            {
                assemblyManager.money -= organCost;
                SetOrganState(false); // Organ is working
                Debug.Log($"{organName} activated. Remaining money: {assemblyManager.money}");
            }
            else
            {
                toggle.isOn = false; // Can't afford — revert
                Debug.Log("Not enough money to activate this organ!");
            }
        }
        else
        {
            // Deactivate organ
            SetOrganState(true); // Organ is failing
            Debug.Log($"{organName} deactivated.");
        }
    }

    int GetOrganCost()
    {
        switch (organName)
        {
            case "Brain": return organList.brainCost;
            case "Heart": return organList.heartCost;
            case "Lungs": return organList.lungCost;
            case "Stomach":
                return organList.stomachCo
