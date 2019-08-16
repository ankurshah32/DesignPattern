namespace AbstractFactory
{
    public interface IGUIFactory
    {
        IWinFactory GetWindowGui();
        IMacFactory GetMacGui();
        IMobileFactory GetMobileGui();
    }
    // Added a new Web GUI buttons without changing the existing code
    public interface IGUIFactory1 : IGUIFactory
    {
        IWebFactory GetWebGui();
    }
    public interface IAbstractFactory
    {
        void CreateBtn();
        void CreateChkBox();
    }
    public interface IWinFactory: IAbstractFactory { }
    public interface IMacFactory: IAbstractFactory { }
    public interface IMobileFactory: IAbstractFactory { }
    // Added a new Web GUI buttons without changing the existing code
    public interface IWebFactory : IAbstractFactory { }
    public class ConcreteFactory : IGUIFactory
    {
        public IMacFactory GetMacGui()
        {
            return new Mac();
        }

        public IMobileFactory GetMobileGui()
        {
            return new Mobile();
        }

        public IWinFactory GetWindowGui()
        {
            return new Win();
        }
    }
    // Added a new concrete class for new Web GUI
    public class ConcreteFactory1 : ConcreteFactory, IGUIFactory1
    {
        public IWebFactory GetWebGui()
        {
            return new Web(); ;
        }
    }

    public class Web : IWebFactory
    {
        public void CreateBtn()
        {
            Console.WriteLine("Web Button");
        }

        public void CreateChkBox()
        {
            Console.WriteLine("Web Checkbox");
        }
    }
    public class Win : IWinFactory
    {
        public void CreateBtn()
        {
            Console.WriteLine("Window Button");
        }

        public void CreateChkBox()
        {
            Console.WriteLine("Window Checkbox");
        }
    }
    public class Mac : IMacFactory
    {
        public void CreateBtn()
        {
            Console.WriteLine("Mac Button");
        }

        public void CreateChkBox()
        {
            Console.WriteLine("Mac Checkbox");
        }
    }
    public class Mobile : IMobileFactory
    {
        public void CreateBtn()
        {
            Console.WriteLine("Mobile Button");
        }

        public void CreateChkBox()
        {
            Console.WriteLine("Mobile Checkbox");
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            IGUIFactory1 fact = new ConcreteFactory1();
            fact.GetMacGui().CreateBtn();
            fact.GetWebGui().CreateBtn();
        }
    }
}
