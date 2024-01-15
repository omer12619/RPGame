using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] float speed=1f;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        if ((target ==null))
        {
            return;
            
        }
        transform.LookAt(GetAimLocation());
        transform.Translate(Vector3.forward*speed*Time.deltaTime);
        
        
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
}
