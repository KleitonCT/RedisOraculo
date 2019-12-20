using StackExchange.Redis;
using System;

namespace RedisOraculo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Connect
            var redis = ConnectionMultiplexer.Connect("13.65.194.91");
            IDatabase db = redis.GetDatabase();
            string channel = "Perguntas";


            var sub = redis.GetSubscriber();
            sub.Subscribe(channel, (ch, msg) =>
            {
                string pergunta = msg.ToString().Split(":")[0];
                sub.Publish(ch, string.Concat(pergunta, "Resposta"));
            });
        }
    }
}
