# 💰 MyFinProject Backend

> "Финансы поют романсы? - тогда тебе поможет наш проект!"
## 📚 Описание проекта

MyFinProject Backend — это серверная часть приложения для управления личными финансами. Проект разработан с использованием ASP.NET Core 3.1 и предназначен для обработки операций, связанных с доходами, расходами и инвестициями пользователей.

## 🚀 Технологический стек

- **Язык программирования:** C#
- **Фреймворк:** ASP.NET Core 3.1
- **База данных:** PostgreSQL SQL Server



## 🏗️ ERD DataBase
![picture.jpeg](image/picture.jpeg)




### 🎛️ Основные модули Backend

1. **Controllers**  
   Принимают входящие HTTP-запросы. Поддерживают REST-стиль, четко разделяют CRUD и обеспечивают простоту интеграции со Swagger'ом.

2. **Services**  
   Бизнес-логика. Не просто классы, а мыслящие механизмы, отделенные от деталей реализации. Работают через интерфейсы, потому что SOLID.

3. **Models**  
   Entity

4. **DTO**

    Модели, которые принимает пользователь?

5. **ApplicationDbContext**  
   Класс-контекст, через который идут все обращения к БД. Настроен на строгую миграционную дисциплину.

---

## 🔐 Аутентификация и безопасность


- **Azure Active Directory (Azure AD):** для аутентификации API.
- **Managed Identity:** для безопасного доступа к Key Vault и SQL Database без хранения секретов в коде.


| Элемент                       | Метод                                          | Комментарий                              |
|-------------------------------|------------------------------------------------|------------------------------------------|
| Защита API                    | Middleware с проверкой JWT и Audience          | Без валидного токена — никакого JSON     |
| HTTPS                        | Включен по умолчанию                           | ---------                                |
| CORS                         | Гибко настраиваемый через `Startup.cs`         | Только доверенные домены, только по делу |



---

## Используемые API

> Чтение чеков - https://proverkacheka.com


---



## 🛠️ Установка и запуск (локально)

### 📦 Зависимости

- [.NET Core SDK 3.1](https://dotnet.microsoft.com/download/dotnet/3.1)
- SQL Server (PosgreSQL)


### 🚦 Шаги запуска

1. **Клонировать репозиторий**


> git clone https://github.com/MyFinProject/Backend.git
cd Backend

2. **Настроить строку подключения**

Откройте appsettings.Development.json и пропишите:
> "ConnectionStrings": {
"DefaultConnection": "Server=localhost;Database=MyFinDb;User Id=sa;Password=YourStrong@Passw0rd;"
}

3. **Применить миграции и инициализировать базу**
>dotnet ef database update

4. **Запуск приложения**
>dotnet run --project Api

---

## 📦 Структура проекта
```Backend/
├── Api/
│   ├── Controllers/           # Обработчики HTTP-запросов
│   ├── DTO/                   # Модели для связи с пользователем
│   ├── Models/                # DTO и сущности базы данных
│   ├── Services/              # Бизнес-логика и взаимодействие с данными
│   ├── Data/                  # Контекст базы данных
│   ├── Migrations/            # Миграция
│   ├── Mappers/               # Переход от моделей к DTO и обратно
│   ├── Program.cs             # Точка входа приложения
│   ├── image/                 # EDR DataBase
│   ├── Reposytore/            # Связь с базой данных
│   ├── Extensions/            # Позволяет получить имя пользователя из claim GivenName одним вызовом user.GetUsername().
├── Properties/
│   └── launchSettings.json      # Настройки запуска для различных сред
├── appsettings.json             # Основные настройки приложения
├── appsettings.Development.json # Настройки для среды разработки
├── Program.cs                   # Файл решения Visual Studio
├── .gitignore                   # Файлы и папки, игнорируемые Git
└── README.md                    # Документация проекта
```
