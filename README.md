# Discord.NET Template [![version](https://img.shields.io/myget/discord-net/v/Discord.Net)](https://discordnet.dev/)  ![issues](https://img.shields.io/github/issues/zobweyt/Discord.NET-Template)

<img src="https://user-images.githubusercontent.com/98274273/187032105-316cf322-c431-4a46-a14a-1de50123aa30.png" align="right" width="120" height="120">

This repository is fully maintained template for creating a Discord bot with **applications commands** based on [Discord.Interactions](https://www.nuget.org/packages/Discord.Net.Interactions/) and [Discord.Addons.Hosting](https://www.nuget.org/packages/Discord.Addons.Hosting/).

<details>
  <summary>Table of Contents</summary>
  <ol>
    <li><a href="#key-features">Key Features</a></li>
    <li><a href="#getting-started">Getting Started</a></li>
    <li>
      <a href="#advanced-configuration">Advanced Configuration</a>
      <ul>
        <li><a href="#user-secrets">User Secrets</a></li>
        <li><a href="#environment-variables">Environment Variables</a></li>
      </ul>
    </li>
    <li><a href="#contribution">Contribution</a></li>
  </ol>
</details>



## Key Features
* Advanced console logging support.
* Easy configuration such as [ASP.NET Core](https://docs.microsoft.com/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-6.0).
* Completely maintained template.
* Contains premade slash commands: `avatar`, `latency` and `clean`.



## Getting started

To start using the template, clone the repository and place your token in the `appsettings.json` and `appsettings.Development.json` files found in the main directory.



## Advanced Configuration

Json files are not fully secured, so you may mistakenly commit them with token in your repository. The topics below will introduce you to all the ways to secure the token.



### User Secrets

User secrets are designed specifically for development. **They will not load** in `"DOTNET_ENVIRONMENT": "Production"`. To configure user secrets on the local machine right click at "**Project**" > "**Configure user secrets**", fill up the secrets:
```json
{
  "Token": "",
  "DevGuild": 0,
}
```



### Environment Variables

This topic is needed if you are running the template in `"DOTNET_ENVIRONMENT": "Production"`.

1. Open powershell and navigate to the directory containing the project executable:
  ```sh
  cd bot\bin\Debug\net6.0
  ```
2. Set up the environment variables:
  ```sh
  $env:Token=""
  $env:DevGuild=0
  ```
3. Run the project:
  ```sh
  .\bot.exe
  ```
  
  
  
## Contribution

Feel free to open an issue, contribute or suggest new ideas to improve this repository!
