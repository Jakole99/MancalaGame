// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Board board = new MancalaBoard(10, 4);
Board wariboard = new WariBoard(10, 4);
board.MoveStones(2, Player.Numb.P2);
wariboard.MoveStones(2, Player.Numb.P2);

board.DrawBoard();
wariboard.DrawBoard();