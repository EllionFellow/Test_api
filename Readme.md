﻿# Задача
Используя .Net или .Net Core (предпочтительнее), СУБД (MS SQL или Postgre) необходимо реализовать API поддерживающее следующий функционал:
1. Хранение информации о сотрудниках и их должностях. В предметной области применяются следующие сущности:
Сотрудник: ФИО, дата рождения
Должность: Название, Грейд (числовое значение от 1 до 15)
Сотрудники и должности связаны отношением многие-ко-многим
2. REST JSON API поддерживающие следующие методы:
Получение информации о сотруднике и всех его должностях
Сохранение (добавление нового и изменение существующего) информации о сотруднике и его должностях
Удаление сотрудника
Получение информации по должности
Сохранение (добавление новой и изменение существующей) информации о должности
Удаление должности (удаление должностей к которым привязаны сотрудники должно быть заблокировано)
API должно поддерживать Swagger или логирование (предпочтительнее Swagger)
Решение необходимо выложить на GitHub или прислать в виде zip архива с паролем 123 (пароль, чтобы почтовый сервис не удалил архив).
___

# Стек
.Net Core
Dapper
PostgreSQL
___

# Скрипт базы данных
Полный скрипт базы данных описан в файле
```
DB Script.txt
```

# Строка подключения
находится в 
```
AppSettings.json
```

# Swagger
Доступен из корня приложения

# URL
http://localhost:5000
