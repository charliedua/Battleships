using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using SwinGameSDK;

// =======================================
// AUTHOR		: Anmol Dua
// STUDENT ID	: 101983924
// DESCRIPTION	: Documentation
// =======================================

/// <summary>
/// The battle phase is handled by the DiscoveryController.
/// </summary>
internal static class DiscoveryController
{
    /// <summary>
    /// Handles input during the discovery phase of the game.
    /// </summary>
    /// <remarks>
    /// Escape opens the game menu. Clicking the mouse will
    /// attack a location.
    /// </remarks>
    public static void HandleDiscoveryInput()
    {
        if (SwinGame.KeyTyped(KeyCode.vk_ESCAPE))
        {
            GameController.AddNewState(GameState.ViewingGameMenu);
        }

        if (SwinGame.MouseClicked(MouseButton.LeftButton))
        {
            DoAttack();
        }
    }

    /// <summary>
    /// Attack the location that the mouse if over.
    /// </summary>
    private static void DoAttack()
    {
        Point2D mouse = default(Point2D);

        mouse = SwinGame.MousePosition();

        //Calculate the row/col clicked
        int row = 0;
        int col = 0;
        row = Convert.ToInt32(Math.Floor((mouse.Y - UtilityFunctions.FIELD_TOP) / (UtilityFunctions.CELL_HEIGHT + UtilityFunctions.CELL_GAP)));
        col = Convert.ToInt32(Math.Floor((mouse.X - UtilityFunctions.FIELD_LEFT) / (UtilityFunctions.CELL_WIDTH + UtilityFunctions.CELL_GAP)));

        if (row >= 0 & row < GameController.HumanPlayer.EnemyGrid.Height)
        {
            if (col >= 0 & col < GameController.HumanPlayer.EnemyGrid.Width)
            {
                GameController.Attack(row, col);
            }
        }
    }

    /// <summary>
    /// Draws the game during the attack phase.
    /// </summary>s
    public static void DrawDiscovery()
    {
        const int SCORES_LEFT = 172;
        const int SHOTS_TOP = 157;
        const int HITS_TOP = 206;
        const int SPLASH_TOP = 256;
        const int BACK_BUTTON_LEFT = 710;
        const int BACK_BUTTON_TOP = 5;
        const int BACK_BUTTON_WIDTH = 60;
        const int TOP_BUTTONS_HEIGHT = 46;

        if ((SwinGame.KeyDown(KeyCode.vk_LSHIFT) | SwinGame.KeyDown(KeyCode.vk_RSHIFT)) & SwinGame.KeyDown(KeyCode.vk_c))
        {
            UtilityFunctions.DrawField(GameController.HumanPlayer.EnemyGrid, GameController.ComputerPlayer, true);
        }
        else
        {
            UtilityFunctions.DrawField(GameController.HumanPlayer.EnemyGrid, GameController.ComputerPlayer, false);
        }
        if (UtilityFunctions.IsMouseInRectangle(BACK_BUTTON_LEFT, BACK_BUTTON_TOP, BACK_BUTTON_WIDTH, TOP_BUTTONS_HEIGHT) && SwinGame.MouseClicked(MouseButton.LeftButton))
        {
            GameController.AddNewState(GameState.ViewingGameMenu);
        }

        UtilityFunctions.DrawSmallField(GameController.HumanPlayer.PlayerGrid, GameController.HumanPlayer);
        UtilityFunctions.DrawMessage();

        SwinGame.DrawText(GameController.HumanPlayer.Shots.ToString(), Color.White, GameResources.GameFont("Menu"), SCORES_LEFT, SHOTS_TOP);
        SwinGame.DrawText(GameController.HumanPlayer.Hits.ToString(), Color.White, GameResources.GameFont("Menu"), SCORES_LEFT, HITS_TOP);
        SwinGame.DrawText(GameController.HumanPlayer.Missed.ToString(), Color.White, GameResources.GameFont("Menu"), SCORES_LEFT, SPLASH_TOP);
        SwinGame.DrawBitmap(GameResources.GameImage("Back"), BACK_BUTTON_LEFT, BACK_BUTTON_TOP);
    }
}