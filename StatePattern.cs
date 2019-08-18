using System;
using System.Collections;
namespace IteratorOne
{
    class Program
    {
        static void Main(string[] args)
        {
            Candidate c = new Candidate("Tom");

            c.context.SetNextState();
            c.context.SetNextState();
            c.context.SetNextState();
            c.context.SetNextState();
        }
    }
    //State Sequence NewState -> Pending for Approval State -> RejectedState or ApprovedState
    public class Candidate
    {
        public string name { get; set; }
        public ObjectState CurrentState { get; set; }
        public StateContext context { get; set; }
        public Candidate(string name)
        {
            this.name = name;
            this.context = new StateContext();
        }
    }
    public class StateContext
    {
        public ObjectState _currentState { get; set; }
        private System.Collections.Generic.List<ObjectState> StateSeq;
        private readonly IEnumerator StateSeqItr;
        public StateContext()
        {
            this.StateSeq = new System.Collections.Generic.List<ObjectState>();
            IntailizeState();
            this.StateSeqItr = this.StateSeq.GetEnumerator();
            this.StateSeqItr.MoveNext();
            this._currentState = (ObjectState)this.StateSeqItr.Current;
            this._currentState.MyState();
        }

        private void IntailizeState()
        {
            this.StateSeq.Add(new NewState());
            this.StateSeq.Add(new PendingState());
            this.StateSeq.Add(new ApprovedState());
            this.StateSeq.Add(new RejectedState());
        }
        public ObjectState GetInitalState() {
            return this._currentState;
        }

        public void SetNextState()
        {
            if (this.StateSeqItr.MoveNext())
            {
                this._currentState = (ObjectState)this.StateSeqItr.Current;
                this._currentState.MyState();
            }
        }
    }
    public interface ObjectState
    {
        void MyState();
    }
    public class NewState : ObjectState
    {
        public void MyState()
        {
            Console.WriteLine("New State");
        }
    }
    public class PendingState : ObjectState
    {
        public void MyState()
        {
            Console.WriteLine("Pending State");
        }
    }

    public class ApprovedState : ObjectState
    {
        public void MyState()
        {
            Console.WriteLine("Approved State");
        }
    }

    public class RejectedState : ObjectState
    {
        public void MyState()
        {
            Console.WriteLine("Rejected State");
        }
    }
}
