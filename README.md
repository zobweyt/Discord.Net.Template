# Discord.NET Template [![version](https://img.shields.io/myget/discord-net/v/Discord.Net)](https://discordnet.dev/)  [![release](https://img.shields.io/github/release-date/zobweyt/Discord.NET-Template)](https://github.com/zobweyt/Discord.NET-Template)

<img src="https://user-images.githubusercontent.com/98274273/187032105-316cf322-c431-4a46-a14a-1de50123aa30.png" align="right" width="120" height="120">

This repository is fully maintained template for creating a Discord bot with **applications commands** based on [Discord.Interactions](https://www.nuget.org/packages/Discord.Net.Interactions/) and [Discord.Addons.Hosting](https://www.nuget.org/packages/Discord.Addons.Hosting/).

<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#key-features">Key Features</a>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li>
      <a href="#advanced-configuration">Advanced Configuration</a>
      <ul>
        <li><a href="#user-secrets">User Secrets</a></li>
        <li><a href="#environment-variables">Environment Variables</a></li>
      </ul>
    </li>
    <li><a href="#license">License</a></li>
  </ol>
</details>



## Key Features
* Advanced console logging support.
* Easy configuration such as [ASP.NET Core](https://docs.microsoft.com/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-6.0).
* Completely maintained template.
* Contains premade slash commands: `avatar`, `latency` and `clean`.



## Getting started

To get a local copy up, running and become fully familiar with configuration, follow these simple steps.



### Prerequisites

* [.NET 6.0](https://dotnet.microsoft.com/download).
* [User Secrets](https://docs.microsoft.com/aspnet/core/security/app-secrets?view=aspnetcore-6.0&tabs=windows).
* [Environment Variables](https://en.wikipedia.org/wiki/Environment_variable).



### Installation

1. Clone the repository:
  ```sh
  git clone https://github.com/Zobweyt/Gudgeon.git
  ```
2. Configure [appsettings.json](https://github.com/Zobweyt/Discord.NET-Template/blob/master/appsettings.json) and [appsettings.Development.json](https://github.com/Zobweyt/Discord.NET-Template/blob/master/appsettings.Development.json) files found in the main directory.




## Advanced Configuration

Json file is not fully secured so you can commit it to your repository by mistake. The topics below will familiarize you with all the ways to protect your `token` and `guild id`.



### User Secrets

To configure user secrets on the local machine right click at **Project** > **Configure user secrets**, fill up secrets:
```json
{
  "Token": "",
  "DevGuild": 0,
}
```



### Environment Variables

1. Open powershell or click `win+r`:
  ```run
  powershell
  ```
2. Go to the project executable directory:
  ```sh
  cd TEMPLATE\bin\Debug\net6.0
  ```
3. Setting up the environment variables:
  ```sh
  $env:Token=""
  $env:DevGuild=0
  ```
4. Run the project:
  ```sh
  .\EXECUTABLE.exe
  ```



## License

Distributed under the MIT License. See [LICENSE](https://github.com/Zobweyt/Discord.NET-Template/blob/master/LICENSE.txt) for more information.
