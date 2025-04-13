using UnityEngine;

public class FlyingCar : BaseCar
{
   
    public void Fly()
    {
        Debug.Log(message: "Flying is flying...");
    }

    public override void Drive()
    {
        Fly();
    }


}
