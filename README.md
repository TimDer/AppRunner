# AppRunner
AppRunner is a tool to run multiple bash commands simultaneously. Which is very handy if you are developing an app and need to run the backend and the frontend at the same time.

## How to build
To use the AppRunner tool you need to build the executable with the build.sh bash script.

```
$ ./build.sh
```

When you have build the executable you can copy or cut it to your desired destination.

## How to use
The AppRunner can be used in two ways. You can use the json method or you can directly give the commands to the AppRunner.

### Json
You can use the following json configuration with the following command.

Command:
```
$ ./AppRunnerDist/AppRunner -json /path/to/jsonfile.json
```

Json configuration:
```
[
    {
        "Name": "List all files",
        "CLI": "ls -lash"
    },
    {
        "Name": "Echo test",
        "CLI": "echo 'hello world'"
    }
]
```

### Directly
If you want to directly give commands you can do so as follows.

```
$ ./AppRunnerDist/AppRunner "ls -lash" "echo 'hello world'"
```