using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp4
{
    class Person : IMessageReceiver
    {
        public string Name { get; set; }
        private List<Channel> _myChannels;
        private List<Person> _myFriends;


        public Person()
        {
            _myChannels = new List<Channel>();
            _myFriends = new List<Person>();
        }

        public void RegisterChannel(Channel channel)
        {
            _myChannels.Add(channel);
            channel.Register(this);
        }

        public void AddFriend(Person friend)
        {
            _myFriends.Add(friend);
        }

        public void ReceiveChannelMessage(ChannelMessage channelMessage)
        {
            Console.WriteLine($"{channelMessage.Channel}:{channelMessage.Sender}: {channelMessage.Body}");
        }

        public void SendMessageToFriend(string message, string friendName)
        {
            var friend = _myFriends.FirstOrDefault(f => f.Name == friendName);
            if(friend != null)
            {
                friend.ReceiveMessage(new RegularMessage(message, Name));
            }
            else
            {
                Console.WriteLine($"Cannot send message! The person {friendName} is not a friend.");
            }
        }

        public void ReceiveMessage(RegularMessage message)
        {
            Console.WriteLine($"{message.Sender}: {message.Body}");
        }

        public void SendMessageToChannel(string message, string channelName)
        {
            var channel = _myChannels.FirstOrDefault(ch => ch.Name == channelName);
            if(channel != null)
            {
                channel.ReceiveMessage(new RegularMessage(message, Name));
            }
            else
            {
                Console.WriteLine($"Cannot send message! You are not registered to the channel {channelName}");
            }
        }
    }
}
