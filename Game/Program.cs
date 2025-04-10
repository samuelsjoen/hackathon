using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        GameModel gameModel = new GameModel();
        GameView gameView = new GameView(gameModel);
        GameController gameController = new GameController(gameModel, gameView);
        gameController.InitializeGame();
    }
}