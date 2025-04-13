using UnityEngine;

public class BrokenCar : BaseCar
{
    public override void Drive()
    {
        base.Drive();
        Debug.Log(message: "Very slow....");
    }
}

