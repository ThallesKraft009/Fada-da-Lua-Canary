using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;
using System;
using System.Threading.Tasks;

public class UtilCommands : BaseCommandModule {
  
   [Command("ping")]

     public async Task PingCommand(CommandContext ctx){

    await ctx.RespondAsync($"🏓 | Pong! **`{ctx.Client.Ping}ms`**!");
       
     }


  [Command("info")]
  public async Task InfoCommand(CommandContext ctx){

  
   var msg = new DiscordMessageBuilder()
      .AddEmbed(
        new DiscordEmbedBuilder()
         .WithColor(DiscordColor.Azure)
         .WithTitle("Minhas Informações")
      );
    
  }

  [Command("embed")]
    public async Task EmbedCommand(CommandContext ctx, string msg){

      Console.WriteLine(msg);

    if (msg == null || msg.Length == 0){
      await ctx.RespondAsync("Insira uma msg!");
    } else {

      var embedMessage = new DiscordMessageBuilder()
                .AddEmbed(new DiscordEmbedBuilder()

                .WithColor(DiscordColor.Azure)
                .WithTitle("Esse é meu título")
                .WithDescription($"{msg}")
                );

      await ctx.RespondAsync(embedMessage);

      }
    }
  }