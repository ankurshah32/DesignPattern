/*
    In Uml is-a relation depict inheritance.
    Whlile has-a relation depict composition. 
 */
using System.Collections.Generic;

namespace StratergyPattern
{
    public abstract class SortStratergy
    {
        public abstract void Sort(ref List<string> list);
    }
    public class QuickSort : SortStratergy
    {
        public override void Sort(ref List<string> list)
        {
            System.Console.WriteLine("---------------QuickSort-----------------");
            list.Sort();
        }
    }
    public class ShellSort : SortStratergy
    {
        public override void Sort(ref List<string> list)
        {
            System.Console.WriteLine("---------------ShellSort------------------");
            list.Sort();
        }
    }

    public class MergeSort : SortStratergy
    {
        public override void Sort(ref List<string> list)
        {
            System.Console.WriteLine("---------------MergeSort-------------------");
            list.Sort();
        }
    }

    public class SortedList
    {
        private List<string> names;
        protected SortStratergy stratergy;
        public SortedList(SortStratergy stratergy)
        {
            this.stratergy = stratergy;
            this.names = new List<string>();
            this.FillList();
        }
        void FillList()
        {
            this.names.Add("Ramu");
            this.names.Add("Shaymu");
            this.names.Add("Abymu");
            this.names.Add("Zbymu");
            this.names.Add("bcbymu");
            this.names.Add("debymu");
        }
        public void Sort()
        {
            this.stratergy.Sort(ref this.names);
        }
        public void Display()
        {
            foreach (var name in names)
                System.Console.WriteLine(name);
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            SortedList list = new SortedList(new QuickSort());
            list.Sort();
            list.Display();

            SortedList list1 = new SortedList(new MergeSort());
            list1.Sort();
            list1.Display();
        }
    }
}
