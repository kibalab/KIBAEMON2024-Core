using System.Reflection;
using Discord;
using Discord.WebSocket;
using KIBAEMON2024_CSharp.System;
using Newtonsoft.Json;

namespace KIBAEMON2024_Core.Struct;

[Serializable]
public class Bot
{
    public string Name { get; init; }
    public string Prefix { get; set; } = "?";
    public Authorization Authorization { get; init; } = Authorization.Empty;

    [JsonIgnore] public DiscordSocketClient Client { get; init; } = new(new DiscordSocketConfig { GatewayIntents = GatewayIntents.All, MessageCacheSize = 1000 });

    [JsonIgnore] public CommandManager CommandManager { get; init; }

    [JsonIgnore] public Dictionary<Type, IService> Services { get; } = [];

    public Bot(string name = "UnknownBot")
    {
        Name = name;
        Console.WriteLine($"Bot {Name} created.");

        CommandManager = new CommandManager(this);
    }

    public T GetService<T>() where T : IService
    {
        if (!Services.ContainsKey(typeof(T)))
        {
            Services.Add(typeof(T), (T)Activator.CreateInstance(typeof(T))!);
        }

        return (T)Services[typeof(T)];
    }
}