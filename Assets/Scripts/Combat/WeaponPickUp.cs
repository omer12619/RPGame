using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Combat {
    public class WeaponPickUp : MonoBehaviour
    {
        [SerializeField] Weapon weapon = null;
        [SerializeField] float respawnTime = 3f;
        // Start is called before the first frame update
        private void OnTriggerEnter(Collider other)
        {
            if (other != null && other.gameObject.tag == "Player")
            {
                other.GetComponent<Fighter>().Equipeweapon(weapon);
                StartCoroutine(HideuntilNotOwn(respawnTime));
                
    
            }

        }
        private IEnumerator HideuntilNotOwn(float sec)
        {
            HidePickUp();
           
           
            yield return new WaitForSeconds(sec);

            ShowPickUp();




        }

        private void ShowPickUp()
        {
            GetComponent<Collider>().enabled = true;
            transform.GetChild(0).gameObject.SetActive(true);
        }
    

        private void HidePickUp()
        {
            GetComponent<Collider>().enabled = false;
            
            foreach (Transform t in transform)
            {
                t.gameObject.SetActive(false);

            }
        }
    }
}
