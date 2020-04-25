using System;

namespace RhythmTool
{
    /// <summary>
    /// A Feature is the basic type that holds information in a Track.
    /// </summary>
    public interface IFeature
    {
        /// <summary>
        /// The time in seconds at which this feature occurs.
        /// </summary>
        float timestamp { get; }

        /// <summary>
        /// The duration of this feature in seconds.
        /// </summary>
        float length { get; }
    }
}