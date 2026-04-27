using Field;
using Logic;

public class Program00{
    public static int Main(string[] args){
        Chessfield field = new Chessfield();
        Console.WriteLine(field.ToString());
        Console.WriteLine("Move from (example a1): ");
        string start_pos = Console.ReadLine();
        Console.WriteLine("Move to (example a2): ");
        string dest_pos = Console.ReadLine();
        field.Move(start_pos, dest_pos);
        Console.WriteLine(field.ToString());
        return 0;
    }
}
