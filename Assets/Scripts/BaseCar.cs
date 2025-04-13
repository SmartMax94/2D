using UnityEngine;

public abstract class BaseCar : MonoBehaviour, IControllable {
    public virtual void Drive()
    {
        Debug.Log(message: "Car is driving....");
    }

   
   public   void Move()
    {
        Drive();
    }
}
