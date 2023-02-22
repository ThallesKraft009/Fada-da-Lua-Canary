using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.CommandsNext.Exceptions;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.SlashCommands;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;



public class Bot {

  public DiscordClient Client { get; private set; }
        public InteractivityExtension Interactivity { get; private set; }
        public CommandsNextExtension Commands { get; private set; }

        public async Task RunAsync() 
        {
            var json = string.Empty;
            using (var fs = File.OpenRead("config.json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                json = await sr.ReadToEndAsync();

          

            var configJson = JsonConvert.DeserializeObject<ConfigJSON>(json);

//var db = new MongoClient(configJson.mongo);

            var config = new DiscordConfiguration()
            {
                Intents = DiscordIntents.All,
                Token = configJson.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
            };

    Client = new DiscordClient(config);
    Client.UseInteractivity( new InteractivityConfiguration(){
      Timeout = TimeSpan.FromMinutes(2)
    });

    var commandsConfig = new CommandsNextConfiguration()
            {
                StringPrefixes = new string[] { configJson.Prefix },
                EnableMentionPrefix = true,
                EnableDms = true,
                EnableDefaultHelp = true,
            };

  Commands = Client.UseCommandsNext(commandsConfig);

      Commands.RegisterCommands<UtilCommands>();
          
          
    await Client.ConnectAsync();
    await Task.Delay(-1);

  }

  private Task OnClientReady(DiscordClient sender, DSharpPlus.EventArgs.ReadyEventArgs e)
        {
            return Task.CompletedTask;
    }

  private async Task OnCommandError(CommandErrorEventArgs e){
    

    await e.Context.RespondAsync("Ocorreu um erro!");


   }
  }