﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TLP_1
{
    class ConstTables
    {
        public Dictionary<string, string> _reservedWords = new Dictionary<string, string>()
        {
                {"auto", "W1"},
                {"break", "W2"},
                {"case","W3"},
                {"char","W4"},
                {"const","W5"},
                {"continue", "W6"},
                {"default","W7"},
                {"do","W8"},
                {"double","W9"},
                {"else","W10"},
                {"enum", "W11"},
                {"extern", "W12"},
                {"float", "W13"},
                {"for", "W14"},
                {"goto", "W15"},
                {"if", "W16"},
                {"int", "W17"},
                {"long", "W18"},
                {"register", "W19"},
                {"return", "W20"},
                {"short", "W21"},
                {"signed", "W22"},
                {"sizeof", "W23"},
                {"static", "W24"},
                {"struct", "W25"},
                {"switch", "W26"},
                {"typedef", "W27"},
                {"union", "W28"},
                {"unsigned", "W29"},
                {"void", "W30"},
                {"volatile", "W31"},
                {"while", "W32"}
        };

        public Dictionary<string, string> _operations = new Dictionary<string, string>()
        {
                {".", "O1"},
                {"->", "O2"},
                {"++","O3"},
                {"--","O4"},
                {"~","O5"},
                {"!", "O6"},
                {"-","O7"},
                {"+","O8"},
                {"&","O9"},
                {"*","O10"},
                {"/", "O11"},
                {"%", "O12"},
                {"<<", "O13"},
                {">>", "O14"},
                {"<", "O15"},
                {">", "O16"},
                {"<=", "O17"},
                {">=", "O18"},
                {"==", "O19"},
                {"!=", "O20"},
                {"^", "O21"},
                {"|", "O22"},
                {"&&", "O23"},
                {"||", "O24"},
                {"? :", "O25"},
                {"=", "O26"},
                {"+=", "O27"},
                {"-=", "O28"},
                {"*=", "O29"},
                {"/=", "O30"},
                {"%=", "O31"},
                {"<<=", "O32"},
                {">>=", "O33"},
                {"&=", "O34"},
                {"^=", "O35"},
                {"|=", "O36"},
                {",", "O37"}
        };

        public Dictionary<string, string> _separators = new Dictionary<string, string>()
        {
            {":","S1"},
            {";","S2"},
            {"(","S3"},
            {")", "S4"},
            {"{", "S5"},
            {"}", "S6"},
            {"\\", "S7"},
            {"#", "S8"},
            {"\0", "S9"},
            {"[", "S10"},
            {"]", "S11"}
        };

        // некоторые значение могут измениться, а некоторые и надо изменить. Плюс надо будет
        // добавить различие в приоритетах между постфиксной и инфиксной формой ++ и --
        public Dictionary<string, int> _tableOfPriorities = new Dictionary<string, int>()
        {
            {"S1", 1},
            {"PROC", 1},
            {"END", 1},
            {"DCL", 1},
            {"O1", 2},
            {"O2", 3},
            //{"++", 4},
            //{"--", 4},
            //{"~", 5},
            //{"!", 6},
            //{"+", 7}, // унарный
            //{"-", 7}, // унарный
            //{"&", 8}, // адрес
            //{"*", 9}, // ссылка
            {"O10", 10}, // умножение
            {"O11", 10},
            {"O12", 10},
            {"O8", 11}, // сумма
            {"O7", 11}, // разность
            {"O13", 12},
            {"O14", 12},
            {"O15", 13},
            {"O16", 13},
            {"O17", 13},
            {"O18", 13},
            {"O19", 14},
            {"O20", 14},
            {"O9", 15},
            {"O21", 16},
            {"O22", 17},
            {"O23", 18},
            {"O24", 19},
            {"O26", 20},
            {"W15", 20},
            {"O27", 20},
            {"O28", 20},
            {"O29", 20},
            {"O30", 20},
            {"O31", 20},
            {"O32", 20},
            {"O33", 20},
            {"O34", 20},
            {"O35", 20},
            {"O36", 20},
            {"O37", 21},
            {"S2", 21},
            {"S4", 21},
            {"S11", 21},
            {"THEN", 21},
            {"W10", 21},
            {"W16", 22},
            {"S3", 22},
            {"S10", 22},
            {"AEM", 22},
            {"F", 22}
        };
    }
}
