namespace SaberTestTask;

public class ListNode
{
    public ListNode Prev;
    public ListNode Next;
    public ListNode Rand; // произвольный элемент внутри списка
    public string Data;
}

public class ListRand
{
    public ListNode Head;
    public ListNode Tail;
    public int Count;

    public void Serialize(FileStream s)
    {
        var nodes = new Dictionary<ListNode, int>();
        ;
        var curNode = Head;
        for (var i = 0; i < Count; i++)
        {
            nodes[curNode] = i;
            curNode = curNode.Next;
        }

        using BinaryWriter writer = new BinaryWriter(s);
        curNode = Head;
        writer.Write(Count);
        for (var i = 0; i < Count; i++)
        {
            writer.Write(curNode.Data);
            if (curNode.Rand != null)
                writer.Write(nodes[curNode.Rand]);
            else
                writer.Write(-1);
            
            curNode = curNode.Next;
        }

        writer.Close();
    }

    public void Deserialize(FileStream s)
    {
        using BinaryReader reader = new BinaryReader(s);

        var nodes = new ListNode[reader.ReadInt32()];
        var randNodes = new int[nodes.Length];
        var k = 0;
        while (reader.PeekChar() != -1)
        {
            var data = reader.ReadString();
            var randId = reader.ReadInt32();
            randNodes[k] = randId;
            nodes[k] = new ListNode()
            {
                Data = data
            };
            
            k++;
        }
        reader.Close();
        
        for (var i = 0; i < randNodes.Length; i++)
        {
            if (randNodes[i] != -1)
            {
                nodes[i].Rand = nodes[randNodes[i]];
            }
            if (i > 0)
            {
                nodes[i].Prev = nodes[i - 1];
            }

            if (i < nodes.Length - 1)
            {
                nodes[i].Next = nodes[i + 1];
            }
        }

        Head = nodes[0];
        Tail = nodes[^1];
        Count = nodes.Length;
    }
}