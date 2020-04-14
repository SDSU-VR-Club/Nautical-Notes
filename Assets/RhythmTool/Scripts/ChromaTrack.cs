using UnityEngine;
using System;

namespace RhythmTool
{
    /// <summary>
    /// A Track that contains Chroma features
    /// </summary>
    public class ChromaTrack : Track<Chroma>
    {

    }

    /// <summary>
    /// Chroma features are closely related to pitch and represent the most prominent notes in the song.
    /// </summary>
    [Serializable]
    public struct Chroma : IFeature
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
        /// The detected musical note.
        /// </summary>
        public Note note;
    }
    
    /// <summary>
    /// Musical notes.
    /// </summary>
    public enum Note
    {
        A,
        ASharp,
        B,
        C,
        CSHARP,
        D,
        DSHARP,
        E,
        F,
        FSHARP,
        G,
        GSHARP       
    }
}
