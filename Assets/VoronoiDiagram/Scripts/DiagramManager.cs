using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VoronoiDiagram.DataStructure;

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
            Collider = Bounds.GetComponent<Collider2D>();

            Initialize(new Vector2(20f, 9.5f), new List<Seed>()
            {
                new Seed(Guid.NewGuid(), 5, 1, 1, Color.red),
                new Seed(Guid.NewGuid(), 5, -3, -3, Color.blue)
            });
        }

        /// <summary>
        /// Initializes the diagram.
        /// </summary>
        /// <param name="dimensions">The width and length of the diagram.</param>
        /// <param name="seeds">The center of each region to be created.</param>
        /// <param name="expansionSpeed">The speed at which the regions expand.</param>
        public void Initialize(Vector2 dimensions, List<Seed> seeds, float expansionSpeed = 0.0005f)
        {
            // Set the speed
            ExpansionSpeed = expansionSpeed;

            // Set the boundaries of the diagram
            InitializeBounds(dimensions);

            // Create regions
            InitializeRegions(seeds);
        }

        #endregion

        #region Fields/Properties

        [Header("Bounds")]

        /// <summary>
        /// References the gameobject that represents the bounds of the diagram.
        /// </summary>
        [SerializeField]
        private GameObject Bounds;

        /// <summary>
        /// References the collider of the diagram that will be used to determine its bounds.
        /// </summary>
        private Collider2D Collider;



        [Header("Regions")]

        /// <summary>
        /// The speed at which the regions expand.
        /// </summary>
        [SerializeField]
        private float ExpansionSpeed;

        /// <summary>
        /// References the gameobject that will hold all generated regions.
        /// </summary>
        [SerializeField]
        private GameObject RegionsParent;

        /// <summary>
        /// References the template prefab used when initializing the regions.
        /// </summary>
        [SerializeField]
        private GameObject RegionTemplate;

        /// <summary>
        /// List of all regions created in this diagram.
        /// </summary>
        public List<DiagramRegion> Regions { private set; get; }

        #endregion

        #region Methods

        /// <summary>
        /// Sets the boundaries of the diagram.
        /// </summary>
        private void InitializeBounds(Vector2 dimensions)
        {
            // Create square mesh
            Mesh square = new Mesh();
            square.vertices = new Vector3[]
            {
                new Vector3(0.5f, 0.5f, 0),
                new Vector3(-0.5f, 0.5f, 0),
                new Vector3(-0.5f, -0.5f, 0),
                new Vector3(0.5f, -0.5f, 0)
            };
            square.uv = new Vector2[4]
            {
                new Vector2(0.5f, 0.5f),
                new Vector2(-0.5f, -0.5f),
                new Vector2(0.5f, -0.5f),
                new Vector2(-0.5f, 0.5f)
            };
            square.triangles = new int[] { 0, 3, 2, 2, 1, 0 };
            Bounds.GetComponent<MeshFilter>().mesh = square;

            // Set the scale
            Bounds.transform.localScale = new Vector3(dimensions.x, dimensions.y, 1);
        }

        /// <summary>
        /// Creates a single region for each provided seed.
        /// </summary>
        private void InitializeRegions(List<Seed> seeds)
        {
            // Delete all current regions
            foreach (Transform region in RegionsParent.transform)
                GameObject.Destroy(region.gameObject);
            Regions = new List<DiagramRegion>();

            // Create new regions
            foreach(var seed in seeds)
            {
                // Create a new region instance
                GameObject region = Instantiate(RegionTemplate, RegionsParent.transform);

                // Extract the script
                DiagramRegion script = region.GetComponent<DiagramRegion>();

                // Initialize data
                script.Initialize(seed);

                // Add to list
                Regions.Add(script);
            }
        }

        /// <summary>
        /// Continuously expands the boundaries of the regions.
        /// </summary>
        private void Update()
        {
            foreach (var region in Regions)
                region.Expand(ExpansionSpeed, Collider, Regions);
        }

        #endregion

    }
}
