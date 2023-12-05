using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PopUp : MonoBehaviour
{
    [SerializeField]
    Canvas messageCanvas;
 
   void Start()
   {
      messageCanvas.enabled = false;
   }
 
   void OnTriggerEnter2D(Collider2D other)
   {
      if (other.name == "Robot")
      {
        TurnOnMessage();
      }
   }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "Robot")
        {
            TurnOnMessage();
        }
    }

    private void TurnOnMessage()
   {
      messageCanvas.enabled = true;
   }
  
   void OnTriggerExit2D(Collider2D other)
   {
      if (other.name == "Robot")
        {
            TurnOffMessage();
        }
   }
 
   private void TurnOffMessage()
   {
        messageCanvas.enabled = false;
      
      //Destroy(this.gameObject, 5.0f);
   }
}
