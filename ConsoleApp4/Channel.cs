using System.Collections.Generic;

namespace ConsoleApp4
{
    class Channel : IMessageReceiver
    {
        public string Name { get; set; }
        public List<Person> Members { get; set; }
        public List<RegularMessage> Messages { get; set; }

        public Channel()
        {
            Members = new List<Person>();
            Messages = new List<RegularMessage>();
        }
       

        private void NotifyMembers(RegularMessage message)
        {
            foreach (var member in Members)
            {
                if(member.Name != message.Sender)
                {
                    var channelMessage = new ChannelMessage(message.Body, message.Sender, this.Name);
                    member.ReceiveChannelMessage(channelMessage);
                }
            }
        }

        public void ReceiveMessage(RegularMessage message)
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
