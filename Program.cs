using System;
using System.Text.RegularExpressions;
class Lab_4
{
  // Лаб4-1 Написать программу, которая считывает текст из файла и выводит на экран сначала предложения, начинающиеся c однобуквенных слов, а затем все остальные.
  public void task_1()
  {
    string text = System.IO.File.ReadAllText(@"text.txt");
    string formatted = "";
    foreach (string sentance in text.Split('.'))
    {// получаем масиив отдельных приложений
      if (sentance.Length == 0) continue;
      if (sentance[1] == ' ') // если второй символ в передложении пробел.
      {
        formatted = sentance + "." + formatted; //добавляем в начало коллекции
        continue;
      }
      // иначе в конец
      formatted += sentance + ".";
    }

    Console.WriteLine(formatted);
  }

  //Лаб4-2. В заданном текстовом файленайти указанные строчки и выдать позиции необходимых подстрок
  //Найдите строчки, в которых есть «слова», написанные капсом (то есть строго заглавными), возможно внутри настоящих слов (аааБББввв);
  public void task_2()
  {
    string[] lines = System.IO.File.ReadAllLines(@"lab42.txt");

    Regex myReg = new Regex(@"/^\P{Ll}*$/");

    Console.WriteLine("------------ Found content ------------");
    foreach (string line in lines)
    {
      MatchCollection matches = myReg.Matches(line);
      if (matches.Count > 0)
      {
        Console.WriteLine(line);
      }

    }

  }
}


class MainClass
{
  public static void Main(string[] args)
  {
    var lab_4 = new Lab_4();
    lab_4.task_2();
  }
}