using Field;

namespace Logic;

public enum Colors{
    white,
    black
}
public enum PieceTypes{
    Pawn,
    King,
    Queen,
    Springer,
    Rook,
    Bishop,

}
public abstract class Fig{
    private Colors _color;
    private PieceTypes _piece_type;

    public Fig(PieceTypes piece_type, Colors color){
        this._color = color;
        this._piece_type = piece_type;
    }
    public abstract bool IsValidMove(int xStart, int yStart, int xEnd, int yEnd, Chessfield field);
    public override string ToString()
    {
        string piece = "";
        if(_piece_type == PieceTypes.Pawn){
            piece = "p";
        }
        if(_piece_type == PieceTypes.Bishop){
            piece = "b";
        }
        if(_piece_type == PieceTypes.King){
            piece = "k";
        }
        if(_piece_type == PieceTypes.Queen){
            piece = "q";
        }
        if(_piece_type == PieceTypes.Rook){
            piece = "r";
        }
        if(_piece_type == PieceTypes.Springer){
            piece = "s";
        }
        if(_color == Colors.black){
            piece = piece.ToUpper();
        }
        return piece;
    }
}