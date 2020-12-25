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

            // Set location
            transform.localPosition = new Vector3(seed.PositionX, seed.PositionY, 0);

            // Set color
            MeshRenderer.material = new Material(MeshRenderer.material);
            MeshRenderer.material.color = seed.Color;

            // Generate a circular mesh
            MeshFilter.mesh = GenerateCircleMesh(seed.CircleSegmentCount);
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

        /// <summary>
        /// Generates a 2d mesh in the form of a circle.
        /// </summary>
        private Mesh GenerateCircleMesh(int circleSegmentCount)
        {
            int circleVertexCount = circleSegmentCount + 2;
            int circleIndexCount = circleSegmentCount * 3;
            var circle = new Mesh();
            var vertices = new List<Vector3>(circleVertexCount);
            var indices = new int[circleIndexCount];
            var segmentWidth = Mathf.PI * 2f / circleSegmentCount;
            var angle = 0f;
            vertices.Add(Vector3.zero);
            for (int i = 1; i < circleVertexCount; ++i)
            {
                vertices.Add(new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0f) * 0.05f);
                angle -= segmentWidth;
                if (i > 1)
                {
                    var j = (i - 2) * 3;
                    indices[j + 0] = 0;
                    indices[j + 1] = i - 1;
                    indices[j + 2] = i;
                }
            }
            circle.SetVertices(vertices);
            circle.SetIndices(indices, MeshTopology.Triangles, 0);
            circle.RecalculateBounds();
            return circle;
        }

        #endregion

    }
}
