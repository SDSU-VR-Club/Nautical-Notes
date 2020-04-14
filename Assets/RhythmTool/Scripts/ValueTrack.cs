using System;

namespace RhythmTool
{
    /// <summary>
    /// A Track that contains Value Features.
    /// </summary>
    public class ValueTrack : Track<Value>
    {
        
    }

    /// <summary>
    /// A Value Feature is a Feature with a simple float value.
    /// </summary>
    [Serializable]
    public struct Value : IFeature
    {
        float IFeature.timestamp
        {
            get
            {
                return timestamp;
            }
        }

        float IFeature.length
        {
            get
            {
                return length;
            }
        }

        /// <summary>
        /// The time in seconds at which this feature occurs.
        /// </summary>
        public float timestamp;

        /// <summary>
        /// The duration of this feature in seconds.
        /// </summary>
        public float length;

        /// <summary>
        /// The value.
        /// </summary>
        public float value;
    }
}