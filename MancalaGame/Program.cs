// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Board board = new MancalaBoard(8, 4);
board.MoveStones(4, Player.Numb.P2);
Console.WriteLine (board.GetLastMovePit(4, Player.Numb.P2).GetStoneAmount());


board.DrawBoard();
