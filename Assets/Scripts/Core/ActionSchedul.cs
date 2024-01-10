using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;



namespace RPG.Core
{
    public class ActionSchedul : MonoBehaviour
    {
        IAction curretAction;
        // Start is called before the first frame update


        public void StartAction(IAction action)
        {
            if (curretAction == action) { return; }
            if (curretAction != null)
            {
               curretAction.Cancel();
            }
            curretAction = action;
        }
    }
}
