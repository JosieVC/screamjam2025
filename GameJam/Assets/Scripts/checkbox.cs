using UnityEngine;

public class checkbox : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ActivateCheckbox()
    {
        //check for collision with checkbox
        //if mouse is in the right location, activate or deactivate the checkbox
        //if the checkbox is deactivated, mark that organ as deactivated (use playerControl.organFailing = true and playerControl.aliveOrgans--)
        //if the checkbox is activated, subtract money according to the cost of the organ (assemblyManager.money and organList.organCost (for the respective organ)
        //if that organ was deactivated, reactivate it
    }
}
