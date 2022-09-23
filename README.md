# Discord.NET Template [![dnet_version](https://img.shields.io/myget/discord-net/v/Discord.Net)](https://discordnet.dev/)  [![issues](https://img.shields.io/github/issues/zobweyt/Discord.NET-Template)](https://github.com/zobweyt/Discord.NET-Template/issues)

<img src="https://user-images.githubusercontent.com/98274273/187032105-316cf322-c431-4a46-a14a-1de50123aa30.png" align="right" width="120" height="120">

This repository is a fully maintained template for creating an advanced Discord.NET bot with slash commands using [Discord.Addons.Hosting](https://www.nuget.org/packages/Discord.Addons.Hosting/).

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
* Contains premade slash commands: **avatar**, **latency** and **clean**.



## Getting started

To start using the template, clone the repository and configure the [appsettings.json](https://github.com/zobweyt/Discord.NET-Template/blob/master/appsettings.json) and [appsettings.Development.json](https://github.com/zobweyt/Discord.NET-Template/blob/master/appsettings.Development.json) files found in the main directory.



## Advanced Configuration

Json files are not fully secured, so you may mistakenly commit them with token in your repository. The topics below will introduce you to all the ways to secure your configuration.



### User Secrets

User secrets are designed specifically for development. **They will not load** in `"DOTNET_ENVIRONMENT": "Production"`. To configure user secrets on the local machine right click at "**Project**" > "**Configure user secrets**" then fill up the secrets:
```json
{
  "Token": "",
  "DevGuild": 0,
}
```



### Environment Variables

This topic is needed to read if you are running the template in production.
```sh
# Switch to the directory containing the project executable
cd bot\bin\Debug\net6.0

# Set up the environment variables
$env:Token=""
$env:DevGuild=0

# Run the project
.\bot.exe
```


  
## Contribution

Feel free to open an issue, contribute or suggest new ideas to improve this repository!
