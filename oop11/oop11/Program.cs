using System;
using System.Collections.Generic;

// Абстрактний клас Record
abstract class Record
{
    public string Title { get; set; }
    public DateTime CreatedAt { get; }
    public DateTime LastModified { get; set; }

    public Record(string title)
    {
        Title = title;
        CreatedAt = DateTime.Now;
        LastModified = DateTime.Now;
    }

    public abstract void DisplayInfo();
}

// Клас-спадкоємець TextRecord
class TextRecord : Record
{
    public string Text { get; set; }

    public TextRecord(string title, string text) : base(title)
    {
        Text = text;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Text Record: {Title} - Created: {CreatedAt} - Last Modified: {LastModified}");
    }
}

// Клас-спадкоємець TaskList
class TaskList : Record
{
    public List<string> Tasks { get; set; }

    public TaskList(string title, List<string> tasks) : base(title)
    {
        Tasks = tasks;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Task List: {Title} - Created: {CreatedAt} - Last Modified: {LastModified}");
    }
}

// Клас-спадкоємець Reminder
class Reminder : Record
{
    public DateTime ReminderDate { get; set; }

    public Reminder(string title, DateTime reminderDate) : base(title)
    {
        ReminderDate = reminderDate;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Reminder: {Title} - Reminder Date: {ReminderDate} - Created: {CreatedAt} - Last Modified: {LastModified}");
    }
}

// Клас для керування записами
class RecordManager
{
    public event EventHandler<string> RecordAdded;
    public event EventHandler<string> RecordDeleted;
    public event EventHandler<string> RecordEdited;

    private List<Record> records = new List<Record>();

    // Додавання нового запису
    public void AddRecord(Record record)
    {
        records.Add(record);
        RecordAdded?.Invoke(this, $"Додано запис: {record.Title}");
    }

    // Редагування запису
    public void EditRecord(int index, Record updatedRecord)
    {
        if (index >= 0 && index < records.Count)
        {
            records[index] = updatedRecord;
            updatedRecord.LastModified = DateTime.Now;
            RecordEdited?.Invoke(this, $"Змінено запис: {updatedRecord.Title}");
        }
        else
        {
            Console.WriteLine("Неправильний індекс запису.");
        }
    }

    // Видалення запису
    public void DeleteRecord(int index)
    {
        if (index >= 0 && index < records.Count)
        {
            Record deletedRecord = records[index];
            records.RemoveAt(index);
            RecordDeleted?.Invoke(this, $"Видалено запис: {deletedRecord.Title}");
        }
        else
        {
            Console.WriteLine("Неправильний індекс запису.");
        }
    }

    // Відображення списку записів
    public void DisplayRecords()
    {
        foreach (var record in records)
        {
            record.DisplayInfo();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        RecordManager recordManager = new RecordManager();

        // Приклад додавання різних типів записів
        TextRecord textRecord = new TextRecord("Замітка 1", "Це текстовий запис.");
        TaskList taskList = new TaskList("Список завдань", new List<string> { "Завдання 1", "Завдання 2" });
        Reminder reminder = new Reminder("Нагадування", new DateTime(2023, 12, 10));

        recordManager.AddRecord(textRecord);
        recordManager.AddRecord(taskList);
        recordManager.AddRecord(reminder);

        // Виведення всіх записів
        recordManager.DisplayRecords();

        // Приклад редагування запису
        reminder.ReminderDate = new DateTime(2023, 12, 15);
        recordManager.EditRecord(2, reminder);

        // Приклад видалення запису
        recordManager.DeleteRecord(1);

        // Оновлений список записів
        recordManager.DisplayRecords();
    }
}
