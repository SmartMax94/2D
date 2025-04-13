using UnityEngine;
using System;

public class InputController : MonoBehaviour
{

    public GameObject go;

    private IControllable controllableObject;

    private void Start()
    {
        controllableObject = go.GetComponent<IControllable>();
        if (controllableObject != null)
            throw new NullReferenceException(message: "go dons not have Icontrolable interface");
        
        
    }



    private void Update()
    {
        
if (Input.GetKey(KeyCode.Space)) //»нкапсул€ци€

            controllableObject.Move();
        }



    }

