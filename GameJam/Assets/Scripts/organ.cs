using UnityEngine;

public class organ : MonoBehaviour
{
    [SerializeField]
    private Sprite origin;
    [SerializeField]
    private Sprite final;
    [SerializeField]
    private Sprite decay;

    private conveyorMove conveyorComponent;
    private bool onConveyor;

    /// <summary>
    /// Sets bool for whether or not the organ is on the conveyor belt.
    /// </summary>
    public bool OnConveyor
    {
        get { return onConveyor; }
        set {
            conveyorComponent.enabled = value;
            onConveyor = value;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Makes the default sprite "origin"
        GetComponent<SpriteRenderer>().sprite = origin;
        conveyorComponent = GetComponent<conveyorMove>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Makes the organ completed.
    /// </summary>
    public void Build()
    {
        GetComponent<SpriteRenderer>().sprite = final;
    }

    /// <summary>
    /// Makes the organ failed.
    /// </summary>
    public void Fail()
    {
        GetComponent<SpriteRenderer>().sprite = decay;
    }
}
