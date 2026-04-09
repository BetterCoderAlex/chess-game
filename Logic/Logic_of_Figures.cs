namespace Logic_of_Figures;
using Logic;

public class King : Fig{
    public King(Colors color) : base(PieceTypes.King, color){
        
    }
}
public class Queen : Fig{
    public Queen(Colors color) : base(PieceTypes.Queen, color){

    }
}
public class Bishop : Fig{
    public Bishop(Colors color) : base(PieceTypes.Bishop, color){

    }
}
public class Springer : Fig{
    public Springer(Colors color) : base(PieceTypes.Springer, color){

    }
}
public class Rook : Fig{
    public Rook(Colors color) : base(PieceTypes.Rook, color){

    }
}
public class Pawn : Fig{
    public Pawn(Colors color) : base(PieceTypes.Pawn, color){

    }
}