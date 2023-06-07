# Discord.NET Template [![dnet_version](https://img.shields.io/myget/discord-net/v/Discord.Net)](https://discordnet.dev/) [![issues](https://img.shields.io/github/issues/zobweyt/Discord.NET-Template)](https://github.com/zobweyt/Discord.NET-Template/issues)

<img src="https://user-images.githubusercontent.com/98274273/187032105-316cf322-c431-4a46-a14a-1de50123aa30.png" align="right" width="120" height="120">

This repository is a fully maintained template for creating an advanced [Discord.NET](https://github.com/discord-net/Discord.Net) application using the [interaction framework](https://discordnet.dev/faq/int_framework/framework.html) and [Discord.Addons.Hosting](https://github.com/Hawxy/Discord.Addons.Hosting).

<details>
  <summary>Table of Contents</summary>
  <ol>
    <li><a href="#key-features">Key Features</a></li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#step-1--clone-the-repository">Step 1 — Clone the repository</a></li>
        <li><a href="#step-2--manage-user-secrets-cli">Step 2 — Manage user secrets CLI</a></li>
        <li><a href="#step-3--run-the-dotnet-application">Step 3 — Run the dotnet application</a></li>
      </ul>
    </li>
    <li>
      <a href="#contribution">Contribution</a>
      <ul>
        <li><a href="#documentation">Documentation</a></li>
      </ul>
    </li>
  </ol>
</details>



## Key Features
* Easy configuration such as [ASP.NET Core](https://docs.microsoft.com/aspnet/core/introduction-to-aspnet-core).
* Contains abstract premade interaction commands.
* Provides solutions for convenient bot development.



## Getting Started

To start using the template, open a command prompt and follow these instructions:



### Step 1 — Clone the repository

Get a local copy and navigate to the cloned repository:

```sh
git clone https://github.com/zobweyt/Discord.NET-Template.git Template
cd Template/Template
```



### Step 2 — Manage user secrets CLI

Reduce the risk of accidentally adding secrets into source control:

```sh
dotnet user-secrets set Token ""
dotnet user-secrets set DevGuild 0
```



### Step 3 — Run the dotnet application


```
dotnet run
```

> **Note:**
Instead of using `dotnet run` to run application in production, create a deployment using the `dotnet publish` command and [deploy](https://discordnet.dev/guides/deployment/deployment.html) the published output.



## Contribution

We welcome contributions to enhance this repository's functionality and usability! When contributing new features, please keep in mind that documentation is a critical component of any successful project.

### Documentation

All new features must be accompanied by detailed [documentation comments](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/).

Please ensure that the documentation is kept up-to-date with any changes made to the feature. This will help ensure that the project remains accessible and usable for all users.

Thank you for your contributions!
