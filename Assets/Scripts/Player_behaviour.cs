using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_behaviour : MonoBehaviour {

    // Use this for initialization
    GameObject Pickable;
    public GameObject Right_Hand;


    bool temp= true;
	
	// Update is called once per frame

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("garbage"))
        {
            Debug.Log("entered");
            Debug.Log(Pickable);
            Pickable = other.gameObject;
            Debug.Log(Pickable);

            if (temp)
            {
                temp = false;
                Pickable.transform.SetParent(Right_Hand.transform); // now pickable moves relative to hand
                Pickable.transform.position = Right_Hand.transform.position; // bring the pickable close to hand
                Pickable.GetComponent<Collider>().enabled = false;  // so it doesn't mess with anything else

            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bin"))
        {
            Debug.Log(Pickable);
            Destroy(Pickable);
            Debug.Log(Pickable);
        }
        
    }



    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("garbage"))
        {
            Debug.Log("left");
            Pickable = null;

            temp = true;

        }
    }
}
