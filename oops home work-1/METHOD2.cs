using System;
using UnityEngine;
using org.mariuszgromada.math.mxparser;

public class METHOD2 : MonoBehaviour
{
    private double UniqueIdentifier = 126794;
    private double coefficientA;
    private int frequencyFactor = 2;
    private oompe.lib.FunctionPlotter energyPlotter;

    private void Start()
    {
        CalculateEnergy();
    }

    public void CalculateEnergy()
    {
        double totalEnergy = 0;

        InitializeParameters();

        for (double time = 0; time <= 20; time += 0.1)
        {
            double energyPoint = CalculateEnergyPoint(time);
            totalEnergy += 0.1 * energyPoint;
            PlotEnergyLine(time, energyPoint);
        }

        CalculateAndLogErrors(totalEnergy);
        PlotEnergyGraph();
    }

    private void InitializeParameters()
    {
        coefficientA = UniqueIdentifier / 40000;
        Function energyFunction = new Function("p(x)=(3.16985*x)+sin(2*pi*2*x)");
        energyPlotter = new oompe.lib.FunctionPlotter(energyFunction, 0, 20);
    }

    private double CalculateEnergyPoint(double time)
    {
        return (coefficientA * time) + Math.Sin(2 * Math.PI * frequencyFactor * time);
    }

    private void PlotEnergyLine(double time, double energyPoint)
    {
        Vector2 start = new Vector2((float)time, 0);
        Vector2 end = new Vector2((float)time, (float)energyPoint);
        energyPlotter.AddLine(start, end);

        double nextTime = time + 0.1;
        double nextEnergyPoint = CalculateEnergyPoint(nextTime);

        double meanValue = (energyPoint + nextEnergyPoint) / 2.0;

        Vector2 meanStart = new Vector2((float)nextTime, (float)meanValue);
        Vector2 meanEnd = new Vector2((float)time, (float)meanValue);
        energyPlotter.AddLine(meanStart, meanEnd);

        Vector2 verticalLineStart = new Vector2((float)nextTime, (float)meanValue);
        Vector2 verticalLineEnd = new Vector2((float)nextTime, 0);
        energyPlotter.AddLine(verticalLineStart, verticalLineEnd);
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

    private void PlotEnergyGraph()
    {
        energyPlotter.Plot(this.gameObject);
    }
}
