using UnityEngine;

public class waypointCounter : MonoBehaviour
{

    public waypointCounter next;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        var vehicle = other.gameObject.GetComponent<VehicleController>();
        if (vehicle != null && vehicle.next == this)
        {
            vehicle.next = this.next;
            Debug.Log("bruh");
        }
        //Debug.Log("trigger enter " + other.transform.name);
    }

}
