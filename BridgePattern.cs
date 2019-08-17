/*
The Bridge pattern lets you split the monolithic class into several class hierarchies. 
After this, you can change the classes in each hierarchy independently of the classes in the others.
This approach simplifies code maintenance and minimizes the risk of breaking existing code.
 */

namespace BridgePattern
{
    public interface IDraw
    {
        void DrawCircle(int x, int y, int radius);
        void DrawRectangle(int x, int y, int height, int width);
    }
    public class DrawAPI01 : IDraw
    {
        public void DrawCircle(int x, int y, int radius)
        {
            System.Console.WriteLine(" DrawAPI01 : DrawCircle called");
        }

        public void DrawRectangle(int x, int y, int height, int width)
        {
            System.Console.WriteLine(" DrawAPI01 : DrawRectangle called");
        }
    }
    public class DrawAPI02 : IDraw
    {
        public void DrawCircle(int x, int y, int radius)
        {
            System.Console.WriteLine(" DrawAPI02 : DrawCircle called");
        }

        public void DrawRectangle(int x, int y, int height, int width)
        {
            System.Console.WriteLine(" DrawAPI02 : DrawRectangle called");
        }
    }
    public interface IDrawShapes
    {
        void CallCircle();
        void CallRectangle();
    }
    public class DrawShapes : IDrawShapes
    {
        IDraw _shape;
        public DrawShapes(IDraw shape)
        {
            this._shape = shape;
        }
        public void CallCircle()
        {
            this._shape.DrawCircle(0, 0, 5);
        }

        public void CallRectangle()
        {
            this._shape.DrawRectangle(0, 0, 5, 10);
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            IDrawShapes api01 = new DrawShapes(new DrawAPI01());
            api01.CallCircle();
            api01.CallRectangle();

            IDrawShapes api02 = new DrawShapes(new DrawAPI02());
            api02.CallCircle();
            api02.CallRectangle();
        }
    }
}