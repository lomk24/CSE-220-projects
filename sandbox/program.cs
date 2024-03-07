using System;

class Program
{
    static void Main(string[] args)
    {
        Room _room = new Room("Living room", "First floor");
        string livingRoom = _room.GetName();
        string livingRoomFloor = _room.GetFloor();

        SmartLight _livingRoomLights = new SmartLight("Living Room Lights", 50, "White");
        Console.Write(_livingRoomLights.GetName());
        Console.Write(_livingRoomLights.GetBrightness());
        Console.Write(_livingRoomLights.GetColor());
        _livingRoomLights.TurnOn();

        Console.WriteLine(_livingRoomLights.StatusReport());
        

        Room _room = new Room("Play room", "Basement");
        string playRoom = _room.GetName();
        string livingRoomFloor = _room.GetFloor();

        SmartHeater _playHeater = new SmartHeater("Play Room heater", 75)
        Console.Write(_playHeater.GetName());
        Console.Write(_playHeater.GetTemperature());
        _playHeater.TurnOn();
        Thread.Sleep(10000);
        _playHeater.TurnOff();

        Console.WriteLine(_playHeater.StatusReport)

        SmartTV _playTV = new SmartTV("Play Room", 320);
        Console.WriteLine(_livingRoomLights.GetName());
        Console.Write(_livingRoomLights.GetChannel());
        _playTV.TurnOn();
        
        Console.WriteLine(_playTV.StatusReport());
        
        
    }
}