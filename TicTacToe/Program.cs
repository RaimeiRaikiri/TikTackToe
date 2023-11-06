// Create board
string[,] board = new string[3, 3];
bool GameOver = false;
string yesOrNo;
bool playAgain = false;
int turnsComplete = 1;
string player1Choice;
string player2Choice = "";
int X = 0;
int Y = 0;
void Introduction() => Console.WriteLine("Welcome to the console version of TikTakToe!");
void Player1Choice()
{
    Console.WriteLine("Player 1, Enter 'x' for crosses or 'o' for naughts");
    do
    {
        player1Choice = Console.ReadLine();
        player1Choice = player1Choice.ToUpper();

        if (player1Choice == "X")
        {
            break;
        }
        else if (player1Choice == "O")
        {
            break;
        }
        else
        {
            Console.WriteLine($"You have entered {player1Choice}, this is neither 'x' nor 'o'");
            Console.WriteLine("Please try again!");
            continue;
        }
    } while (player1Choice != "X" || player1Choice != "O");
}
void Player2Choice(string player1Choice)
{
    if (player1Choice == "X")
    {
        player2Choice = "O";
    } else if (player1Choice == "O")
    {
        player2Choice = "X";
    }
    Console.WriteLine();
    Console.WriteLine($"Player 1 is using {player1Choice}");
    Console.WriteLine($"Player 2 is using {player2Choice}");
}
void CreateBoard()
{
    Console.WriteLine();
    Console.WriteLine("  1   2   3");
    Console.WriteLine($"1 {board[0, 0]} | {board[0, 1]} | {board[0, 2]}");
    Console.WriteLine("  ---------");
    Console.WriteLine($"2 {board[1, 0]} | {board[1, 1]} | {board[1, 2]}");
    Console.WriteLine("  ---------");
    Console.WriteLine($"3 {board[2, 0]} | {board[2, 1]} | {board[2, 2]}");
}
void StartingBoard()
{
    Console.WriteLine("Game is starting!");
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            board[i, j] = " ";
        }
    }
    CreateBoard();
}
int BoardPositionX(int WhichPlayersTurn)
{
    Console.WriteLine();
    Console.WriteLine($"Player {WhichPlayersTurn}, please select the row position 1 - 3 you would like to place your move (using the numbers going down vertically)");

    try
    {
            X = Convert.ToInt32(Console.ReadLine());
        while (X > 4 || X < 1)
        {
            Console.WriteLine("You did not enter a number from 1-3");
            X = Convert.ToInt32(Console.ReadLine());
            if (X < 4 && X > 0)
            {
                break;
            }
            else
            {
                continue;
            }
        }
    }
    catch (FormatException e)
    {

        do
        {
            try
            {
                Console.WriteLine("You have entered in the incorrect format try again");
                X = Convert.ToInt32(Console.ReadLine());
                while (X > 4 || X < 1)
                {
                    Console.WriteLine("You did not enter a number from 1-3");
                    X = Convert.ToInt32(Console.ReadLine());
                    if (X < 4 && X > 0)
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            catch (FormatException d)
            {
                continue;
            }
        }
        while (X > 4 || X < 1);
    }
    return X;

}
int BoardPositionY(int WhichPlayersTurn)
{
    Console.WriteLine($"Player {WhichPlayersTurn}, please select the column position 1 - 3 you would like to place your move (using the numbers going across horizontally) ");

    try
    {
        Y = Convert.ToInt32(Console.ReadLine());
        while (Y > 4 || Y < 1)
        {
            Console.WriteLine("You did not enter a number from 1-3");
            Y = Convert.ToInt32(Console.ReadLine());
            if (Y < 4 && Y > 0)
            {
                break;
            }
            else
            {
                continue;
            }
        }
    }
    catch (FormatException e)
    {

        do
        {
            try
            {
                Console.WriteLine("You have entered in the incorrect format try again");
                Y = Convert.ToInt32(Console.ReadLine());
                while (Y > 4 || Y < 1)
                {
                    Console.WriteLine("You did not enter a number from 1-3");
                    Y = Convert.ToInt32(Console.ReadLine());
                    if (Y < 4 && Y > 0)
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            catch (FormatException d)
            {
                continue;
            }
        }
        while (Y > 4 || Y < 1);
    }
    return Y;

}
void TurnsComplete() => turnsComplete += 1;

void RunningGame()
{
    int WhichPlayersTurn;
    do
    {
        if (turnsComplete % 2 == 0)
        {
            WhichPlayersTurn = 2;
        }
        else
        {
            WhichPlayersTurn = 1;
        }
        int x = BoardPositionX(WhichPlayersTurn);
        int y = BoardPositionY(WhichPlayersTurn);
        bool isThisSpaceEmpty = IsThisSpaceEmpty(x,y);
        if (WhichPlayersTurn == 1)
        {
            while (isThisSpaceEmpty == false)
            {
                x = BoardPositionX(WhichPlayersTurn);
                y = BoardPositionY(WhichPlayersTurn);
                isThisSpaceEmpty = IsThisSpaceEmpty(x, y);
                if (isThisSpaceEmpty == false)
                {
                    continue;
                } else
                {
                    break;
                }
            }
            board[x-1, y-1] = player1Choice;
        } else if (WhichPlayersTurn == 2)
        {
            while (isThisSpaceEmpty == false)
            {
                x = BoardPositionX(WhichPlayersTurn);
                y = BoardPositionY(WhichPlayersTurn);
                isThisSpaceEmpty = IsThisSpaceEmpty(x, y);
                if (isThisSpaceEmpty == false)
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
            board[x-1, y-1] = player2Choice;
        }
        CreateBoard();
        TurnsComplete();
        int WhoWon = TestForPlayerWin();
        if (turnsComplete == 10)
        {
            Console.WriteLine("The game ends in a Draw");
            GameOver = true;
            break;
        } else if (WhoWon == 1)
        {
            Console.WriteLine();
            Console.WriteLine("Congratulations Player 1 you win!");
            break;
        } else if (WhoWon == 2)
        {
            Console.WriteLine();
            Console.WriteLine("Congratulations Player 2 you win!");
            break;
        }
        else
        {
            continue;
        }
    } while (turnsComplete < 11 || GameOver == false);

}
int TestForPlayerWin()
{
    string topRow = board[0, 0] + board[0, 1] + board[0, 2];
    string bottomRow = board[2, 0] + board[2, 1] + board[2, 2];
    string leftColumn = board[0, 0] + board[1, 0] + board[2, 0];
    string middleColumn = board[0, 1] + board[1, 1] + board[2, 1];
    string rightColumn = board[0, 2] + board[1, 2] + board[2, 2];
    string leftDiagonal = board[0, 0] + board[1, 1] + board[2, 2];
    string rightDiagonal = board[0, 2] + board[1, 1] + board[2, 0];

    if (player1Choice == "X" && (topRow == "XXX"
        || bottomRow == "XXX"
        || leftColumn == "XXX"
        || rightColumn == "XXX"
        || middleColumn == "XXX"
        || leftDiagonal == "XXX"
        || rightDiagonal == "XXX"))
    {
        return 1;
    } else if (player1Choice == "O" && (topRow == "OOO"
        || bottomRow == "OOO"
        || leftColumn == "OOO"
        || rightColumn == "OOO"
        || middleColumn == "OOO"
        || leftDiagonal == "OOO"
        || rightDiagonal == "OOO"))
    {
        return 1;
    } else if (player2Choice == "X" && (topRow == "XXX"
        || bottomRow == "XXX"
        || leftColumn == "XXX"
        || rightColumn == "XXX"
        || middleColumn == "XXX"
        || leftDiagonal == "XXX"
        || rightDiagonal == "XXX"))
    {
        return 2;
    }
    else if (player2Choice == "O" && (topRow == "OOO"
        || bottomRow == "OOO"
        || leftColumn == "OOO"
        || rightColumn == "OOO"
        || middleColumn == "OOO"
        || leftDiagonal == "OOO"
        || rightDiagonal == "OOO"))
    {
        return 2;
    }
    else
    {
        return 0;
    }
}
bool IsThisSpaceEmpty(int x, int y)
{
    if (board[x-1,y-1] == "X" || board[x-1,y-1] == "O")
    {
        Console.WriteLine("This space has been taken, try a different space");
        return false;
    }
    else
    {
        return true;
    }
}
bool PlayAgain()
{
    Console.WriteLine("Do you want to play again? (Y for yes, N for no)");
    do
    {
        yesOrNo = Console.ReadLine();
        yesOrNo = yesOrNo.ToUpper();

        if (yesOrNo == "Y")
        {
            playAgain = true;
            break;
        }
        else if (yesOrNo == "N")
        {
            playAgain = false;
            break;
        }
        else
        {
            Console.WriteLine($"You have entered {yesOrNo}, this is neither 'Y' nor 'N'");
            Console.WriteLine("Please try again!");
            continue;
        }
    } while (yesOrNo != "Y" || yesOrNo != "N");
    return playAgain;
}
void LoopingGames()
{
    bool willPlayAgain;
    do
    {
        willPlayAgain = PlayAgain();
        if (willPlayAgain)
        {
            turnsComplete = 1;
            Introduction();
            Player1Choice();
            Player2Choice(player1Choice);
            StartingBoard();
            RunningGame();
            continue;
        }
        else
        {
            Console.WriteLine("You have exited the game");
            break;
        }
    } while (willPlayAgain);
}


Introduction();
Player1Choice();
Player2Choice(player1Choice);
StartingBoard();
RunningGame();
LoopingGames();

