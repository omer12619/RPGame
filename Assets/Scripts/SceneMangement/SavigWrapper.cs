
using UnityEngine;
using RPG.Saving;

namespace RPG.ScenceMangment
{
    public class SavigWrapper : MonoBehaviour
    {
        const string defaultSaveFile = "savetome";

        void Update()   
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                Debug.Log("Hit load");
                Load();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("Hit save");
                Save();
            }
        }

        private void Save()
        {
            GetComponent<JsonSavingSystem>().Save(defaultSaveFile);
        }

        private void Load()
        {
            GetComponent<JsonSavingSystem>().Load(defaultSaveFile);
        }
    }
}