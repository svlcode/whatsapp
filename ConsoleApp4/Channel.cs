using System.Collections.Generic;

namespace ConsoleApp4
{
    class Channel
    {
        public string Name { get; set; }
        public List<Person> Members { get; set; }
        public List<Message> Messages { get; set; }

        public Channel()
        {
            Members = new List<Person>();
            Messages = new List<Message>();
        }
       

        public void NotifyMembers(Message message)
        {
            foreach (var member in Members)
            {
                if(member != message.Sender)
                    member.ReceiveChannelMessage(new ChannelMessage { Channel = this, Message = message });
            }
        }

        public void AddMessage(Message message)
        {
            Messages.Add(message);
            NotifyMembers(message);
        }

        public void Register(Person observer)
        {
            Members.Add(observer);
        }

        public void Uregister(Person observer)
        {
            Members.Remove(observer);
        }

    }
}
