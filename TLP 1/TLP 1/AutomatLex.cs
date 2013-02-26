using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TLP_1
{    
    class AutomatLex
    {
        string _parsedString; // обрабатываемая строка

        int count_I = 0; // номер для создания кода для идентификаторов
        int count_C = 0; // номер для создание кода для чисел

        List <string> IDs_values = new List<string>(); // список кодов для идентификаторов
        List<string> Const_values = new List<string>(); // список кодов для чисел

        StreamWriter file = new StreamWriter(@"C:\book\test.txt"); // переменная для записи в файл
        
        // таблица для идентификаторов
        Dictionary<string, string> IDs = new Dictionary<string, string>();
        // таблица для чисел
        Dictionary<string, string> numbers = new Dictionary<string, string>();

        ConstTables variable = new ConstTables();

        public AutomatLex(string s)
        {
            _parsedString = s;
        }

        ~AutomatLex()
        {
            file.Close();
        }

        // проверка, является ли символ буквой
        public bool IsCharacter(char ch)
        {
            if (Convert.ToInt32(ch) >= Convert.ToInt32('a') && Convert.ToInt32(ch) <= Convert.ToInt32('z')
                    || Convert.ToInt32(ch) >= Convert.ToInt32('A') && Convert.ToInt32(ch) <= Convert.ToInt32('Z')
                    || ch == '_')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // проверка, является ли символ цифрой
        public bool IsDigit(char ch)
        {
            if (ch >= '0' && ch <= '9')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // проверка, является ли символ началом операции
        public bool IsOperation(char ch)
        {
            if (ch == '.' || ch == '-' || ch == '+' || ch == '~' || ch == '!' || ch == '&' || ch == '*'
                || ch == '/' || ch == '%' || ch == '<' || ch == '>' || ch == '=' || ch == '^' || ch == '|'
                || ch == '?' || ch == ',')
                return true;
            else
                return false;
        }

        public void StartAutomat()
        {
            int position = 0;

            if (IsCharacter(_parsedString[position]))
            {
                WordsFunc(ref position);
            }

            file.Close();
 
        }

        // обрабатывает ветку автомата, соотвествующую ситуации, когда первый символ - буква
        public void WordsFunc(ref int position)
        {
            int i = position;
            string temp_s;
            int pos = 0;

            while (true)
            {
                if (IsCharacter(_parsedString[i]) || IsDigit(_parsedString[i]))
                {
                    i++;
                    continue;
                }

                // встречаем начало индексации
                if (_parsedString[i] == '[')
                {
                    pos = i;
                    //выделяем идентификатор и если он соотвествует служебному слову, то переходим в состояние ошибки
                    temp_s = _parsedString.Substring(position, i - position);
                    if (variable._reservedWords.ContainsKey(temp_s))
                    {
                        //Переход в состояние ошибки
                    }

                    // если мы нашли это идентификтор в таблицы идентификаторов, то записываем соотвествующий код в файл
                    if (IDs.ContainsKey(temp_s))
                    {
                        file.Write(IDs[temp_s]);
                        file.Write(" ");
                    }
                    // иначе добавляем его в таблицу идентификаторов и потом записываем в файл
                    else
                    {
                        IDs_values.Add(("I" + Convert.ToString(count_I + 1)));
                        IDs.Add(temp_s, IDs_values[count_I]);
                        count_I++;
                        file.Write(IDs[temp_s]);
                        file.Write(" ");
                    }

                    // добавляем код разделителя в файл
                    file.Write(variable._separators["["]);
                    file.Write(" ");
                    ++i;
                    position = i;
                    continue;
                }

                // встречаем конец индексации
                if (_parsedString[i] == ']')
                {
                    temp_s = _parsedString.Substring(pos + 1, i - pos + 1);

                    // проверяем, является ли индекс массива числом
                    if (IsDigit(temp_s[0]))
                    {
                        // если число уже есть в таблице, то записываем его код в файл
                        if (numbers.ContainsKey(temp_s))
                        {
                            file.Write(numbers[temp_s]);
                            file.Write(" ");
                        }
                        // иначе добавляем его в таблицу и записываем
                        else
                        {
                            Const_values.Add(("C" + Convert.ToString(count_C + 1)));
                            numbers.Add(temp_s, Const_values[count_C]);
                            count_C++;
                            file.Write(numbers[temp_s]);
                            file.Write(" ");
                        }
                    }
                    // если это переменная, то записываем её код, иначе переходим в состояние ошибки
                    else if (IsCharacter(temp_s[0]))
                    {
                        if (IDs.ContainsKey(temp_s))
                        {
                            file.Write(IDs[temp_s]);
                            file.Write(" ");
                        }
                        else
                        {
                            // переходим в состояние ошибки
                        }
                    }
                    else
                    {
                        // переходим в состояние ошибки
                    }

                    file.Write(variable._separators["]"]);
                    file.Write(" ");
                    ++i;
                    position = i;
                    continue;
                }

                // если встречаем пробел или конец строки, то добавляем в файл код обработанного слова
                if (_parsedString[i] == ' ' || _parsedString[i] == '\0')
                {
                    temp_s = _parsedString.Substring(position, i - position + 1);

                    if (variable._reservedWords.ContainsKey(temp_s))
                    {
                        file.Write(variable._reservedWords[temp_s]);
                        file.Write(" ");
                    }
                    else if (IDs.ContainsKey(temp_s))
                    {
                        file.Write(IDs[temp_s]);
                        file.Write(" ");
                    }
                    else
                    {
                        IDs_values.Add(( "I" + Convert.ToString(count_I + 1)));
                        IDs.Add(temp_s, IDs_values[count_I]);
                        count_I++;
                        file.Write(IDs[temp_s]);
                        file.Write(" ");
                    }

                    if (_parsedString[i] == ' ')
                    {
                        ++i;
                        position = i;
                    }
                    break;
                }

                // если встречаем символ операции, то вызываем функцию для обработки операций
                if (IsOperation(_parsedString[i]))
                {
                    OperFunc(ref position);
                }
            }

        }

        public void OperFunc (ref int position)
        {
        }
    }
}
