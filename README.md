# Проект CrossPlatformLabs

Цей проект містить лабораторні роботи та тести. Для початку роботи, будь ласка, виконайте наступні кроки.

## Вимоги

- .NET SDK версії 8.0 або вище.

## Запуск проекту

1. Відкрийте термінал Developer PowerShell for VS 2022
2. Перейдіть до кореневої папки проекту

# lab1-3 INFO:
Запустити лабораторну:
```bash
dotnet build Build.proj -t:Run -p:Solution=lab1
```
Білд:
```bash
dotnet build Build.proj -t:Build -p:Solution=lab1
```
Тести:
```bash
dotnet build Build.proj -t:Test -p:Solution=lab1
```

Де `lab1` може бути замінена на `lab2`, щоб запустити лабораторну №2, `lab3` - лабораторна №3, тощо
