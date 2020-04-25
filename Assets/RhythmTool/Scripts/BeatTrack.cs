using System;

namespace RhythmTool
{
    /// <summary>
    /// A Track that contains Beat Features.
    /// </summary>
    public class BeatTrack : Track<Beat>
    {

    }

    /// <summary>
    /// A Beat represents the rhythm of the song.
    /// </summary>
    [Serializable]
    public struct Beat : IFeature
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
        /// The current BPM of the song.
        /// </summary>
        public float bpm;                
    }
}