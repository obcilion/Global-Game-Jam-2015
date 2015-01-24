// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScaleEqualsTiling.cs" company="Trollpants Game Studios AS">
//  Copyright (c) 2015 All Rights Reserved
// </copyright>
// <summary>
//  todo [Write a short summary of the script here]
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Trollpants // todo Add project key, like "HE" or "WW"
{
    using UnityEngine;
    using UnityEngine.UI;


    public class ScaleEqualsTiling : MonoBehaviour
    {
        #region Fields & properties

        private Material _material;

        #endregion /Fields & properties

        #region Public methods

        #endregion /Public methods

        #region Unity methods

        // Notes & best practices:
        // Remove methods if empty
        // Execution order: http://docs.unity3d.com/Manual/ExecutionOrder.html

        private void Awake()
        {
            _material = renderer.material;

            if (_material.mainTextureScale == (Vector2)transform.localScale)
            {
                return;
            }

            _material.mainTextureScale = transform.localScale;
        }

        private void Start()
        {
        }

        private void Update()
        {
            
        }

        #endregion /Unity methods

        #region Private methods

        private void UpdateTiling()
        {
            _material.mainTextureScale = transform.localScale;
        }

        #endregion / Private methods
    }
}
