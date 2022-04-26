using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    private Controls controls;

    public Vector2 move;
    public Vector2 look;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        controls = new Controls();
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        controls.Locomotion.Move.performed += controls => move = controls.ReadValue<Vector2>();
        controls.Locomotion.Look.performed += controls => look = controls.ReadValue<Vector2>();
    }


}


