public class Room : House
{
    string roomName;

    public Room(string name, string floor) : base(floor)
    {
        name = roomName;
    }

    public string GetName()
    {
        return roomName;
    }
    

}