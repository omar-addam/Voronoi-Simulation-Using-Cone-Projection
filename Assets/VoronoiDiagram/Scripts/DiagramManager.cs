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

        /// <summary>
        /// Initializes the diagram.
        /// </summary>
        /// <param name="dimensions">The width and length of the diagram.</param>
        public void Initialize(Vector2 dimensions)
        {
            // Set the width and length of the diagram
            transform.localScale = new Vector3(dimensions.x, dimensions.y, 0);
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
