# Intellias Hackaton

## Summary

<Put here description of your tech decisions>
В качестве базы данных использую SQL Server 2019. В данной базе используем функциональность графических баз данных для реализации зависимостей между сущностями.
Реализовано в Visual Studio 2019, файл солюшина: HackathonSolution.sln

## Run

<Put here steps to run your solution>

```bash
# Go into the folder with solution and run:
$ docker-compose up
```
используется порт 8000 для сервисов.

тут swagger: https://localhost:8000/swagger/

тут сервисы: https://localhost:8000/

тут rabbitmq UI на порту 15672 (login guest:guest): http://localhost:15672/

## Test

<Put here steps to run your tests>

_Example_

```bash
# Go into the folder with solution and run:
$ dotnet test HackathonSolution.sln
```

## Notes

<Put here your notes if you have some>
