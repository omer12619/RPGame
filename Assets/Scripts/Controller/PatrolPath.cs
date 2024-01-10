using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;




namespace RPG.Control
{
    public class PatrolPath : MonoBehaviour {

        private void OnDrawGizmos()
        {
            for(int i = 0; i < transform.childCount; i++)
            {
                
              
                Gizmos.DrawSphere(transform.GetChild(i).position, 0.3f);
                if (i < transform.childCount - 1)
                {
                    Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i + 1).position);
                }
                else
                {
                    Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(0).position);
                }
               
                

            }
        }
    } 
}

