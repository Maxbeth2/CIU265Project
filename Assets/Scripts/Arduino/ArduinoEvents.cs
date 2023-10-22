using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ArduinoEvent
{
    public void PerformEvent();
}

public class Shake : ArduinoEvent
{
    int level;
    public Shake(int level) { this.level = level; }

    public void PerformEvent()
    {
        DataSender ds =GameObject.FindObjectOfType<DataSender>();
        ds.activateRelay(level);
    }
}

public class ShakeOff : ArduinoEvent
{

    public void PerformEvent()
    {
        DataSender ds =GameObject.FindObjectOfType<DataSender>();
        ds.ShutOffVibrations();
    }
}

public class DropMagazines : ArduinoEvent
{
    public void PerformEvent()
    {
        DataSender ds =GameObject.FindObjectOfType<DataSender>();
        ds.DropMagazines();
    }
}
