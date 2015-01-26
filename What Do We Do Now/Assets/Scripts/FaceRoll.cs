// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FaceRoll.cs" company="Trollpants Game Studios AS">
//  Copyright (c) 2015 All Rights Reserved
// </copyright>
// <summary>
//  todo [Write a short summary of the script here]
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Trollpants // todo Add project key, like "HE" or "WW"
{
    using UnityEngine;

    public class FaceRoll : MonoBehaviour
    {
        #region Fields & properties

        private ShapeeBase _shapee;
        private bool _swappingFace;

        #endregion /Fields & properties

        #region Public methods

        #endregion /Public methods

        #region Unity methods

        // Notes & best practices:
        // Remove methods if empty
        // Execution order: http://docs.unity3d.com/Manual/ExecutionOrder.html

        private void Awake()
        {
            _shapee = GetComponent<ShapeeBase>();
        }

        private void Start()
        {
        }

        private void Update()
        {
            if (_swappingFace)
            {
                return;
            }

            RandomTimer();
        }

        #endregion /Unity methods

        #region Private methods

        private void RandomTimer()
        {
            _swappingFace = true;

            Invoke("SwapFace", Random.Range(2f, 6f));
        }

        private void SwapFace()
        {
            var rand = Random.Range(0, 4);

            _shapee.SetFace(rand);

            _swappingFace = false;
        }

        #endregion / Private methods
    }
}
