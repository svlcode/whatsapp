namespace ConsoleApp4
{
    class RegularMessage
    {
        private readonly string _sender;
        public RegularMessage(string body, string sender)
        {
            Body = body;
            _sender = sender;
        }

        public string Body { get; private set; }
        public string Sender 
        { 
            get { return _sender; }
        }
    }
}
