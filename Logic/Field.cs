using Figure;
namespace Field;

public class Chessfield
{
    private string text = "";
    public string?[,] playing_field = new string[8,8];
    //default Placement
    public override string ToString()
    {
        text += "  a b c d e f g h \n";
        string symbol;
        for(int rows = 0; rows < 8; rows++){
            for(int colums = 0; colums < 8; colums++){
                
                if((rows+colums)%2 == 1){
                    symbol = "#";
                }
                else{
                    symbol = " ";
                }
                if (playing_field[rows,colums] == null && colums == 0){
                    text += $"{rows+1}|{symbol}|";
                }
                else if(playing_field[rows,colums] == null){
                    text += $"{symbol}|";
                }
                else{
                    if(colums == 0){
                    text += $"{rows+1}| |";
                    }
                    else{
                    text += $" |";
                    }
                }
                if (colums == 7){
                    text += $"{Environment.NewLine}";
                    if (rows < 7){
                        text += " +-+-+-+-+-+-+-+-+";
                        text += $"{Environment.NewLine}";
                    }
                }
            }
        }
        return text;
    }
}
