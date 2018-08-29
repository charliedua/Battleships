using SwinGameSDK;

namespace MyGame
{
    internal static class GameMain
    {
        public static void Main()
        {
            // Opens a new Graphics Window
            SwinGame.OpenGraphicsWindow("Battle Ships", 800, 600);

            // Load Resources
            GameResources.LoadResources();

            SwinGame.PlayMusic(GameResources.GameMusic("Background"));

            // Game Loop
            do
            {
                GameController.HandleUserInput();
                DrawScreen();
            }
            while (!SwinGame.WindowCloseRequested() == true | CurrentState == GameState.Quitting);

            SwinGame.StopMusic();

            // Free Resources and Close Audio, to end the program.
            FreeResources();
        }
    }
}