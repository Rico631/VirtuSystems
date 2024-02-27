﻿namespace TestProject2.App;
// Базовый объект полиса
public class BasePolicy
{
    public DateTime DocumentDate { get; set; }      // Дата создания документа
    public DateTime EffectiveDate { get; set; }       // Начало действия ДС
    public DateTime ExpirationDate { get; set; }    // Окончание действия ДС
    public DateTime AcceptationDate { get; set; }   // Дата акцептации ДС
    public Person Insurer { get; set; }             // Страхователь
    public Vehicle Vehicle { get; set; }            // Данные Автомобиля
}

// Класс субъекта Физ. лица
public class Person
{
    public string Name { get; set; }                // Наименование субъекта (ФИО - если ФЛ, Название организации - если ЮЛ)
}

// Класс автомобиля
public class Vehicle
{
    public string MarkName { get; set; }            // Наименование марки
    public string ModelName { get; set; }           // Наименование модели
}
