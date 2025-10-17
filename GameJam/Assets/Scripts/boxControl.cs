using UnityEngine;

public class boxControl : MonoBehaviour
{
    //determines which part the box accepts
    //1 is bolt, 2 is screw, 3 is pipe, 4 is chip
    [SerializeField, Range(1, 4)]
    private int boxNum;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //checks to see if the right part is being placed in the box
    void CheckBox(GameObject incomingPart)
    {
        switch (boxNum)
        {
            case 1:
                //checks type of part, makes sure it aligns with box part
                if (incomingPart.tag == "bolt")
                {
                    //increments respective part count appropriately
                    partsManager.boltCount++;
                }
                break;
            case 2:
                if(incomingPart.tag == "screw")
                {
                    partsManager.screwCount++;
                }
                break;
            case 3:
                if(incomingPart.tag == "pipe")
                {
                    partsManager.pipeCount++;
                }
                break;
            case 4:
                if( incomingPart.tag == "chip")
                {
                    partsManager.chipCount++;
                }
                break;
            case 5:
                if (incomingPart.tag == "mesh")
                {
                    partsManager.meshCount++;
                }
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check part & destroy object - if it's the wrong box, too bad!
        CheckBox(collision.gameObject);
        Destroy(collision.gameObject);
    }
}
