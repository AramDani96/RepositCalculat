namespace Practic_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Snake snake = new Snake();
            Food food = new Food();
            food.GeneretFood();
            while (true) 
            {
                snake.Move();
                snake.Draw();
                snake.ChangeDirection();
                food.DrowFood();
                if (snake.EatFood(food))
                {
                    food.GeneretFood();
                }
                Thread.Sleep(100);
            }
        }
    }
    class Food
    {
        public Point Position { get; set; }
        Random random = new Random();
        public void GeneretFood()
        {
            Position.X = random.Next(1, 50);
            Position.Y = random.Next(1, 50);
        }

        public void DrowFood()
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write("?");
        }
    }
    class Snake
    {
        public Location direction;
        public Point Points { get; set; }

        public Snake()
        {
           direction = Location.Right;
            Points = new Point()
            {
                X = 6,
                Y = 6
            };
        }
        public bool EatFood(Food food)
        {
            if (Points.X == food.Position.X && Points.Y == food.Position.Y)
            {
                return true;
            }
            return false;
        }
        public void Move()
        {
            switch (direction)
            {
                case Location.Up:
                    Points.Y--;
                    break;
                case Location.Down:
                    Points.Y++;
                    break;

                case Location.Left:
                    Points.X--;
                    break;

                case Location.Right:
                    Points.X++;
                    break;

            }
        }
        public void Draw()
        {
            Console.Clear();
            Console.SetCursorPosition(Points.X, Points.Y);
            Console.Write("#");
        }
        public void ChangeDirection()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        direction = Location.Up;
                        break;
                    case ConsoleKey.DownArrow:
                        direction = Location.Down;
                        break;
                    case ConsoleKey.LeftArrow:
                        direction = Location.Left;
                        break;
                    case ConsoleKey.RightArrow:
                        direction = Location.Right;
                        break;
                }
            }
        }
    }

    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    enum Location
    {
        Up, Down, Left, Right
    }
}
