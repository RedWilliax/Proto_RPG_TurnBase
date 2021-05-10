using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PM_InputManager : MonoBehaviour
{

    public static Action<bool> OnClickLeftMouse = null;

    PM_MousePointer mousePointer;


    public bool GetLeftMouse => Input.GetMouseButtonDown(0);


    private void Awake()
    {
        if (!mousePointer)
            mousePointer = gameObject.GetComponent<PM_MousePointer>();

        if (!mousePointer)
            Debug.LogError("Missing MousePointer for InputManager");

        OnClickLeftMouse += DebugLeftMouse;
    }

    private void Update()
    {
        OnClickLeftMouse.Invoke(GetLeftMouse);
    }

    void DebugLeftMouse(bool _bool)
    {
        Debug.Log($"K.O, {_bool}");
    }




}
