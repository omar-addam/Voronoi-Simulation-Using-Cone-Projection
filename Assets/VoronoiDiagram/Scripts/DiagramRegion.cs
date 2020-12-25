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
            MeshCollider = GetComponent<MeshCollider>();
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
            MeshCollider.sharedMesh = MeshFilter.mesh;
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

        /// <summary>
        /// References the mesh collider of this object.
        /// </summary>
        private MeshCollider MeshCollider;

        /// <summary>
        /// All vertices used to set the bounds of the mesh.
        /// </summary>
        private Vector3[] Vertices;

        /// <summary>
        /// The status of all the vertices. False: still requires expanding. True: done expanding.
        /// </summary>
        private bool[] VerticesStatus;

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
                vertices.Add(new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0f) * 0.1f);
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

            Vertices = vertices.ToArray();
            VerticesStatus = new bool[Vertices.Length];
            return circle;
        }

        /// <summary>
        /// Expands the boundaries of the region.
        /// </summary>
        /// <param name="distance">The speed at which the region expands.</param>
        public void Expand(float distance, Collider2D diagramBoundaries, List<DiagramRegion> regions)
        {
            // Expand the region
            for (int i = 0; i < Vertices.Length; i++)
            {
                // Check if vertex is done expanding
                if (VerticesStatus[i])
                    continue;

                // Compute new position
                Vector3 newPosition = Vertices[i] + Vertices[i].normalized * distance;

                // Check if the new point is outside the diagram's boundaries
                if (!diagramBoundaries.bounds.Contains(newPosition + transform.position))
                {
                    VerticesStatus[i] = true;
                    continue;
                }

                // Check if the new point is inside any other region
                bool insideRegion = false;
                foreach (var region in regions)
                    if (region.Seed.Id != Seed.Id
                        && region.CheckIfPointIsInside(newPosition + transform.position))
                    {
                        VerticesStatus[i] = true;
                        insideRegion = true;
                        break;
                    }
                if (insideRegion)
                    continue;

                // Set new position
                Vertices[i] = newPosition;
            }

            MeshFilter.mesh.vertices = Vertices;
            MeshCollider.sharedMesh = null;
            MeshCollider.sharedMesh = MeshFilter.mesh;
        }

        /// <summary>
        /// Checks if a point is inside the region's boundaries.
        /// </summary>
        public bool CheckIfPointIsInside(Vector3 point)
        {
            if (Physics.Raycast(point, point.normalized, out RaycastHit hit1, Mathf.Infinity) &&
                Physics.Raycast(point, -point.normalized, out RaycastHit hit2, Mathf.Infinity)
                && hit1.transform == transform && hit2.transform == transform)
                return true;
            Debug.Log(hit1.transform);
            return false;
        }

        #endregion

    }
}
