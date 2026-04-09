using System.Drawing;

namespace Figure;

public enum Colors{
    white,
    black
}
public enum PieceTypes{
    None,
    Pawn,
    King,
    Queen,
    Knight,
    Rook,
    Bishop,

}
public class Fig{
    private Colors _color;
    private PieceTypes _piece_type;

    public Fig(PieceTypes piece_type, Colors color){
        this._color = color;
        this._piece_type = piece_type;
    }
    public override string ToString()
    {
        return "";
    }
}