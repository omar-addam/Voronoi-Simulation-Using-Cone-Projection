using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VoronoiDiagram;
using VoronoiDiagram.DataStructure;

public class MainSceneManager : MonoBehaviour
{

    #region Initialization

    /// <summary>
    /// Executes once on start.
    /// </summary>
    private void Awake()
    {
        // Display version
        VersionText.text = string.Format("Version: {0}", Application.version);
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



    #endregion

}
