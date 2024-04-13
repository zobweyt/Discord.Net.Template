# Discord.Net.Template

This project is a template for creating advanced [Discord.Net](https://github.com/discord-net/Discord.Net) applications using the [interaction framework](https://discordnet.dev/faq/int_framework/framework) and [Discord.Addons.Hosting](https://github.com/Hawxy/Discord.Addons.Hosting) with .NET ecosystem.

The primary objective of this project is to provide a ready-to-use template that allows developers to quickly start coding bot commands without the need to configure the entire application setup.

[![Version](https://img.shields.io/myget/discord-net/v/Discord.Net)](https://www.nuget.org/packages/Discord.Net)
[![OpenIssues](https://img.shields.io/github/issues/zobweyt/Discord.Net.Template)](https://github.com/zobweyt/Discord.Net.Template/issues)

## ☑️ Prerequisites

* The [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
* An app on the [developer portal](https://discord.com/developers)
* A [server](https://support.discord.com/hc/articles/204849977) for the bot development

## 📦 Usage

To start, open a command prompt and follow these instructions:

### Step 1 — Get the template

[Use](https://github.com/zobweyt/Discord.Net.Template/generate) this repository as a [template](https://docs.github.com/repositories/creating-and-managing-repositories/creating-a-repository-from-a-template), open it in your editor, and navigate to the startup project:

```sh
cd src/Template
```

### Step 2 — Configure the environment

We are using the [options pattern](https://learn.microsoft.com/aspnet/core/fundamentals/configuration/options) for typed access to groups of [related settings](https://github.com/zobweyt/Discord.Net.Template/blob/main/src/Template/Common/Options). You should configure the [`appsettings.json`](https://github.com/zobweyt/Discord.Net.Template/blob/main/src/Template/appsettings.json) file or manage [user secrets](https://learn.microsoft.com/aspnet/core/security/app-secrets) via [CLI](https://learn.microsoft.com/dotnet/core/tools):

```sh
dotnet user-secrets set <key> <value>
```

> **Note:**
You might also have noticed that there are several TODOs in the solution. They are not required to run and are designed to assist you with additional configuration.

### Step 3 — Run the application

Pending database migrations will be applied automatically on startup:

```sh
dotnet run
```

> **Warning:**
Instead of using the `dotnet run` in production, create a deployment using the `dotnet publish` command and [deploy](https://discordnet.dev/guides/deployment) the output.

### Further customization

Here's what you can also do:
* Modify all instances of “template” to reflect your application's name.
* Rewrite the [`README.md`](README.md) file to fit your needs.
* Follow the TODOs across the solution.

## 🧪 Testing

This project utilizes the [xUnit](https://github.com/xunit/xunit) framework for creating test cases. It also incorporates [Moq](https://github.com/moq/moq) for mocking objects and [Bogus](https://github.com/bchavez/Bogus) to generate fake data. To run all the tests, execute the following command from the root directory in your command prompt:

```sh
dotnet test
```

## 🚀 Contributing

To contribute to this project, please read the [`CONTRIBUTING.md`](.github/CONTRIBUTING.md) file. It provides details on our code of conduct and the process for submitting pull requests.

## ❤️ Acknowledgments

See the [contributors](https://github.com/zobweyt/Discord.Net.Template/contributors) who participated in this project and the [dependencies](https://github.com/zobweyt/Discord.Net.Template/network/dependencies) used.

## 📜 License

This project is licensed under the **MIT License** — see the [`LICENSE.md`](LICENSE.md) file for details.
