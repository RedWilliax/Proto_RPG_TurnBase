using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PM_Player : PM_Entity
{
    private void Start()
    {
        PM_InputManager.OnClickLeftMouse += MoveEntity;
    }

    void MoveEntity(bool _do)
    {
        if (_do)
            movement.Move(PM_MousePointer.MousePosition);
    }
}
