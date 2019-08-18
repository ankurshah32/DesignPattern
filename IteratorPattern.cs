using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
namespace IteratorOne
{
    //IEnumerable and IEnumerator

    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person("King");

            Person p2 = new Person("Kong");

            Person p3 = new Person("Fing");

            PersonList pl = new PersonList();
            pl.Add(p1);
            pl.Add(p2);
            pl.Add(p3);

            PersonEnum2 pe2 = (PersonEnum2)pl.GetEnumeratorBackwards();

            foreach (Person p in pl)
            {
                Console.WriteLine("Person's name is {0}", p.Name);
            }
            Console.WriteLine("----------------------------");
            
            pe2.Reset();
            while (pe2.MoveNext())
            {
                Person p = (Person)pe2.Current;
                Console.WriteLine("Person's name is {0}", p.Name);
            }

        }
    }
    class Person
    {
        private string _Name;
        
        public Person (string name)
        {
            _Name = name;
        }
        public string  Name
        {
            get
            {
                return _Name;
            }
        }
    }

    class PersonList:IEnumerable
    {
        private ArrayList persons;
        private PersonEnum personEnum;
        private PersonEnum2 personEnum2;
        public PersonList()
        {
            persons = new ArrayList();
            personEnum = new PersonEnum(persons);
            personEnum2 = new PersonEnum2(persons);
        }
        public IEnumerator GetEnumerator()
        {
            return personEnum;
        }
        public IEnumerator GetEnumeratorBackwards()
        {
            return personEnum2;
        }
        public void Add(Person p)
        {
            persons.Add(p);
        }
        public int Count()
        { 
          return persons.Count;
        }
    }
    class PersonEnum : IEnumerator
    {
        private ArrayList persons;
        int currPosition = -1;

        public PersonEnum(ArrayList personsList)
        {
            persons = personsList  ;
        }

        public object Current
        {
            get
            {
                if ((currPosition >= 0) && (currPosition < persons.Count))
                {
                    return persons[currPosition];
                }
                else
                    return null;
            }
        }
        public bool MoveNext()
        {
            currPosition++;
            if ((currPosition >= 0) && (currPosition < persons.Count))
                return true;
            else
                return false;
        }
        public void Reset()
        {
            currPosition = -1;
        }
    }

    class PersonEnum2 : IEnumerator
    {
        private ArrayList persons;
        int currPosition = -1;

        public PersonEnum2(ArrayList personsList)
        {
            persons = personsList;
            currPosition = personsList.Count;
        }

        public object Current
        {
            get
            {
                if ((currPosition >= 0) && (currPosition < persons.Count))
                {
                    return persons[currPosition];
                }
                else
                    return null;
            }
        }
        public bool MoveNext()
        {
            currPosition--;
            if ((currPosition >= 0) && (currPosition < persons.Count))
                return true;
            else
                return false;
        }
        public void Reset()
        {
            currPosition = persons.Count;
        }
    }

}
