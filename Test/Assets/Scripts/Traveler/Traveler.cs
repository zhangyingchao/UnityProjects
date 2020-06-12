using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 旅行者
/// </summary>
public abstract class Traveler : MonoBehaviour
{
    public string travelerName;

    public float interval;
    protected float restTime;
    public int goldRate;
    public int goldCount;
    public Traveler(string name)
    {
        this.travelerName = name;
        Born();
    }
    protected abstract void Born();

    protected virtual void GoldGrow()
    {
        goldCount += goldRate;
    }

    private void Update()
    {
        if (restTime > 0) restTime -= Time.deltaTime;
        else
        {
            GoldGrow();
            restTime = interval;
        }
    }
}
