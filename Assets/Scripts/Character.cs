using UnityEngine;

public class Character : MonoBehaviour, IControllable
{
    public void Move()
    {
        Run();
    }

    public void Run()
    {
        Debug.Log(message: "Character: Run");
    }

    public void Walk()
    {
        Debug.Log(message: "Character: Walk");
    }
}