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

    Regex myReg = new Regex(@"([A-Z])([a-z]+)?");

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

  //Лаб4-2. Фильтрация строк в файлеЗадан текстовый файл, содержащий некоторое множество строк. Требуется вывести те из строк, которые удовлетворяют  заданному  критерию. В  приведенных  ниже  задачах  вам  нужно  написать  регулярное выражение  для  описанного  критерия.Должны  быть  выведены  в  точности  строки,  удовлетворяющие заданному критерию. Далее словом называется непустая последовательность символов, подходящих под шаблон «\w», ограниченная с двух сторон началом/концом строки или остальными символами («\W»). Подсказка:  для  работы  со  словами  удобны  также  шаблоны  «\b»  и  «\B».  Под  термином  буква подразумевается символ, подходящий под шаблон «\w». 
  // Строки, содержащие «cat» в качестве слова. Пример строк, которые подходят: «cat», «catapult and cat», «catapult and cat and concatenate». Пример строк, которые не подходят: «catcat», «concat», «Cat».

  public void task_3()
  {
    string[] lines = System.IO.File.ReadAllLines(@"lab42.txt");

    Regex myReg = new Regex(@"\b(cat)\b");

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


  // Лаб4-2. Преобразованиестрок в файле Задан текстовый файл, содержащий некоторое множество строк. Требуется преобразовать каждую из этих строк в соответствии с заданным правилом (нужно написать регулярное выражение для описанного преобразования) и вывести результат.Также вывести количество успешных замен.
  // Поменять местами две первых буквы в каждом слове. Примеры замен: «this is a text» → «htis si a etxt».
  public void task_4()
  {
    string[] lines = System.IO.File.ReadAllLines(@"lab42.txt");

    foreach (string line in lines)
    {
      string newline = Regex.Replace(line, @"\b(\w)(\w)\w*\b", "$2$1$'");
      Console.WriteLine(newline);
    }

  }
}


class MainClass
{
  public static void Main(string[] args)
  {
    var lab_4 = new Lab_4();
    lab_4.task_4();
  }
}