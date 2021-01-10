using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VoronoiDiagram;
using VoronoiDiagram.DataStructure;

public class MainSceneManager : MonoBehaviour
{

    #region Constants

    /// <summary>
    /// The width of the voronoi diagram.
    /// </summary>
    private const float DIARGRAM_WIDTH = 12f;

    /// <summary>
    /// The height of the voronoi diagram.
    /// </summary>
    private const float DIARGRAM_HEIGHT = 7f;

    /// <summary>
    /// The number of segmenets used to draw the regions.
    /// </summary>
    private const int CIRLCE_SEGMENTS_COUNT = 128;

    /// <summary>
    /// The distance applied every frame to each segment when expanding regions.
    /// </summary>
    private const float SIMULATION_SPEED = 0.01f;

    #endregion

    #region Initialization

    /// <summary>
    /// Executes once on start.
    /// </summary>
    private void Awake()
    {
        // Display version
        VersionText.text = string.Format("Version: {0}", Application.version);

        // Starts the demo with a 2 regions sample.
        Generate2RegionsSample();
    }

    #endregion

    #region Fields/Properties

    /// <summary>
    /// References the voronoi diagram in the scene.
    /// </summary>
    [SerializeField]
    private DiagramManager Diagram;

    /// <summary>
    /// References the UI element displaying the version of the app.
    /// </summary>
    [SerializeField]
    private Text VersionText;

    #endregion

    #region Methods

    /// <summary>
    /// Generates 2 regions sample.
    /// </summary>
    public void Generate2RegionsSample()
    {
        Diagram.Initialize(new Vector2(DIARGRAM_WIDTH, DIARGRAM_HEIGHT), new List<Seed>()
        {
            new Seed(Guid.NewGuid(), CIRLCE_SEGMENTS_COUNT, 1.5f, 1.5f, Color.red),
            new Seed(Guid.NewGuid(), CIRLCE_SEGMENTS_COUNT, -1.5f, -1.5f, Color.blue),
        }, SIMULATION_SPEED);
    }

    /// <summary>
    /// Generates 3 regions sample.
    /// </summary>
    public void Generate3RegionsSample()
    {
        Diagram.Initialize(new Vector2(DIARGRAM_WIDTH, DIARGRAM_HEIGHT), new List<Seed>()
        {
            new Seed(Guid.NewGuid(), CIRLCE_SEGMENTS_COUNT, 0.5f, 0.5f, Color.red),
            new Seed(Guid.NewGuid(), CIRLCE_SEGMENTS_COUNT, -1.5f, -1.5f, Color.blue),
            new Seed(Guid.NewGuid(), CIRLCE_SEGMENTS_COUNT, -0.5f, -1.5f, Color.green)
        }, SIMULATION_SPEED);
    }

    /// <summary>
    /// Generates 4 regions sample.
    /// </summary>
    public void Generate4RegionsSample()
    {
        Diagram.Initialize(new Vector2(DIARGRAM_WIDTH, DIARGRAM_HEIGHT), new List<Seed>()
        {
            new Seed(Guid.NewGuid(), CIRLCE_SEGMENTS_COUNT, 0.5f, 0.5f, Color.red),
            new Seed(Guid.NewGuid(), CIRLCE_SEGMENTS_COUNT, 2f, 0f, Color.cyan),
            new Seed(Guid.NewGuid(), CIRLCE_SEGMENTS_COUNT, -1.5f, -1.5f, Color.blue),
            new Seed(Guid.NewGuid(), CIRLCE_SEGMENTS_COUNT, -0.5f, -1.5f, Color.green)
        }, SIMULATION_SPEED);
    }

    #endregion

}
