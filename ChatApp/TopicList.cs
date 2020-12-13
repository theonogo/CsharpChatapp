using System.Collections.Generic;

namespace ChatApp
{
    public class TopicList
    {
        public List<Topic> _topics;

        public TopicList()
        {
            _topics= new List<Topic>();
        }

        public bool newTopic(string name)
        {
            foreach (Topic t in _topics)
            {
                if (t.Name.Equals(name)) return false;
            }
            
            _topics.Add(new Topic(name));
            return true;
        }

        public override string ToString()
        {
            string outStr = _topics.Count + " Topics: \n";
            foreach (Topic t in _topics)
            {
                outStr += t;
            }
            return base.ToString();
        }
    }
}