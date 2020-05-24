using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    public GameObject level;
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    /*  public GameObject object4;
      public GameObject object5;
      public GameObject object6;
  */
    private void Start()
    {
        level.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {            
            object1.SetActive(false);
            object2.SetActive(false);
            object3.SetActive(false);
            level.SetActive(true);
        }
    }
}
