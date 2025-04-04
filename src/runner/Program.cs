using AppRunner;

TaskRunner taskRunner = new TaskRunner();
CommandsConstructor commandsConstructor = new CommandsConstructor(args);

taskRunner.AddCommands(
    commandsConstructor.GetCommands());

await taskRunner.Run();