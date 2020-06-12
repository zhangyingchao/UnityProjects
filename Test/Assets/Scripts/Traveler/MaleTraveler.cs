using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaleTraveler : Traveler
{
    public MaleTraveler male;
    public MaleTraveler(string name) : base(name)
    {
        
    }

    protected override void Born()
    {
        male = new GameObject(travelerName).AddComponent<MaleTraveler>();
        male.travelerName = travelerName;

        male.restTime = male.interval = 1;
        male.goldRate = 5;
        male.goldCount = 0;
    }

    protected override void GoldGrow()
    {
        base.GoldGrow();
    }

}
