using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour
{
    public int materialIndex = 0;
    public Vector2 uvAnimationRate = new Vector2(1.0f, 1.0f);
    public string textureName = "_MainTex";

    Vector2 uvOffset = Vector2.zero;

    // Update is called once per frame
    void Update()
    {
        uvOffset += (uvAnimationRate * Time.deltaTime);
        if (GetComponent<Renderer>().enabled)
        {
            GetComponent<Renderer>().materials[materialIndex].SetTextureOffset(textureName, uvOffset);
        }
    }
}
