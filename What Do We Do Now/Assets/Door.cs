// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Door.cs" company="Trollpants Game Studios AS">
//  Copyright (c) 2015 All Rights Reserved
// </copyright>
// <summary>
//  todo [Write a short summary of the script here]
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Trollpants // todo Add project key, like "HE" or "WW"
{
    using UnityEngine;

    public class Door : MonoBehaviour
    {
        #region Fields & properties

        public GameObject ClosedDoor;
        public GameObject OpenDoor;

        #endregion /Fields & properties

        #region Public methods

        #endregion /Public methods

        #region Unity methods

        // Notes & best practices:
        // Remove methods if empty
        // Execution order: http://docs.unity3d.com/Manual/ExecutionOrder.html

        private void Awake()
        {
            SetDoorState(0);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == 9)
            {
                SetDoorState(1);
            }
        }

        #endregion /Unity methods

        #region Private methods

        private void SetDoorState(int state)
        {
            ClosedDoor.SetActive(false);
            OpenDoor.SetActive(false);

            switch (state)
            {
                case 0:
                    ClosedDoor.SetActive(true);
                    break;
                case 1:
                    OpenDoor.SetActive(true);
                    break;
            }
        }

        #endregion / Private methods
    }
}
