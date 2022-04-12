namespace ConServCore;

public enum PacketType {Message, Connect, Kill}
    
    
public readonly struct Packet
{ 
    public readonly PacketType Type;
    public readonly long Id;
    public readonly string Message;
        
    public Packet(PacketType type, long id, string message)
    {
        Type = type;
        Id = id;
        Message = message;
    }

    public override string ToString()
    {
        return $"Packet{{ {Id}: {Type}}}";
    }
}