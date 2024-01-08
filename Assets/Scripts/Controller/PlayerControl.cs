using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using System;
using RPG;
using RPG.Combat;

namespace RPG.Control
{
    public class PlayerControl : MonoBehaviour
    {
        private void Update()
        {
            if (InteractWithCombat()) { return; }



            if (InteractWithMovment()) { return; }; 
            
            
            

            

        }

        private bool InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits)
            {
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();

                if (target == null) continue;

                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("foundone");
                    GetComponent<Fighter>().Attack(target);
                }
                return true;


            }
            return false;
        }

        public bool InteractWithMovment()
        {
            
            return MoveTOcursor();
               

       
        }

        private bool MoveTOcursor()
        {
            Ray ray = GetMouseRay();
            RaycastHit hit;
            bool hashit = Physics.Raycast(ray, out hit);
            if (hashit)
            {
                if (Input.GetMouseButton(0))
                {
                    GetComponent<Move>().StartMoveAction(hit.point);
                    return true;
                }

                
                
                
            }
            return false;



        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}
