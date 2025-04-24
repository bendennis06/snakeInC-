using System;
using System.Numerics;
using Raylib_cs;

class Program
{
    static void Main()
    {
        const int screenWidth = 800;
        const int screenHeight = 600;

        bool gameOver = false;

        Raylib.InitWindow(screenWidth, screenHeight, "Snake Game");
        Raylib.SetTargetFPS(15);

        Vector2 snakePosition = new Vector2(screenWidth / 2, screenHeight / 2);
        Vector2 direction = new Vector2(0, 0);
        Rectangle snake = new Rectangle();

        while (!Raylib.WindowShouldClose())
        {
            // --- UPDATE ---
            if (!gameOver)
            {
                if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT) && direction.X == 0) direction = new Vector2(20, 0);
                if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT) && direction.X == 0)  direction = new Vector2(-20, 0);
                if (Raylib.IsKeyDown(KeyboardKey.KEY_UP) && direction.Y == 0) direction = new Vector2(0, -20);
                if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN) && direction.Y == 0)  direction = new Vector2(0, 20);
            }

            // --- SYNC RECTANGLE TO POSITION ---
            snakePosition += direction;
            snake.x = snakePosition.X;
            snake.y = snakePosition.Y;
            snake.width = 20;
            snake.height = 20;

            // --- WALL COLLISION ---
            if (!gameOver && 
                (snake.x < 0 || snake.y < 0 || 
                snake.x + snake.width > screenWidth || 
                snake.y + snake.height > screenHeight))
            {
                gameOver = true;
                Console.WriteLine("💥 Snake hit the wall!");
            }

            // --- INPUT WHEN GAME OVER ---
            if (gameOver)
            {
                if (Raylib.IsKeyPressed(KeyboardKey.KEY_R))
                {
                    snakePosition = new Vector2(screenWidth / 2, screenHeight / 2);
                    direction = new Vector2(0, 0);
                    gameOver = false;
                }

                if (Raylib.IsKeyPressed(KeyboardKey.KEY_ESCAPE))
                {
                    Raylib.CloseWindow();
                }
            }

            // --- DRAW ---
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RAYWHITE);

            if (gameOver)
            {
                Raylib.DrawText("GAME OVER", 300, 250, 40, Color.RED);
                Raylib.DrawText("Press R to restart or ESC to quit", 220, 320, 20, Color.DARKGRAY);
            }
            else
            {
                Raylib.DrawRectangleRec(snake, Color.DARKGREEN);
                Raylib.DrawText("Use arrow keys to move", 10, 10, 20, Color.GRAY);
            }

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}
