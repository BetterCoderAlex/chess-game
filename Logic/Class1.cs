namespace Logic;

public class Chessfield
{
    private string text = "";
    public string?[,] playing_field = new string[8,8];

    public Chessfield(){
        playing_field[0,0] = "T";
        playing_field[0,1] = "R";
        playing_field[0,2] = "L";
        playing_field[0,3] = "D";
        playing_field[0,4] = "K";
        playing_field[0,5] = "L";
        playing_field[0,6] = "R";
        playing_field[0,7] = "T";

        for(int black = 0; black < 8; black++){
            playing_field[1,black] = "B";
        }

        playing_field[7,0] = "t";
        playing_field[7,1] = "r";
        playing_field[7,2] = "l";
        playing_field[7,3] = "d";
        playing_field[7,4] = "k";
        playing_field[7,5] = "l";
        playing_field[7,6] = "r";
        playing_field[7,7] = "t";

        for(int white = 0; white < 8; white++){
            playing_field[6,white] = "b";
        }
    }
    public override string ToString()
    {
        text += "  a b c d e f g h \n";
        string symbol = "";
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
                    text += $"{rows+1}|{playing_field[rows,colums]}|";
                    }
                    else{
                    text += $"{playing_field[rows,colums]}|";
                    }
                }
                if (colums == 7){
                    text += $"{rows+1}{Environment.NewLine}";
                    if (rows < 7){
                        text += " +-+-+-+-+-+-+-+-+";
                        text += $"{Environment.NewLine}";
                    }
                }
            }
        }
        text += "  a b c d e f g h";
        return text;
    }
}
