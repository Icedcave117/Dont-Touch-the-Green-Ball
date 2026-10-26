using System.Numerics;
using Raylib_cs;
class Program
{    
    public static void Main(String[] args)
    {
        
        // Player Positions
        int PosX = 30;
        int PosY = 30;
        int SpeedX = 10;
        int SpeedY = 10;
    
        // Circle Positions
        int CircleX = 80;
        int CircleY = 80;
        // Scores
        int Score = 0;

        // Enemy Positions
        int BallX = 120;
        int BallY = 130;
        int BallSpeedX = 10;
        int BallSpeedY = 10;
        int BallRadius = 20;
        

        Raylib.InitWindow(500,400, "Dont Touch the Green Ball");
        Raylib.SetTargetFPS(30);

        while(!Raylib.WindowShouldClose())
        {
            if(Raylib.IsKeyDown(KeyboardKey.D)) { PosX += SpeedX; }
            if(Raylib.IsKeyDown(KeyboardKey.A)) { PosX -= SpeedX; }
            if(Raylib.IsKeyDown(KeyboardKey.W)) { PosY -= SpeedY; }
            if(Raylib.IsKeyDown(KeyboardKey.S)) { PosY += SpeedY; }
            
            BallX += BallSpeedX;
            BallY += BallSpeedY;

            if((BallX + BallRadius) > Raylib.GetScreenWidth())
            {
                BallX = Raylib.GetScreenWidth() - BallRadius;
                BallX *= -BallSpeedX;
            } else if(BallX < 0)
            {
                BallX = 0;
                BallX *= BallSpeedX;
            }

            if((BallY + BallRadius) > Raylib.GetScreenHeight())
            {
                BallY = Raylib.GetScreenHeight() - BallRadius;
                BallY *= -BallSpeedY;
            } else if(BallY < 0)
            {
                BallY = 0;
                BallY *= BallSpeedY;
            }

            // check collisions for screen
            Random rand = new Random();
            if(PosX < 0)
            {
                PosX = 0;
            } else if ((PosX + 30) > Raylib.GetScreenWidth())
            {
                PosX = Raylib.GetScreenWidth() - 30;
            }
            if(PosY < 0)
            {
                PosY = 0;
            } else if ((PosY + 30) > Raylib.GetScreenHeight())
            {
                PosY = Raylib.GetScreenHeight() - 30;
            }

            Rectangle PlayerRectangle = new Rectangle(PosX, PosY,50,50);
            Vector2 CoinCircle = new Vector2(CircleX, CircleY);
            Vector2 AnAssHoleBall = new Vector2(BallX, BallY);

            if(Raylib.CheckCollisionCircleRec(AnAssHoleBall, 10.0f, PlayerRectangle))
            {
                break;
            }

            if(Raylib.CheckCollisionCircleRec(CoinCircle, 30.0f, PlayerRectangle))
            {
                CircleX = rand.Next(0,Raylib.GetScreenWidth());
                CircleY = rand.Next(0,Raylib.GetScreenHeight());
                Score += 1;
            }
            

            Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.Black);
                Raylib.DrawRectangle(PosX, PosY, 50, 50, Color.Blue);
                Raylib.DrawCircle(CircleX, CircleY, 15, Color.Red);

                Raylib.DrawCircle(BallX,BallY, BallRadius, Color.Green);
                Raylib.DrawText("Score:"+ Score, 50, 10, 20, Color.White);
            Raylib.EndDrawing();
        }
        Raylib.CloseWindow();
    }
}