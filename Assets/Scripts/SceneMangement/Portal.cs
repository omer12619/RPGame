using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using RPG.ScenceMangment;

public class Portal : MonoBehaviour
{
    enum DestiantionID
    {
        A,B,C,D,E,F,G,H
    }
    [SerializeField] int scencetoload = -1;
 
    [SerializeField] Transform spawnPoint;
    [SerializeField] DestiantionID destiantionID;
    [SerializeField] float fadeouttime =0.5f;
    [SerializeField] float fadeintime =1f;
    [SerializeField] float delay =1f;
    


    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(Transction());
            print("i hit");
        }
       
    }
    private IEnumerator Transction()
    {
        if (scencetoload < 0)
        {
            Debug.LogError("-1 nagtive scence no exist");
            yield break;
        }
        DontDestroyOnLoad(gameObject);
        Fader fader= FindObjectOfType<Fader>();
        yield return fader.Fadeout(fadeouttime);


        yield return SceneManager.LoadSceneAsync(scencetoload);
        Portal other= GetotherPortal();
        UpdatePlayer(other);
        yield return new  WaitForSeconds(delay);
        yield return fader.Fadein(fadeintime);

        Destroy(gameObject);
    }

    private Portal GetotherPortal()
    {
        foreach (Portal portal in FindObjectsOfType<Portal>())
        {
            if (portal == this) continue;
            if (portal.destiantionID != destiantionID) continue;
            return portal;
        }
        return null;
    }

    void Start()
    {
        
        
    }

    // Update is called once per frame
    void UpdatePlayer(Portal other)
    {
        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponent<NavMeshAgent>().enabled = false;
        player.transform.position = other.spawnPoint.position;
        player.transform.rotation = other.spawnPoint.rotation;
        player.GetComponent<NavMeshAgent>().enabled = true;



    }
}
