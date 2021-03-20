using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PM_EntiteTeamManagerTester))]
public class PM_EntiteTeamManagerTesterEditor : Editor
{

    PM_EntiteTeamManagerTester eTarget;

    private void OnEnable()
    {

        eTarget = (PM_EntiteTeamManagerTester)target;

    }

    public override void OnInspectorGUI()
    {

        base.OnInspectorGUI();

        if(GUILayout.Button("MakeTeam"))
        {
            eTarget.TeamUp(eTarget.entite);
        }

        if (GUILayout.Button("Disband"))
        {
            eTarget.Disband();
        }

    }

}
