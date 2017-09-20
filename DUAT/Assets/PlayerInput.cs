using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{ 
    /// <summary>
    /// Master input manager 
    /// </summary>

    public PlayerMovementManager movementManager;
    public FormManager formManager;

	// Use this for initialization
	void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetAxis("Jump") > 0)
        {
            movementManager.Jump();
        }
        if(Input.GetAxis("Dash") > 0)
        {
            movementManager.Dash(Input.GetAxis("Horizontal"));
        }
        if(Input.GetAxis("Khepri Swap") != 0 && !formManager.khepriForm)
        {
            formManager.ChangeForm("Khepri");
        }
        if (Input.GetAxis("Khnum Swap") != 0 && !formManager.khnumForm)
        {
            formManager.ChangeForm("Khnum");
        }
        if (Input.GetAxis("Ra Swap") != 0 && !formManager.raForm)
        {
            formManager.ChangeForm("Ra");
        }
        if(Input.GetAxis("Osiris Swap") != 0 && !formManager.osirisForm)
        {
            formManager.ChangeForm("Osiris");
        }
    }
}
