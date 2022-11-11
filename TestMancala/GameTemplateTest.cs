using System.Runtime.CompilerServices;
using Moq;

public class GameTemplateTest
{

    public class CheckEndConditionTest
    {
        [Theory]
        [InlineData(8, 2, false)]
        [InlineData(6, 0, true)]
        [InlineData(6, 4, false)]
        [InlineData(14, 0, true)]

        public void CheckEndConditionTest1(int pits, int stones, bool expectedAnswer)
        {
            //arrange
            Player player = new Player("Jan", Player.Numb.P1);
            GameTemplate gameTemplate = new MancalaTemplate();
            Board board = new Board(pits, stones, true);

            //act
            bool answer = gameTemplate.CheckEndCondition(board, player);

            //assert
            Assert.Equal(expectedAnswer, answer);
        }

        [Theory]
        [InlineData(80, 0, true)]
        [InlineData(4, 2, false)]
        [InlineData(2, 0, true)]
        [InlineData(16, 8, false)]

        public void CheckEndConditionTest2(int pits, int stones, bool expectedAnswer)
        {
            //arrange
            Player player = new Player("Peter", Player.Numb.P1);
            GameTemplate gameTemplate = new WariTemplate();
            Board board = new Board(pits, stones, false);


            //act
            bool answer = gameTemplate.CheckEndCondition(board, player);

            //assert
            Assert.Equal(expectedAnswer, answer);
        }


        [Theory]
        [InlineData(80, 0, true)]
        [InlineData(4, 2, false)]
        [InlineData(2, 0, true)]
        [InlineData(16, 8, false)]

        public void CheckEndConditionTest3(int pits, int stones, bool expectedAnswer)
        {
            //arrange
            Player player = new Player("Erik", Player.Numb.P2);

            GameTemplate gameTemplate = new MancalaTemplate();
            Board board = new Board(pits, stones, true);


            //act
            bool answer = gameTemplate.CheckEndCondition(board, player);

            //assert
            Assert.Equal(expectedAnswer, answer);
        }

    }

    public class ChoosePitTest
    { 
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]

        public void ChoosePitTest1(int keyInput)
        {
            //Arrange
            Player player = new Player("Mike", Player.Numb.P1);
            GameTemplate gameTemplate = new MancalaTemplate();
            GameSettings gameSettings = new GameSettings(Game.Variant.Mancala, "Mike", "Erik", true);

            Mock<UI> uiMock = new Mock<UI>();
            uiMock.Setup(x => x.GetInteger()).Returns(keyInput);


            //act
            int expectedAnswer = keyInput - 1;
            int answer = gameTemplate.ChoosePit(player, uiMock.Object, gameSettings);

            //assert
            Assert.Equal(expectedAnswer, answer);

        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]

        public void ChoosePitTest2(int keyInput)
        {
            //Arrange
            Player player = new Player("Jan", Player.Numb.P2);
            GameTemplate gameTemplate = new WariTemplate();
            GameSettings gameSettings = new GameSettings(Game.Variant.Mancala, "Jan", "Tom", true);

            Mock<UI> uiMock = new Mock<UI>();
            uiMock.Setup(x => x.GetInteger()).Returns(keyInput);


            //act
            int expectedAnswer = keyInput - 1 + (gameSettings.GameBoard.Pits.Length/2);
            int answer = gameTemplate.ChoosePit(player, uiMock.Object, gameSettings);

            //assert
            Assert.Equal(expectedAnswer, answer);

        }


    }

    public class GetWinnerTest
    {
        [Theory]
        [InlineData(5, 10, Player.Numb.P2)]
        [InlineData(15, 1, Player.Numb.P1)]
        [InlineData(1, 1, Player.Numb.None)]
        [InlineData(15, 110, Player.Numb.P2)]
        [InlineData(215, 121, Player.Numb.P1)]
        [InlineData(450, 450, Player.Numb.None)]

        public void GetWinnerTest1(int scorePlayer1, int scorePlayer2, Player.Numb expectedAnswer)
        {
            //arrange
            GameTemplate gameTemplate = new MancalaTemplate();
            GameSettings gameSettings = new GameSettings(Game.Variant.Mancala, "Bob", "Kaan", true);

            //act
            gameSettings.Player1.score = scorePlayer1;
            gameSettings.Player2.score = scorePlayer2;
            Player.Numb answer = gameTemplate.GetWinner(gameSettings).PlayerNumb;

            //assert
            Assert.Equal(expectedAnswer, answer);
        }

        [Theory]
        [InlineData(45, 46, Player.Numb.P2)]
        [InlineData(3, 1, Player.Numb.P1)]
        [InlineData(0, 0, Player.Numb.None)]
        [InlineData(1, 10, Player.Numb.P2)]
        [InlineData(23, 21, Player.Numb.P1)]
        [InlineData(22, 22, Player.Numb.None)]

        public void GetWinnerTest2(int scorePlayer1, int scorePlayer2, Player.Numb expectedAnswer)
        {
            //arrange
            GameTemplate gameTemplate = new WarCaliTemplate();
            GameSettings gameSettings = new GameSettings(Game.Variant.Mancala, "J", "K", true);

            //act
            gameSettings.Player1.score = scorePlayer1;
            gameSettings.Player2.score = scorePlayer2;
            Player.Numb answer = gameTemplate.GetWinner(gameSettings).PlayerNumb;

            //assert
            Assert.Equal(expectedAnswer, answer);
        }

        [Theory]
        [InlineData(10000, 10001, Player.Numb.P2)]
        [InlineData(1, 0, Player.Numb.P1)]
        [InlineData(300000, 300000, Player.Numb.None)]
        [InlineData(10, 115, Player.Numb.P2)]
        [InlineData(21, 12, Player.Numb.P1)]
        [InlineData(5, 5, Player.Numb.None)]

        public void GetWinnerTest3(int scorePlayer1, int scorePlayer2, Player.Numb expectedAnswer)
        {
            //arrange
            GameTemplate gameTemplate = new WarCaliTemplate();
            GameSettings gameSettings = new GameSettings(Game.Variant.Mancala, "J", "K", true);

            //act
            gameSettings.Player1.score = scorePlayer1;
            gameSettings.Player2.score = scorePlayer2;
            Player.Numb answer = gameTemplate.GetWinner(gameSettings).PlayerNumb;

            //assert
            Assert.Equal(expectedAnswer, answer);
        }
    }
}

