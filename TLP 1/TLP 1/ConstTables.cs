using System;
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
            {"/", "S7"},
            {"space", "S8"},
            {"/0", "S9"},
            {"[", "S10"},
            {"]", "S11"}
        };
    }
}
