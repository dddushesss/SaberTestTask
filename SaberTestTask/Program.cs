namespace SaberTestTask;

public static class Program
{
    public static void Main(string[] args)
    {
        var node1 = new ListNode
        {
            Data = "node1"
        };
        var node2 = new ListNode
        {
            Data = "node2"
        };
        var node3 = new ListNode
        {
            Data = "node3"
        };
        var node4 = new ListNode
        {
            Data = "node4"
        };
        var node5 = new ListNode
        {
            Data = "node5"
        };

        node1.Next = node2;
        node1.Rand = node4;

        node2.Prev = node1;
        node2.Next = node3;
        node2.Rand = node2;

        node3.Prev = node2;
        node3.Next = node4;
        node3.Rand = node1;

        node4.Prev = node3;
        node4.Next = node5;

        node5.Prev = node4;

        ListRand listRand = new ListRand()
        {
            Head = node1,
            Tail = node5,
            Count = 5
        };
        var fileStream = File.Create("List.data");
        listRand.Serialize(fileStream);
        fileStream.Close();

        var desListNode = new ListRand();
        var openedFile = File.Open("List.data", FileMode.Open);
        desListNode.Deserialize(openedFile);
        openedFile.Close();
    }
}