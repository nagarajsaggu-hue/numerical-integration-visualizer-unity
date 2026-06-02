
using System;
using UnityEngine;
using org.mariuszgromada.math.mxparser;

public class METHOD1 : MonoBehaviour
{
    private double registrationNumber = 126794d;
    private double a;
    private int frequency = 2; // Given Value: 2Hz
    private int timeLimit = 20; // For 20 Seconds
    private Function function;
    private oompe.lib.FunctionPlotter plotter;

    void Start()
    {
        CalculateEnergy();
    }

    public void CalculateEnergy()
    {
        double totalEnergy = 0;
        double x = 0;
        double absoluteError = 0d;
        double relativeError = 0d;
        double calculatedValue = 634.469;
        double pt = 0;

        a = registrationNumber / 40000;
        function = new Function("p(x)=(3.16985*x)+sin(2*pi*2*x)");
        plotter = new oompe.lib.FunctionPlotter(function, 0, 20);

        for (double i = 0; i <= timeLimit; i += 0.1)
        {
            pt = (a * i) + Math.Sin(2 * Math.PI * frequency * i);

            Vector2 startLine = new Vector2((float)i, 0);
            Vector2 endLine = new Vector2((float)i, (float)pt);
            plotter.AddLine(startLine, endLine);

            totalEnergy += 0.1 * pt;

            Vector2 startLine1 = new Vector2((float)(i + 0.1), (float)pt);
            Vector2 endLine1 = new Vector2((float)i, (float)pt);
            plotter.AddLine(startLine1, endLine1);

            Vector2 startLine2 = new Vector2((float)(i + 0.1), (float)pt);
            Vector2 endLine2 = new Vector2((float)(i + 0.1), 0);
            plotter.AddLine(startLine2, endLine2);
        }

        absoluteError = calculatedValue - totalEnergy;
        relativeError = (absoluteError / calculatedValue) * 100;

        Debug.Log("Total Energy Consumed by Method 1: " + totalEnergy);
        Debug.Log("Absolute Error for Method 1: " + absoluteError);
        Debug.Log("Relative Error for Method 1: " + relativeError);

        // Create an empty GameObject to use as a drawing plane
        GameObject drawingPlane = new GameObject("DrawingPlane");

        // Plot the function on the drawing plane
        plotter.Plot(drawingPlane);
    }
}
