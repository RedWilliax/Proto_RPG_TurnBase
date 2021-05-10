using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PM_MousePointer : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;

    [SerializeField] PM_Entity owner;

    static Vector3 mousePosition;

    static Vector3 distanceOwnerToTarget;

    const float distanceMax = 1000;

    public static Vector3 MousePosition => mousePosition;

    public static Vector3 DistanceOwnerToTarget => distanceOwnerToTarget;

    private void LateUpdate()
    {
        ComputeMousePointer();
    }

    public void ComputeMousePointer()
    {
        mousePosition = MousePositonWorld();
        distanceOwnerToTarget = owner.transform.position - mousePosition;
    }

    Vector3 MousePositonWorld()
    {
        RaycastHit _hitResult;

        bool _hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out _hitResult, distanceMax, layerMask);

        if (_hit)
        {
           // Debug.Log("Hit");
           
            return _hitResult.point;
        }

      //  Debug.Log("not Hit");
        return Camera.main.transform.forward;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawSphere(mousePosition, 0.5f);

        Gizmos.color = Color.yellow;

        Gizmos.DrawLine(owner.transform.position, mousePosition);

        Gizmos.color = Color.red;

        Gizmos.DrawRay(Camera.main.ScreenPointToRay(Input.mousePosition));

    }

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(5, 5, 200, 200));

        GUILayout.Label("DEBUG MOUSEPOINTER");
        GUILayout.Label($"Distance Owner - Mouse : {distanceOwnerToTarget.magnitude: 0.0}");

        GUILayout.EndArea();

    }

}
