using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasChanger : MonoBehaviour
{
    Canvas myCanvas;


    // Start is called before the first frame update
    void Start()
    {
        myCanvas = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableCanvas()
    {
        myCanvas.enabled = false;
    }

    public void EnableCanvas()
    {
        myCanvas.enabled = true;
    }

}
