using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace RPG.ScenceMangment
{



    public class Fader : MonoBehaviour
    {

        private void Start()
        {
            canvasGroup = GetComponent<CanvasGroup>();
           
        }

        CanvasGroup canvasGroup;
        public IEnumerator Fadeout(float time)
        {
            while (canvasGroup.alpha<1)
            {
                canvasGroup.alpha += Time.deltaTime / time;
                yield return null;
            }
           


        }
        public IEnumerator FadeInOut(float time)
        {
            yield return Fadeout(3f);
            print(" out");
            yield return Fadein(3f);

        }
       public IEnumerator Fadein(float time)
        {
            while (canvasGroup.alpha > 0)
            {
                canvasGroup.alpha -= Time.deltaTime / time;
                yield return null;
            }



        }
    }
}
