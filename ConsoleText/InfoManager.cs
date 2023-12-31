using System;
using System.IO;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace InfoManager
{
    class InfoManagerPlayer
    {
        public int DungeonClear = 0;
        public int maxHp = 100;
        public int currentHp = 100;
        public int level = 1;
        public int currentExp = 0;
        public int maxExp = 100;
        public string className = "모험가";
        public float atk = 10;
        public int def = 5;
        public int gold = 10000;
        public string[] equipment = { "", "", "" };    //차례 대로 무기, 방어구, 장신구
        public int maxInventory = 10;
        public string[] isbuy = { "600G", "1500G", "3000G", "1000G", "2000G", "3500G", "3000G", "1500G" };
        public int appendAtk = 0;
        public int appendDef = 0;
        public List<Item> list = new List<Item>();

        public void AddItem(Item ItemName)
        {
            if (list.Count <= maxInventory)
            {
                list.Add(ItemName);
            }
            else
            {
                Console.WriteLine("더이상 구매할 수 없습니다.");
            }
        }

        public void GetItemName()
        {
            if (list.Count == 0)
            {
                Console.WriteLine("보유중인 아이템이 없습니다.");
            }
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine((i + 1) + "." + list.ElementAt(i).name);
                }
            }
        }

        public int SetMaxHp(int add) { maxHp += add; return maxHp; }
        public int GetMaxHp() { return maxHp; }
        public int SetHp(int add) { currentHp += add; return currentHp; }
        public int GetHp() { return currentHp; }
        public float SetAtk(float add) { atk += add; return atk; }
        public float GetAtk() { return atk; }
        public int SetDef(int add) { def += add; return def; }
        public int GetDef() { return def; }
        public string SetClassName(string jobname) { className = jobname; return className; }
        public string GetClassName() { return className; }
        public int SetLevel() { return level++; }
        public int GetLevel() { return level; }
        public int GetGold() { return gold; }
        public int SetGold(int addGold) { gold += addGold; return gold; }
    }
}

class Item
{
    public string type;
    public string name;
    public int power;
    public int price;
    public string info;
    public int number;
    public bool isEquip = false;
}