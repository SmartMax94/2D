using System.Collections.Generic;
using UnityEngine;

public class SpyCar : BaseCar
{
    public void SetVisibility(bool enabled)
    {
        Debug.Log(message: "SpyCar visibility enabled: " + enabled);
    }
    }

