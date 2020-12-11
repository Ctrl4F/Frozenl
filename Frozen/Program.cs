using System;
using System.Collections.Generic;
using System.IO;

namespace Frozen
{
    class Program
    {
        class Frozen
        {
            string name;
            string item;
            public Frozen(string _name, string _item)
            {
                name = _name;
                item = _item;
            }
            public string Name { get { return name; } }
            public string Item { get { return item; } }
        }
        class FrozenList
        {
            List<Frozen> characters;
            public FrozenList()
            {
                characters = new List<Frozen>();
            }
            public void AddCharactersToList(string name, string item)
            {
                Frozen newfrozen = new Frozen(name, item);
                characters.Add(newfrozen);
            }
            public void PrintAllFrozens()
            {
                foreach(Frozen character in characters)
                {
                    Console.WriteLine($"{character.Name}. {character.Item} want something");
                }
            }
        }
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\opilane\samples";
            string fileName = @"frozenl.txt";
            string fullFilePath = Path.Combine(filePath, fileName);
            string[] linesFromFile = File.ReadAllLines(fullFilePath);
            FrozenList characters = new FrozenList();
            foreach(string line in linesFromFile)
            {
                string[] tempArray = line.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                string characterName = tempArray[0];
                string characterItem = tempArray[1];
                characters.AddCharactersToList(characterName, characterItem);
            }
            characters.PrintAllFrozens();
        }
    }
}
