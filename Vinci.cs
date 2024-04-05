
using Discord;

using Discord.WebSocket;

using System;

using System.Collections.Generic;

using System.Threading.Tasks;

using System.Threading;
 
class Program

{

    private DiscordSocketClient _client;

    private Timer _timer;

    private Random _random;

    private List<string> _flachwitze;

    private ulong CHANNEL_ID = 1181933479332679682; // Ersetze dies durch die tatsächliche ID deines Zielkanals

    static async Task Main(string[] args)

    {

        var program = new Program();

        await program.RunBotAsync();

    }

    public async Task RunBotAsync()

    {

        _client = new DiscordSocketClient();

        _random = new Random();

        _client.Log += LogAsync;

        _client.Ready += OnReady;

        string token = "MTIyMDc0NjQ1MjQxMDU2NDc1OQ.GyfhmX.31tngPFcxjr_Wdq66mvz2VkiemgHBUNhdRK8Yg";

        await _client.LoginAsync(TokenType.Bot, token);

        await _client.StartAsync();

        // Liste von Flachwitzen initialisieren

        InitializeFlachwitze();

        // Timer initialisieren, der alle 1 Minute ausgelöst wird

        _timer = new Timer(async (_) => await SendFlachwitz(), null, TimeSpan.Zero, TimeSpan.FromMinutes(1));

        await Task.Delay(-1);

    }

    private Task LogAsync(LogMessage log)

    {

        Console.WriteLine(log);

        return Task.CompletedTask;

    }

    private Task OnReady()

    {

        Console.WriteLine("Bot is connected and ready!");

        return Task.CompletedTask;

    }

    private void InitializeFlachwitze()

    {

        // Hier kannst du eine Liste von Flachwitzen hinzufügen

        _flachwitze = new List<string>

        {

            "Warum hat der Mathematiker eine Brille? Weil er zahlen muss.",

            "Was ist gelb und kann nicht schwimmen? Ein Bagger.",

            "Was ist orange und hüpft durch den Wald? Ein Hupfkürbis.",

            "Was macht ein Clown im Büro? Faxen.",

            "Warum sitzen Vögel auf Stromleitungen? Weil sie keine Steckdosen finden.",

            "Was ist grün und hat vier Räder? Gras, ich habe gelogen wegen den Rädern.",

            "Warum hat der Hai einen Anwalt? Weil er Haifischbecken möchte.",

            "Was ist weiß und stört beim Essen? Eine Lawine.",

            "Was ist grün und steht vor der Tür? Ein Klopfsalat.",

            "Was ist braun und hüpft durch den Wald? Ein Hase."

        };

    }

    private async Task SendFlachwitz()

    {

        var channel = _client.GetChannel(CHANNEL_ID) as ISocketMessageChannel;

        // Überprüfe, ob das channel-Objekt nicht null ist

        if (channel != null)

        {

            int index = _random.Next(_flachwitze.Count);

            string flachwitz = _flachwitze[index];

            await channel.SendMessageAsync(flachwitz);

        }

        else

        {

            Console.WriteLine("Kanal nicht gefunden oder keine Berechtigung zum Senden von Nachrichten.");

        }

    }

}
