using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasChange : MonoBehaviour
{
    [SerializeField]
    private Canvas coffeeCalculatorCanvas, ratioChangeCanvas;

    // Start is called before the first frame update
    void Start()
    {
        RatioToCalculatorCanvas();
    }

    public void CalculatorToRatioCanvas()
    {
        coffeeCalculatorCanvas.gameObject.SetActive(false);
        ratioChangeCanvas.gameObject.SetActive(true);
    }

    public void RatioToCalculatorCanvas()
    {
        coffeeCalculatorCanvas.gameObject.SetActive(true);
        ratioChangeCanvas.gameObject.SetActive(false);
    }
}
