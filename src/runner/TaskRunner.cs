using System.Diagnostics;
using System.Text;

namespace AppRunner
{
    public class TaskRunner
    {
        private List<Command> _Commands { get; set; }

        public TaskRunner()
        {
            _Commands = new List<Command>();
        }

        public void AddCommands(List<Command> arguments) {
            foreach (Command argument in arguments)
            {
                _Commands.Add(argument);
            } 
        }

        public async Task Run() {
            if (_Commands == null) {
                return;
            }

            List<Task<string>> tasks = new List<Task<string>>();
            foreach (Command command in _Commands) {
                tasks.Add(RunCommand(command));
            }

            await Task.WhenAll(tasks);
        }

        private Task<string> RunCommand(Command command) {
            return Task.Run(() => {
                Process process = new Process();

                process.StartInfo.FileName = "/bin/bash";
                process.StartInfo.Arguments = $"-c \"{command.CLI}\"";
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;

                StringBuilder output = new StringBuilder();
                process.OutputDataReceived += (sender, args) => {
                    if (!string.IsNullOrEmpty(args.Data)) {
                        Console.WriteLine(command.Name + ": " + args.Data);
                        output.AppendLine(command.Name + ": " + args.Data);
                    }
                };

                process.Start();
                process.BeginOutputReadLine();
                process.WaitForExit();

                return output.ToString();
            });
        }
    }
}