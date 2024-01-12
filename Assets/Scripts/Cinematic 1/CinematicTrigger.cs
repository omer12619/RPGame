using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace RPG.Cinematic
{
    public class CinematicTrigger : MonoBehaviour
    {
        bool flag = false;
        // Start is called before the first frame update
        private void OnTriggerEnter(Collider other)
        {
            {
                if (!flag && other.tag == "Player")
                {
                    GetComponent<PlayableDirector>().Play();
                    flag = true;

                }

            }
        }
    }
}

