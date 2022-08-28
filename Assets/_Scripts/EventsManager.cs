using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    private static EventsManager _instance;
    public static EventsManager Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }


    public event Action OnZoneOneCompleted;
    public event Action OnZoneTwoCompleted;
    public event Action OnZoneThreeCompleted;


    public void ZoneOneCompleted()
    {
        OnZoneOneCompleted?.Invoke();
    }
    
    public void ZoneTwoCompleted()
    {
        OnZoneTwoCompleted?.Invoke();
    }
    
    public void ZoneThreeCompleted()
    {
        OnZoneThreeCompleted?.Invoke();
    }
}
