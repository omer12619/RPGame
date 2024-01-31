using RPG.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RPG.Combat
{
    public class Projectile : MonoBehaviour
    {
        Health target =null;
        float damage = 10f;
        [SerializeField] float speed = 1f;
        [SerializeField] bool isHoming = false;
        [SerializeField] GameObject hiEffect = null;
        [SerializeField] float lifetime = 2f;
        [SerializeField] float timetodie = 2f;
        [SerializeField] GameObject[] destroyOnHit = null;

        // Start is called before the first frame update
        private void Start()
        {
            transform.LookAt(GetAimLocation());
        }

        // Update is called once per frame
        void Update()
        {
            if (target == null)
            {
                return;

            }
            if (isHoming&& !target.IsDead()) {
                transform.LookAt(GetAimLocation());
            }
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            


        }
        
        Vector3 GetAimLocation()
        {

            CapsuleCollider capsuleCollider = target.GetComponent<CapsuleCollider>();
            if (capsuleCollider == null)
            {
                return target.transform.position;
            }
            return target.transform.position + Vector3.up * capsuleCollider.height / 2;

        }
        public void SetTarget(Health target,float damage)
        {
            this.target = target;
            this.damage = damage;
            Destroy(gameObject, lifetime);

        }
        private void OnTriggerEnter(Collider other)
        {
            if(other.GetComponent<Health>() != target) {
                return;
            }
            if (target.IsDead()) return;
            target.TakeDamage(damage);

            if(hiEffect != null)
            {

               Instantiate(hiEffect, GetAimLocation(),transform.rotation);
            }

            foreach (GameObject toDestroy in destroyOnHit)
            {
                Destroy(toDestroy);
            }

           



            Destroy(gameObject);

        }
    }
}
