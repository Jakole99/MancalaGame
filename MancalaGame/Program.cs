// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Board board = new WariBoard(8, 4);
Console.WriteLine(board.MoveStones(0, Player.Numb.P1).index);


board.DrawBoard();
