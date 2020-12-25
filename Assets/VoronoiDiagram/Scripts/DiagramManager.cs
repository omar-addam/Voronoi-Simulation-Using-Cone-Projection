using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VoronoiDiagram
{
    public class DiagramManager : MonoBehaviour
    {

        #region Initialization

        /// <summary>
        /// Executes once on start.
        /// </summary>
        private void Awake()
        {
            Collider = GetComponent<Collider2D>();
        }

        #endregion

        #region Fields/Properties

        /// <summary>
        /// References the collider of the diagram that will be used to determine its bounds.
        /// </summary>
        private Collider2D Collider;

        #endregion

    }
}
