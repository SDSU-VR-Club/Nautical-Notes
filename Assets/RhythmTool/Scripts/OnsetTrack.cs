using System;

namespace RhythmTool
{
    /// <summary>
    /// A Track that contains Onset Features.
    /// </summary>
    public class OnsetTrack : Track<Onset>
    {
        
    }
    
    /// <summary>
    /// An Onset is the start of a note in a song.
    /// </summary>
    [Serializable]
    public struct Onset : IFeature
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
                return 0;
            }
        }

        /// <summary>
        /// The time in seconds at which this feature occurs.
        /// </summary>
        public float timestamp;

        /// <summary>
        /// The strength or prominence of an onset.
        /// </summary>
        public float strength;
    }
}