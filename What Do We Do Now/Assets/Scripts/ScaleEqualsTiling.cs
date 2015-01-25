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

    [ExecuteInEditMode]
    public class ScaleEqualsTiling : MonoBehaviour
    {
        #region Fields & properties

        [SerializeField] private bool _updateTiling;

        #endregion /Fields & properties

        #region Public methods

        #endregion /Public methods

        #region Unity methods

        // Notes & best practices:
        // Remove methods if empty
        // Execution order: http://docs.unity3d.com/Manual/ExecutionOrder.html

        private void Update()
        {
            if (!_updateTiling)
            {
                return;
            }

            UpdateTiling();
        }

        #endregion /Unity methods

        #region Private methods

        private void UpdateTiling()
        {
            _updateTiling = false;
            renderer.sharedMaterial.mainTextureScale = new Vector2(Mathf.Abs(transform.localScale.x), Mathf.Abs(transform.localScale.y));
        }

        #endregion / Private methods
    }
}
