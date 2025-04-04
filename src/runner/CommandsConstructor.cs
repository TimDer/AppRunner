namespace AppRunner
{
    class CommandsConstructor
    {
        public string[] _commandsFromArgs { get; set; }
        public string[]? _commandsFromJson { get; set; }

        public CommandsConstructor(string[] commandsFromArgs)
        {
            _commandsFromArgs = commandsFromArgs;
        }

        public List<Command> GetCommands()
        {
            var isJson = CheckIfUsingJson();

            if (isJson)
            {
                return GetJsonCommands();
            }

            return GetArgsCommands();
        }

        private Boolean CheckIfUsingJson()
        {
            if (_commandsFromArgs != null && _commandsFromArgs[0] == "-json")
            {
                return true;
            }

            return false;
        }

        private List<Command> GetArgsCommands()
        {
            List<Command> commands = new List<Command>();

            foreach (string item in _commandsFromArgs)
            {
                commands.Add(new Command {
                    Name = item,
                    CLI = item
                });
            }

            return commands;
        }

        private List<Command> GetJsonCommands()
        {
            try
            {
                List<Command> commands = JsonReader.GetJsonDataFromFile<List<Command>>(_commandsFromArgs[1]);

                return commands;
            }
            catch (Exception ex)
            {
                List<Command> commands = new List<Command>();
                return commands;
            }
        }
    }
}