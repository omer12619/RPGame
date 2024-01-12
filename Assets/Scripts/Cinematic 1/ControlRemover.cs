using RPG.Control;
using RPG.Core;
using UnityEngine;
using UnityEngine.Playables;


namespace RPG.Cinematic
{
    public class ControlRemover : MonoBehaviour
    {
        GameObject player;
        void Start()
        {


                GetComponent<PlayableDirector>().played += DisableControl;
                GetComponent<PlayableDirector>().stopped += EnableControl;
                player = GameObject.FindWithTag("Player");
            

        }

        void DisableControl(PlayableDirector playableDirector)
        {
            
            player.GetComponent<ActionSchedul>().CancelAction();
            player.GetComponent<PlayerControl>().enabled = false;

        }
        void EnableControl(PlayableDirector playableDirector)
        {
            player.GetComponent<PlayerControl>().enabled = true;

        }
       
     

        // Update is called once per frame
        void Update()
        {

        }
    }
}
