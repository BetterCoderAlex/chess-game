using Field;
using Logic;

public class Program00{
    public static int Main(string[] args){
        Chessfield field = new Chessfield();
        //field.Move("a2", "a3");
        Console.WriteLine(field.ToString());
        return 0;
    }
}
