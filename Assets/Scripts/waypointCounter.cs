using UnityEngine;

public class waypointCounter : MonoBehaviour
{

    public waypointCounter next;
    public MeshRenderer left;
    public MeshRenderer right;

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
        if (vehicle == null) return;
        if (vehicle.next == this)
        {
            vehicle.next = this.next;
            next.left.materials[0].color = Color.red;
            next.right.materials[0].color = Color.red;
            left.materials[0].color = Color.white;
            right.materials[0].color = Color.white;
        }
        //Debug.Log("trigger enter " + other.transform.name);

        //need to check if the thing entered is the first waypoint (menaing one lap complete)
        if (vehicle.target == this.next)
        {
            Debug.Log("updating lap");
            vehicle.updateLap();
        }
    }

}
