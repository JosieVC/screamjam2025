using UnityEngine;
using UnityEngine.UI; // Required for Toggle
using TMPro; // Optional if you want to update label text

public class checkbox : MonoBehaviour
{
    public string organName; // Set this in the Inspector (e.g. "Brain", "Heart")

    private Toggle toggle;

    void Start()
    {
        toggle = GetComponent<Toggle>();

        if (toggle != null)
        {
            toggle.onValueChanged.AddListener(OnToggleChanged);
        }
    }

    void OnToggleChanged(bool isOn)
    {
        int organCost = GetOrganCost();

        if (isOn)
        {
            // Trying to activate organ — check if we can afford it
            if (assemblyManager.money >= organCost)
            {
                assemblyManager.money -= organCost;
                SetOrganState(false); // Organ is now working
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
            SetOrganState(true); // Organ is now failing
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
            case "Stomach": return organList.stomachCost;
            case "Skin": return organList.skinCost;
            default: return 0;
        }
    }

    void SetOrganState(bool failing)
    {
        switch (organName)
        {
            case "Brain": playerControl.brainFailing = failing; break;
            case "Heart": playerControl.heartFailing = failing; break;
            case "Lungs": playerControl.lungFailing = failing; break;
            case "Stomach": playerControl.stomachFailing = failing; break;
            case "Skin": playerControl.skinFailing = failing; break;
        }

        playerControl.aliveOrgans += failing ? -1 : 1;
    }
}

