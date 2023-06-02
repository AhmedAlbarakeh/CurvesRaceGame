using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollision : MonoBehaviour
{
   
   bool collide = false;
   float timer = 0;
   readonly float duration = 1.5f; //one second
   
    void OnTriggerEnter2D(Collider2D col){
      if(GameManager.IsLevelEnded()==false&&GameManager.IsGameEnded()==false){
         if(col.CompareTag("EndLevel0")){
                // Debug.Log("Head Collide -EndLevel0");
                GameManager.setEndLevelFlag(true);
                FindObjectOfType<EndLevelController>().endLevel();
          
            return;
       }

       if(!collide && col.CompareTag("Ground"))
        {
          collide = true;
          timer = 0;
        }
      }
      
     }

     void FixedUpdate()
     { 
      if(GameManager.IsLevelEnded()==false&&GameManager.IsGameEnded()==false){
        if(collide)
      {
        timer+=Time.fixedDeltaTime/2;
        if(timer>=duration)
          {
               //a second has passed so do something
                FindObjectOfType<GameManager>().setReasonOfOver(true);
              FindObjectOfType<GameManager>().EndGame();
              GameManager.setEndGameFlag(true);
          }
      }
    }

 }
  
}
