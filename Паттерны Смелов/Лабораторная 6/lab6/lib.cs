using Lab6Lib;
using System;
using System.Collections.Generic;

namespace Lab6Lib
{
    public interface ISubscriber
    {
        void update(string eventname);
    }

    public class Publisher
    {
        private string _eventname;
        private List<ISubscriber> _subscribers = new List<ISubscriber>();

        public Publisher(string eventname)
        {
            _eventname = eventname;
        }

        public void subscribe(ISubscriber subscriber)
        {
            _subscribers.Add(subscriber);
        }

        public bool unsubscribe(ISubscriber subscriber)
        {
            return _subscribers.Remove(subscriber);
        }


        public int nonify()
        {
            foreach (ISubscriber subscriber in _subscribers)
            {
                subscriber.update(_eventname);
            }
            return _subscribers.Count;
        }
    }
}

public class NEW : Publisher
{
    public NEW(string eventName) : base(eventName)
    {
    }
}