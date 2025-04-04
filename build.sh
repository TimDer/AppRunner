#echo "$(realpath $(dirname $0))"
dotnet publish "$(realpath $(dirname $0))/src/runner/AppRunner.csproj" -o "$(realpath $(dirname $0))/AppRunnerDist" --self-contained