<p align="center">
  <a href="https://github.com/discord-net/Discord.Net">
    <img width="100" src="https://github.com/zobweyt/Discord.Net.Template/assets/98274273/43b481b3-72b7-4669-98f7-74f41cf9e30b" alt="Discord.NET Logo" />
  </a>
</p>

<h1 align="center">
  Discord.Net.Template
</h1>

<p align="center">
  A template for building scalable and ready for production <a href="https://docs.discordnet.dev">Discord.NET</a> apps within the <a href="dotnet.microsoft.com">.NET</a> ecosystem.
</p>

<p align="center">
  <img src="https://img.shields.io/librariesio/github/zobweyt/Discord.Net.Template" alt="Dependencies" />
  <img src="https://img.shields.io/github/repo-size/zobweyt/Discord.Net.Template" alt="Size" />
  <img src="https://img.shields.io/github/created-at/zobweyt/Discord.Net.Template" alt="Creation Date" />
</p>

## 📦 Usage

To start, open a command prompt and follow these instructions:

### Step 1 — Get the template

[Use](https://github.com/zobweyt/Discord.Net.Template/generate) this repository as a [template](https://docs.github.com/repositories/creating-and-managing-repositories/creating-a-repository-from-a-template), open it in your editor, and navigate to the startup project:

```sh
cd src/Template
```

### Step 2 — Configure the environment

We are using the [options pattern](https://learn.microsoft.com/aspnet/core/fundamentals/configuration/options) for typed access to groups of [related settings](./src/Template/Common/Options). You should configure the [`appsettings.json`](./src/Template/appsettings.json) file or manage [user secrets](https://learn.microsoft.com/aspnet/core/security/app-secrets) via [CLI](https://learn.microsoft.com/dotnet/core/tools):

```sh
dotnet user-secrets set <key> <value>
```

> [!NOTE]
> Pending database migrations are applied automatically [before startup](./src/Template/Program.cs#L49) and an informational [message](./src/Template/Extensions/HostExtensions.cs#L29) is logged.

### Step 3 — Run the app

To run the bot, just execute the following command: 

```sh
dotnet watch
```

The initial setup is done. Enjoy using the template! 🎉

> [!WARNING]
> Instead of using the `dotnet run` in production, create a deployment using the `dotnet publish` command and [deploy](https://docs.discordnet.dev/guides/deployment/deployment) the output.

## 🎨 Customization

Here is what you can also do:
- [ ] Follow the TODO comments across the entire solution.
- [ ] Find and replace all occurrences of "template" to fit your app's name.
- [ ] Rewrite the [`README.md`](README.md) file to fit your needs.

> [!TIP]
> Take a look at the [discord-md-badge](https://github.com/gitlimes/discord-md-badge) project which is a customizable badge that shows your or a bot account status, or a server invite.

## 🧪 Testing

This project utilizes the [xUnit](https://github.com/xunit/xunit) framework for creating test cases. It also incorporates [Moq](https://github.com/moq/moq) for mocking objects and [Bogus](https://github.com/bchavez/Bogus) to generate fake data.

To run all the [tests](./test), execute the following command from the root directory in your command prompt:

```sh
dotnet test
```

## 🚀 Contributing

To contribute to this project, please read the [`CONTRIBUTING.md`](.github/CONTRIBUTING.md) file. It provides details on our code of conduct and the process for submitting pull requests.

## ❤️ Acknowledgments

See the [contributors](https://github.com/zobweyt/Discord.Net.Template/contributors) who participated in this project and the [dependencies](https://github.com/zobweyt/Discord.Net.Template/network/dependencies) used.

## 📜 License

This project is licensed under the **MIT License** — see the [`LICENSE.md`](LICENSE.md) file for details.
