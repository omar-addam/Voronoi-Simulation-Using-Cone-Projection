using System;
using UnityEngine;

namespace VoronoiDiagram.DataStructure
{
    [Serializable]
    public class Seed
    {

        #region Constructors



        #endregion

        #region Fields/Properties

        /// <summary>
        /// Unique identifier used by the region representing this seed.
        /// </summary>
        [SerializeField]
        [Tooltip("Unique identifier used by the region representing this seed.")]
        private Guid _Id;

        /// <summary>
        /// Unique identifier used by the region representing this seed.
        /// </summary>
        public Guid Id { get { return _Id; } }



        /// <summary>
        /// The x position of the seed.
        /// </summary>
        [SerializeField]
        [Tooltip("The x position of the seed.")]
        private float _PositionX = 0;

        /// <summary>
        /// The x position of the seed.
        /// </summary>
        public float PositionX { get { return _PositionX; } }



        /// <summary>
        /// The y position of the seed.
        /// </summary>
        [SerializeField]
        [Tooltip("The y position of the seed.")]
        private float _PositionY = 0;

        /// <summary>
        /// The y position of the seed.
        /// </summary>
        public float PositionY { get { return _PositionY; } }



        /// <summary>
        /// The color used to display the region generated from this seed.
        /// </summary>
        [SerializeField]
        [Tooltip("The color used to display the region generated from this seed.")]
        private Color _Color = Color.white;

        /// <summary>
        /// The color used to display the region generated from this seed.
        /// </summary>
        public Color Color { get { return _Color; } }

        #endregion

        #region Methods

        /// <summary>
        /// Uses the id of the seed for hash coding.
        /// </summary>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        /// <summary>
        /// Uses the id of the seed for comparison.
        /// </summary>
        public override bool Equals(object obj)
        {
            Seed item = obj as Seed;
            return item?.Id == Id;
        }

        /// <summary>
        /// Displays the color of the seed.
        /// </summary>
        public override string ToString()
        {
            return Color.ToString();
        }

        #endregion

    }
}
