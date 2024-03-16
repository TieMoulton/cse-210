using System;
using System.Collections.Generic;
using System.Linq;

abstract class SmartDevice
{
    public string Name { get; set; }
    public bool IsOn { get; protected set; }
    public TimeSpan TimeOn { get; protected set; }

    public abstract void TurnOn();
    public abstract void TurnOff();

    public void UpdateTimeOn()
    {
        if (IsOn)
            TimeOn = TimeOn.Add(TimeSpan.FromSeconds(1));
    }

    public override string ToString()
    {
        return $"{Name} is {(IsOn ? "on" : "off")}, Time On: {TimeOn}";
    }
}

class SmartLight : SmartDevice
{
    public SmartLight(string name)
    {
        Name = name;
        IsOn = false;
        TimeOn = TimeSpan.Zero;
    }

    public override void TurnOn()
    {
        IsOn = true;
    }

    public override void TurnOff()
    {
        IsOn = false;
    }
}

class SmartHeater : SmartDevice
{
    public SmartHeater(string name)
    {
        Name = name;
        IsOn = false;
        TimeOn = TimeSpan.Zero;
    }

    public override void TurnOn()
    {
        IsOn = true;
    }

    public override void TurnOff()
    {
        IsOn = false;
    }
}

class SmartTV : SmartDevice
{
    public SmartTV(string name)
    {
        Name = name;
        IsOn = false;
        TimeOn = TimeSpan.Zero;
    }

    public override void TurnOn()
    {
        IsOn = true;
    }

    public override void TurnOff()
    {
        IsOn = false;
    }
}

class Room
{
    public List<SmartDevice> Devices { get; }

    public Room()
    {
        Devices = new List<SmartDevice>();
    }

    public void AddDevice(SmartDevice device)
    {
        Devices.Add(device);
    }

    public void TurnOnAllDevices()
    {
        foreach (var device in Devices)
        {
            device.TurnOn();
        }
    }

    public void TurnOffAllDevices()
    {
        foreach (var device in Devices)
        {
            device.TurnOff();
        }
    }

    public void ReportAllItemsStatus()
    {
        foreach (var device in Devices)
        {
            Console.WriteLine(device);
        }
    }

    public void ReportAllItemsOn()
    {
        var onDevices = Devices.Where(d => d.IsOn);
        foreach (var device in onDevices)
        {
            Console.WriteLine(device);
        }
    }

    public void ReportLongestRunningItem()
    {
        var longestRunningDevice = Devices.OrderByDescending(d => d.TimeOn).FirstOrDefault();
        if (longestRunningDevice != null)
        {
            Console.WriteLine(longestRunningDevice);
        }
    }
}

class House
{
    public List<Room> Rooms { get; }

    public House()
    {
        Rooms = new List<Room>();
    }

    public void AddRoom(Room room)
    {
        Rooms.Add(room);
    }

    public void TurnOnAllLights()
    {
        foreach (var room in Rooms)
        {
            room.TurnOnAllDevices();
        }
    }

    public void TurnOffAllLights()
    {
        foreach (var room in Rooms)
        {
            room.TurnOffAllDevices();
        }
    }
}

class Program
{
    static void Main()
    {
        var kitchen = new Room();
        var livingRoom = new Room();

        var light1 = new SmartLight("Kitchen Light");
        var light2 = new SmartLight("Living Room Light");
        var tv = new SmartTV("Living Room TV");

        kitchen.AddDevice(light1);
        livingRoom.AddDevice(light2);
        livingRoom.AddDevice(tv);

        var house = new House();
        house.AddRoom(kitchen);
        house.AddRoom(livingRoom);

        house.TurnOnAllLights();
        kitchen.Devices[0].UpdateTimeOn(); // Simulate time passing for the kitchen light
        livingRoom.Devices[1].UpdateTimeOn(); // Simulate time passing for the TV

        livingRoom.ReportAllItemsStatus();
        Console.WriteLine();

        house.TurnOffAllLights();
        livingRoom.ReportAllItemsStatus();
        Console.WriteLine();

        livingRoom.ReportAllItemsOn();
        Console.WriteLine();

        livingRoom.ReportLongestRunningItem();
    }
}