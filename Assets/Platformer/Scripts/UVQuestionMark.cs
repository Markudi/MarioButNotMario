using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVQuestionMark : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Blink());

    }

    // Update is called once per frame
    void Update()
    {
        // Blink();

        // GetComponent<MeshRenderer>().material = mat;
    }

    IEnumerator Blink()
    {
        Material mat = GetComponent<MeshRenderer>().material;
        
        
        //Change material y offset by 0.2 every second.
        mat.mainTextureOffset = mat.mainTextureOffset + new Vector2(0f, 0.2f);
        // mat.mainTextureScale = new Vector2(-0.5f, -0.5f);

        yield return new WaitForSeconds(1);

        StartCoroutine(Blink());
    }
}
