using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp4
{
    class Person
    {
        public string Name { get; set; }
        public List<Channel> MyChannels { get; set; }
        public List<Person> MyFriends { get; set; }
        private List<ChannelMessage> UnreadChannelMessages { get; set; }
        private List<ChannelMessage> ReadChannelMessages { get; set; }

        public Person()
        {
            MyChannels = new List<Channel>();

            UnreadChannelMessages = new List<ChannelMessage>();
            ReadChannelMessages = new List<ChannelMessage>();
        }

        public void RegisterChannel(Channel channel)
        {
            MyChannels.Add(channel);
            channel.Register(this);
        }

        public void ReceiveChannelMessage(ChannelMessage channelMessage)
        {
            UnreadChannelMessages.Add(channelMessage);
        }

        public IEnumerable<Message> ReadMessagesFromChannel(string channelName)
        {
            var channelMessages = this.UnreadChannelMessages
                .Where(cm => cm.Channel.Name == channelName).ToList();

            ReadChannelMessages.AddRange(channelMessages);
            UnreadChannelMessages.RemoveAll(cm => cm.Channel.Name == channelName);
            
            var messages = channelMessages.Select(cm => cm.Message);

            return messages;
        }

        public void SendMessageToChannel(string message, string channelName)
        {
            var channel = MyChannels.FirstOrDefault(ch => ch.Name == channelName);
            channel.AddMessage(new Message { Body = message, Sender = this });
        }
    }
}
