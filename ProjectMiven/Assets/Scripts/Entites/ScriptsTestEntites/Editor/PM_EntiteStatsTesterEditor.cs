using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PM_EntiteStatsTester))]
public class PM_EntiteStatsTesterEditor : Editor
{ 
    PM_EntiteStatsTester eTarget;

    Stats stat;

    float value;

    protected void OnEnable()
    {
        eTarget = (PM_EntiteStatsTester)target;
    }


    public override void OnInspectorGUI()
    {
        eTarget.entite = (PM_Entity)EditorGUILayout.ObjectField(eTarget.entite, typeof(PM_Entity), true);

        stat = (Stats)EditorGUILayout.EnumPopup("Stat to change", stat);

        value = EditorGUILayout.FloatField("Value to apply", value);

        if(GUILayout.Button("Up Stat"))
        {
            eTarget.UpStats(stat, value);
        }

        if (GUILayout.Button("Down Stat"))
        {
            eTarget.DownStats(stat, value);
        }
    }


}
