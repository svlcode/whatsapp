using System;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {

            Channel channel = new Channel();
            channel.Name = "CApRe";

            Person p1 = new Person();
            p1.Name = "Vio";
            p1.RegisterChannel(channel);

            Person p2 = new Person();
            p2.Name = "Mady";
            p2.RegisterChannel(channel);


            p1.SendMessageToChannel("Hello, everyone!", "CApRe");
            p1.SendMessageToChannel("ce faceti?", "CApRe");

            //var messages = p2.ReadMessagesFromChannel("CApRe");

            //foreach (var message in messages)
            //{
            //    Console.WriteLine($"{message.Sender}: {message.Body}");
            //}
        }
    }
}
