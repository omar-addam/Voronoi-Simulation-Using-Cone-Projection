using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VoronoiDiagram.DataStructure;

namespace VoronoiDiagram
{
    public class DiagramRegion : MonoBehaviour
    {

        #region Initialization

        /// <summary>
        /// Executes once on start.
        /// </summary>
        private void Awake()
        {
            MeshRenderer = GetComponent<MeshRenderer>();
            MeshFilter = GetComponent<MeshFilter>();
        }

        /// <summary>
        /// Initializes the region.
        /// </summary>
        public void Initialize(Seed seed)
        {
            Seed = seed;
        }

        #endregion

        #region Fields/Properties

        /// <summary>
        /// The seed used to initialize the region.
        /// </summary>
        public Seed Seed { private set; get; }

        /// <summary>
        /// References the mesh renderer of this object. Used to set the color of the mesh.
        /// </summary>
        private MeshRenderer MeshRenderer;

        /// <summary>
        /// References the mesh filter of this object. Used to set the mesh.
        /// </summary>
        private MeshFilter MeshFilter;

        #endregion

        #region Methods



        #endregion

    }
}
