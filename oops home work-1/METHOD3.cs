
using System;
using UnityEngine;
using org.mariuszgromada.math.mxparser;

public class METHOD3 : MonoBehaviour
{
    private double registrationNumber = 12345;
    private double coefficientA;
    private int frequency = 2;
    private oompe.lib.FunctionPlotter graphPlotter;

    private void Start()
    {
        InterpolateArea();
    }

    private void InterpolateArea()
    {
        double totalEnergy = 0;
        InitializeParameters();

        for (double time = 0; time <= 20; time += 0.1)
        {
            double point = CalculatePoint(time);
            totalEnergy += 0.1 * point;
            PlotLine(time, point);
        }

        CalculateAndLogErrors(totalEnergy);
        PlotGraph();
    }

    private void InitializeParameters()
    {
        coefficientA = registrationNumber / 40000;
        Function function = new Function("p(x)=(3.16985*x)+sin(2*pi*2*x)");
        graphPlotter = new oompe.lib.FunctionPlotter(function, 0, 20);
    }

    private double CalculatePoint(double time)
    {
        return (coefficientA * time) + Math.Sin(2 * Math.PI * frequency * time);
    }

    private void PlotLine(double time, double point)
    {
        Vector2 start = new Vector2((float)time, 0);
        Vector2 end = new Vector2((float)time, (float)point);
        graphPlotter.AddLine(start, end);

        double nextTime = time + 0.1;
        double nextPoint = CalculatePoint(nextTime);

        for (double t = 0.1; t > 0; t -= 0.05)
        {
            double interpolatedValue = Lerp(point, nextPoint, t);
            Vector2 nextStart = new Vector2((float)(time + t), (float)interpolatedValue);
            Vector2 nextEnd = new Vector2((float)(time + t), 0);
            graphPlotter.AddLine(nextStart, nextEnd);
        }
    }

    private double Lerp(double a, double b, double t)
    {
        return a + (b - a) * t;
    }

    private void CalculateAndLogErrors(double totalEnergy)
    {
        double calculatedValue = 634.469;
        double absoluteError = calculatedValue - totalEnergy;
        double relativeError = (absoluteError / calculatedValue) * 100;

        Debug.Log("The Total Energy " + totalEnergy);
        Debug.Log("Absolute Error: " + absoluteError);
        Debug.Log("Relative Error: " + relativeError);
    }

    private void PlotGraph()
    {
        graphPlotter.Plot(gameObject);
    }
}
