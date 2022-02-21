using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVQuestionMark : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Material mat = GetComponent<MeshRenderer>().material;
        mat.mainTextureOffset = mat.mainTextureOffset + new Vector2(Time.deltaTime, 0f);
        mat.mainTextureScale = new Vector2(-0.5f, -0.5f);

        // GetComponent<MeshRenderer>().material = mat;
    }
}
