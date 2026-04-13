namespace Logic_of_Figures;
using Logic;
using Field;

public class King : Fig{
    public King(Colors color) : base(PieceTypes.King, color){
        
    }
    public override bool IsValidMove(int xStart, int yStart, int xEnd, int yEnd, Chessfield field){
        return true;
    }
}
public class Queen : Fig{
    public Queen(Colors color) : base(PieceTypes.Queen, color){

    }
    public override bool IsValidMove(int xStart, int yStart, int xEnd, int yEnd, Chessfield field){
        return true;
    }
}
public class Bishop : Fig{
    public Bishop(Colors color) : base(PieceTypes.Bishop, color){

    }
    public override bool IsValidMove(int xStart, int yStart, int xEnd, int yEnd, Chessfield field){
        return true;
    }
}
public class Springer : Fig{
    public Springer(Colors color) : base(PieceTypes.Springer, color){

    }
    public override bool IsValidMove(int xStart, int yStart, int xEnd, int yEnd, Chessfield field){
        return true;
    }
}
public class Rook : Fig{
    public Rook(Colors color) : base(PieceTypes.Rook, color){

    }
    public override bool IsValidMove(int xStart, int yStart, int xEnd, int yEnd, Chessfield field){
        return true;
    }
}
public class Pawn : Fig{
    public Pawn(Colors color) : base(PieceTypes.Pawn, color){

    }
    public override bool IsValidMove(int xStart, int yStart, int xEnd, int yEnd, Chessfield field){
        return true;
    }
}