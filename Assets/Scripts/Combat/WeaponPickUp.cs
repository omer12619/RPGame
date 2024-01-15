using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RPG.Combat {
    public class WeaponPickUp : MonoBehaviour
    {
        [SerializeField] Weapon weapon = null;
        // Start is called before the first frame update
        private void OnTriggerEnter(Collider other)
        {
            if (other != null && other.gameObject.tag == "Player")
            {
                other.GetComponent<Fighter>().Equipeweapon(weapon);
                Destroy(gameObject);
    
        }

        }
    }
}
