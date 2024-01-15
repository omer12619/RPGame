using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace RPG.Core
{
    public class PreisstClassSPawn : MonoBehaviour
    {
        [SerializeField] GameObject presistobjectref;
        static bool hasSpawn=false;
        private void Awake()
        {
            if (hasSpawn) return;
            
                spawnpressitobjects();
                hasSpawn = true;
           
        }

        private void spawnpressitobjects()
        {
           GameObject presistpbj = Instantiate(presistobjectref);
            DontDestroyOnLoad(presistpbj);
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
