using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PM_Effect
{
    float value;
    Stats stat;
    int duration;
    bool buff;

    public PM_Effect(float value, Stats stat, int duration, bool buff)
    {
        this.value = value;
        this.stat = stat;
        this.duration = duration;
        this.buff = buff;
    }

    public void ApplyEffect(PM_Entity _entity)
    {
        _entity.Stats.ManageStat(stat, value, buff);
        duration--;
        if (duration <= 0)
            _entity.RemoveEffect(this);
    }
}

public class PM_Skill : MonoBehaviour
{

    float count; // Use when player want to use it
    float coolDown;
    float value;
    int duration;
    Stats stat;

    bool buff;
    bool monoTarget;

    public float Count { get => count; }

    public void Effect(PM_Entity _entity)
    {
        if (coolDown > 0)
        {
            //Display why it can use
            return;
        }

        if (monoTarget)
            _entity.AddEffect(new PM_Effect(value, stat, duration, buff));
        else
            _entity.TeamManager.Team.ForEach(n => n.AddEffect(new PM_Effect(value, stat, duration, buff)));

    }
}
