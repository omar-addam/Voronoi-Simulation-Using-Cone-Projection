using System;
using UnityEngine;

namespace VoronoiDiagram.DataStructure
{
    [Serializable]
    public class Seed
    {

        #region Constructors

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public Seed()
            : this(Guid.NewGuid(), 16, 0, 0, Color.white)
        {
        }

        /// <summary>
        /// Default constructor.
        /// <param name="id">Unique identifier used by items to link them to this category.</param>
        /// <param name="circleSegmentCount">The number of segments used to create the cone projection.</param>
        /// <param name="positionX">The x position of the seed.</param>
        /// <param name="positionY">The y position of the seed.</param>
        /// <param name="color">The color used to display the region generated from this seed.</param>
        /// </summary>
        public Seed(Guid id, int circleSegmentCount, float positionX, float positionY, Color color)
        {
            _Id = id;
            _CircleSegmentCount = circleSegmentCount;
            _PositionX = positionX;
            _PositionY = positionY;
            _Color = color;
        }

        /// <summary>
        /// Clone constructor.
        /// </summary>
        /// <param name="seed">Instance to clone.</param>
        public Seed(Seed seed)
            : this(seed.Id, seed.CircleSegmentCount, seed.PositionX, seed.PositionY, seed.Color)
        {
        }

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
        /// The number of segments used to create the cone projection.
        /// </summary>
        [SerializeField]
        [Tooltip("The number of segments used to create the cone projection.")]
        private int _CircleSegmentCount = 0;

        /// <summary>
        /// The number of segments used to create the cone projection.
        /// </summary>
        public int CircleSegmentCount { get { return _CircleSegmentCount; } }



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
