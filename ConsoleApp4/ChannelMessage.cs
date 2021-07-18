namespace ConsoleApp4
{
    class ChannelMessage : RegularMessage
    {
        public ChannelMessage(string body, string sender, string channel) : base(body, sender)
        {
            Channel = channel;
        }
        public string Channel { get; private set; }
    }
}
