using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Net.Http.Headers;
using System.Numerics;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Authentication.ExtendedProtection;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

public abstract class SmartDevice
{
    private bool _status;
    private int _time;
    private string _name;
    Stopwatch stopwatch = new Stopwatch();

    public SmartDevice(int time, string name)
    {
        _time = time;
        _name = name;
    }

    public int GetDuration()
    {
        return _time;
    }
    
    public string GetName()
    {
        return _name;
    }

    public bool GetStatus()
    {
        return _status;
    }
    
    public bool TurnOn()
    {
        _status = true;

        stopwatch.Start();

        return _status;
    }

    public bool TurnOff()
    {
        _status = false;

        stopwatch.Stop();

        return _status;
    }

    public abstract string StatusReport();

}

public class SmartLight : SmartDevice
{
    private int _brightness;
    private string _colors;
    string report; 

    private int[] _brightnessLevels = {25, 50, 75, 100};
    private string[] _colorsArray = {"White", "Red", "Blue", "Green", "Yellow", "Orange", "Purple"};


    public SmartLight(int time, string name, int bright, string color) : base(time, name)
    {
        bright = _brightness;
        color = _colors;
    }

    public int GetBrightness()
    {
        return _brightness;
    }
    public override string StatusReport()
    {
        string report = "";
        bool change = GetStatus();
        int howBright = GetBrightness();

        if(change == true)
        {
            report = $"On: Brightness {howBright}";
        }
        else
        {
            report = "Off";
        }

        return report;
    }
}

public class SmartHeater : SmartDevice
{
    private int _temperature;
    string report; 

    public SmartHeater(bool stat, int time, string name, int temperature) : base(time, name)
    {
        temperature = _temperature;
    }

    public int GetTemperature()
    {
        return _temperature;
    }


    public override string StatusReport()
    {
        string report = "";
        bool change = GetStatus();
        int temp = GetTemperature();

        if(change == true)
        {
            report = $"On: Temperature {temp}";
        }
        else
        {
            report = "Off";
        }

        return report;
    }
}

public class SmartTV : SmartDevice
{
    private int _channel;
    string report; 

    public SmartTV(int time, string name, int channel) : base(time, name)
    {
        channel = _channel;
    }

    private int GetChannel()
    {
        return _channel;
    }

    public override string StatusReport()
    {
        string report = "";
        bool change = GetStatus();
        int whatChannel = GetChannel();

        if(change == true)
        {
            report = $"On {whatChannel}";
        }
        else
        {
            report = "Off";
        }

        return report;
    }
}
