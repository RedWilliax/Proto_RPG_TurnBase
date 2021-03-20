using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PM_EntiteTeamManagerTester : MonoBehaviour
{
    [SerializeField] public List<PM_Entity> entite;

    public void TeamUp(List<PM_Entity> _entite)
    {
        for (int i = 0; i < _entite.Count; i++)
        {
            _entite[i].TeamManager.AddEntites(entite);
        }
    }

    public void Disband()
    {
        for (int i = 0; i < entite.Count; i++)
        {
            entite[i].TeamManager.ClearTeam();
        }

    }

}
