using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PM_Entity : MonoBehaviour
{

    [SerializeField] uint id; //random number give at connection

    [SerializeField] PM_Stats stats;

    [SerializeField] PM_TeamManager teamManager;

    public PM_Stats Stats { get => stats; }
    public PM_TeamManager TeamManager { get => teamManager; }

    public uint ID { get => id; }

}
