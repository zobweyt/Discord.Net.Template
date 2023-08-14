# Discord.Net.Template

This repository is a fully maintained template for creating an advanced [Discord.NET](https://github.com/discord-net/Discord.Net) application using the [interaction framework](https://discordnet.dev/faq/int_framework/framework.html) and [Discord.Addons.Hosting](https://github.com/Hawxy/Discord.Addons.Hosting).

[![CurrentVersion](https://img.shields.io/myget/discord-net/v/Discord.Net)](https://www.nuget.org/packages/Discord.Net)
[![OpenIssues](https://img.shields.io/github/issues/zobweyt/Discord.NET-Template)](https://github.com/zobweyt/Discord.Net.Template/issues)

## ☑️ Prerequisites

* [.NET](https://dotnet.microsoft.com/en-us/download) – The software development kit.
* [MySQL](https://dev.mysql.com/downloads/installer/) – The database provider used by this template.

## 📦 Installation

To start using the application, open a command prompt and follow these instructions:

### Step 1 — Clone the repository

Get a local copy and navigate to the cloned repository:

```sh
git clone https://github.com/zobweyt/Discord.Net.Template.git
cd Template/Template
```

### Step 2 — Configure the environment

We are using the [options pattern](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options) for strongly typed access to groups of related settings. You should configure the [`appsettings.json`](https://github.com/zobweyt/Discord.Net.Template/blob/main/Discord.Net.Template/appsettings.json) file or [manage user secrets](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets) via CLI:

```sh
dotnet user-secrets set <key> <value>
```

| Key                         | Type     | Description                                                                                          | Required |
| --------------------------- | -------- | ---------------------------------------------------------------------------------------------------- | -------- |
| `Links:Github`              | `string` | The URL to the open-source GitHub code of the application.                                           |          |
| `Links:Discord`             | `string` | The URL to your Discord community server.                                                            |          |
| `Startup:Token`             | `string` | The token obtained from the [Discord Developer Portal](https://discord.com/developers/applications). | &#9745;  |
| `Startup:TestingGuildId`    | `ulong`  | The ID of your server in the Discord used for development purposes.                                  | &#9745;  |
| `ConnectionStrings:Default` | `string` | The [connection string](https://www.connectionstrings.com/mysql) of your MySQL database.             | &#9745;  |

### Step 3 — Run the application

Pending database migrations will be applied automatically on startup:

```sh
dotnet run
```

> **Warning:**
Instead of using `dotnet run` to run application in production, create a deployment using the `dotnet publish` command and [deploy](https://discordnet.dev/guides/deployment/deployment.html) the published output.

## 🧪 Testing

This project utilizes the [xUnit](https://github.com/xunit/xunit) framework for creating test cases. It also incorporates [Moq](https://github.com/moq/moq) for mocking objects and [Bogus](https://github.com/bchavez/Bogus) to generate fake data. To run all the tests, execute the following command from the root directory in your command prompt:

```sh
dotnet test
```

## 🚀 Contributing

If you would like to contribute to this project, please read the [`CONTRIBUTING.md`](CONTRIBUTING.md) file. It provides details on our code of conduct and the process for submitting pull requests.

## ❤️ Acknowledgments

* [Discord.Net](https://github.com/discord-net/Discord.Net) – The Discord framework used.
  * [Discord.Net.Template](https://github.com/zobweyt/Discord.Net.Template) – The application template used.
  * [Discord.Addons.Hosting](https://github.com/Hawxy/Discord.Addons.Hosting) – Enables smooth execution of startup and background tasks.
  * [Fergun.Interactive](https://github.com/d4n3436/Fergun.Interactive) – Adds interactive functionality to commands.
* [Microsoft.EntityFrameworkCore](https://github.com/dotnet/efcore) – A modern object-database mapper.
  * [Pomelo.EntityFrameworkCore.MySql](https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql) – MySQL provider for Entity Framework Core.

See also the list of [contributors](https://github.com/zobweyt/Discord.Net.Template/contributors) who participated in this project.

## 📜 License

This project is licensed under the **MIT License** – see the [`LICENSE.md`](LICENSE.md) file for details.
