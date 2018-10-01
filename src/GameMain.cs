using SwinGameSDK;

// =======================================
// AUTHOR		: Anmol Dua
// STUDENT ID	: 101983924
// DESCRIPTION	: Documentation
// =======================================

namespace MyGame
{
    internal static class GameMain
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
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
                GameController.DrawScreen();
            }
            while (!SwinGame.WindowCloseRequested() == true | GameController.CurrentState == GameState.Quitting);

            SwinGame.StopMusic();

            // Free Resources and Close Audio, to end the program.
            GameResources.FreeResources();
        }
    }
}