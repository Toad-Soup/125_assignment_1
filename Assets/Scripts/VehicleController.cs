using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class VehicleController : MonoBehaviour
{
    public float desired_acceleration;
    public float power;

    //next waybpoint
    public waypointCounter next;
    public waypointCounter target;

    //ui stuffs 
    public float starttime;
    public TextMeshProUGUI timelbl;
    public TextMeshProUGUI lap_label;

    //lap stuffs
    public int lap_counter = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //make player slide less
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.linearDamping = 2;

        //change color of the first waypoint at the bginning of the game
        target.left.materials[0].color = Color.red;
        target.right.materials[0].color = Color.red;

        //more ui stuffs
        starttime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().AddRelativeForce(desired_acceleration*power, 0, 0);
        float dx = (Mouse.current.position.x.value - Screen.width / 2) / 200;
        if (Mathf.Abs(dx) > 0.01f)
        {
            transform.Rotate(0, dx, 0);
        }

        //calculate time ui stuffs
        timelbl.text = string.Format("Current time: {0:F2} seconds", (Time.time - starttime));
    }

    void OnMove(InputValue value)
    {
        Vector2 movement = value.Get<Vector2>();
        desired_acceleration = movement.y;
    }

    public void updateLap()
    {
        //update the counter and diplay text
        lap_counter ++;
        lap_label.text = $"Laps Completed: {lap_counter}";
    }
}
