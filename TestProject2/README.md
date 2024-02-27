Тестовое задание 2:
Дано: Множество объектов JSON, содержащих одинаковую информацию о сущностях, но в разном формате.
Задача: Написать программу, реализующую конвертацию из различных JSON в указанный базовый класс. Конвертация должна быть настраиваемой под каждый конкретный случай, если данные в JSON совпадают по структуре с базовым классом – нет необходимости в настройке этих параметров маппинга.
Разрешается использовать любые вспомогательные библиотеки.
Объект 1:
```json
{
	"Insurer": {
		"FirstName": "Петрищенко",
		"LastName": "Федор"
	},
	"Vehicle": {
		"Mark": "Volvo",
		"Model": "XC90"
	},
	"DateBegin": "2016-06-06",
	"DateEnd": "2017-06-05"
}
```

Объект 2:
```json
{
	"InsurerFirstName": "Петрищенко",
	"InsurerLastName": "Федор"
	"Vehicle": {
		"Mark": "Volvo",
		"Model": "XC90"
	},
	"EffectiveDate": "2016-06-06",
	"ExpirationDate": "2017-06-05"
}
```

Объект 3:
```json
{
	"Insurer": {
		"Type": "Person",
		"Person": {
			"InsurerFirstName": "Петрищенко",
			"InsurerLastName": "Федор"
		}
	},
	"VehicleMark": "Volvo",
	"VehicleModel": "XC90",
	"DateBegin": "2016-06-06",
	"DateEnd": "2017-06-05"
}
```

Базовый класс:
```cs
// Базовый объект полиса
class BasePolicy
{
	public DateTime DocumentDate { get; set; }      // Дата создания документа
	public DateTime EffectiveDate {get; set;}       // Начало действия ДС
	public DateTime ExpirationDate { get; set; }    // Окончание действия ДС
	public DateTime AcceptationDate { get; set; }   // Дата акцептации ДС
	public Person Insurer { get; set; }             // Страхователь
	public Vehicle Vehicle { get; set; }            // Данные Автомобиля
}

// Класс субъекта Физ. лица
class Person
{
    public string Name { get; set; }                // Наименование субъекта (ФИО - если ФЛ, Название организации - если ЮЛ)
}
// Класс автомобиля
class Vehicle
{
    public string MarkName { get; set; }            // Наименование марки
    public string ModelName { get; set; }           // Наименование модели
}
```