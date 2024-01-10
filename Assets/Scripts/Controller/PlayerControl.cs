
using UnityEngine;
using RPG.Movement;

using RPG.Combat;
using RPG.Core;

namespace RPG.Control
{
    public class PlayerControl : MonoBehaviour
    {
        Health health;
        private void Start()
        {
            health = GetComponent<Health>();
        }
        private void Update()
        {
            if (health.IsDead()) return;

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
                GameObject targetObject = target.gameObject;
                if (!GetComponent<Fighter>().CanAttack(target.gameObject)) { continue; }

                if (Input.GetMouseButtonDown(0))
                {
                   
                    Debug.Log("foundone");
                    GetComponent<Fighter>().Attack(target.gameObject);
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
