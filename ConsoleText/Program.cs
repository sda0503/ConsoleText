﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using InfoManager;
using System.Linq;


void Title()
{
    Console.Clear();
    Console.WriteLine("스파르타 던전마을");
    Console.WriteLine("");
    Console.WriteLine("1.게임 스타트 - 스토리 보기");
    Console.WriteLine("2.게임 스타트 - 스토리 스킵");
    Console.WriteLine("3.나가기");
    Console.WriteLine("");
    Console.WriteLine("원하시는 행동을 입력 해주세요.");
    int choice = int.Parse(Console.ReadLine());
    if (choice == 1) story();
    else if (choice == 2) init();
    else if (choice == 3) Console.WriteLine("게임을 종료합니다.");
    else
    {
        Console.WriteLine("잘못된 입력입니다.");
        Thread.Sleep(1000);
        Title();
    }
}

void story()
{
    Console.Clear();
    Console.WriteLine("어느날 스파르타에 있는 어느 작은 한 마을에 던전이 나타났습니다.");
    Thread.Sleep(2000);
    Console.WriteLine("던전에서는 몬스터 들이 튀어나와 스파르타를 혼란에 빠뜨렸습니다.");
    Thread.Sleep(2000);
    Console.WriteLine("스파르타에서는 몬스터들을 막기 위한 정예 84인을 뽑았습니다.");
    Thread.Sleep(2000);
    Console.WriteLine("");
    Console.WriteLine("");
    Console.WriteLine("스파르타에서 선출된 84명의 용사는 몬스터들을 상대로 열심히 싸움을 시작하였고");
    Thread.Sleep(2000);
    Console.WriteLine("스파르타에 출현한 몬스터들을 다시 던전으로 돌아가게 하였습니다.");
    Thread.Sleep(2000);
    Console.WriteLine("하지만 아직 던전은 건재 하였고 스파르타의 84명의 용사들은");
    Thread.Sleep(2000);
    Console.WriteLine("남아 있는 몬스터들을 소탕하기 위해 던전으로 들어가기 시작하였습니다.");
    Thread.Sleep(2000);
    Console.WriteLine("던전에 남아 있는 몬스터들을 소탕하고 던전을 봉인하여");
    Thread.Sleep(2000);
    Console.WriteLine("스파르타의 평안을 위해 던전에 들어가야 하는 상황입니다.");
    Thread.Sleep(2000);
    Console.WriteLine("");
    Console.WriteLine("");
    Console.WriteLine("스파르타의 84인의 용사 중 한분인 당신에게");
    Thread.Sleep(2000);
    Console.WriteLine("던전의 봉인을 부탁드리겠습니다.");
    Thread.Sleep(2000);
    Console.Write("스파르타의 축복이 당신과 함께 함께 하기를.");
    Thread.Sleep(500);
    Console.Write(".");
    Thread.Sleep(500);
    Console.Write(".");
    Console.Clear();
    Console.Beep();
    Thread.Sleep(1000);
    init();
}

void init()
{
    string path = Directory.GetCurrentDirectory();
    path += "\\saveData.txt";
    
    string[] textValue = System.IO.File.ReadAllLines(path);

    //플레이어 초기화
    InfoManager.InfoManagerPlayer player = new InfoManager.InfoManagerPlayer();
    //메모장 로드
    player.DungeonClear = Convert.ToInt32(textValue[0]);
    player.maxHp = Convert.ToInt32(textValue[1]);
    player.currentHp = Convert.ToInt32(textValue[2]);
    player.level = Convert.ToInt32(textValue[3]);
    player.currentExp = Convert.ToInt32(textValue[4]);
    player.maxExp = Convert.ToInt32(textValue[5]);
    player.className = textValue[6];
    player.atk = (float)Convert.ToDouble(textValue[7]);
    player.def = Convert.ToInt32(textValue[8]);
    player.gold = Convert.ToInt32(textValue[9]);
    player.equipment[0] = textValue[10];
    player.equipment[1] = textValue[11];
    player.equipment[2] = textValue[12];
    player.maxInventory = Convert.ToInt32(textValue[13]);
    player.isbuy[0] = textValue[14];
    player.isbuy[1] = textValue[15];
    player.isbuy[2] = textValue[16];
    player.isbuy[3] = textValue[17];
    player.isbuy[4] = textValue[18];
    player.isbuy[5] = textValue[19];
    player.isbuy[6] = textValue[20];
    player.isbuy[7] = textValue[21];
    player.appendAtk = Convert.ToInt32(textValue[22]);
    player.appendDef = Convert.ToInt32(textValue[23]);
    int list_count = Convert.ToInt32(textValue[24]);

    for (int i = 0; i < list_count; i++)
    {
        player.list.Add(new Item());
        player.list[i].type = textValue[25 + (i * 7)];
        player.list[i].name = textValue[25 + (i * 7) + 1];
        player.list[i].power = Convert.ToInt32(textValue[25 + (i * 7) + 2]);
        player.list[i].price = Convert.ToInt32(textValue[25 + (i * 7) + 3]);
        player.list[i].info = textValue[25 + (i * 7) + 4];
        player.list[i].number = Convert.ToInt32(textValue[25 + (i * 7) + 5]);
        player.list[i].isEquip = Convert.ToBoolean(textValue[25 + (i * 7) + 6]);
    }


    //게임 시작
    Town(player);
}
//마을
void Town(InfoManager.InfoManagerPlayer player)
{
    Console.Clear();
    Console.WriteLine("[마을 안내도]");
    Console.WriteLine("");
    Console.WriteLine("1.상태보기");
    Console.WriteLine("2.인벤토리");
    Console.WriteLine("3.상점");
    Console.WriteLine("4.여관");
    Console.WriteLine("5.던전");
    Console.WriteLine("6.저장");
    Console.WriteLine("7.초기화");
    Console.WriteLine("");
    Console.WriteLine("원하시는 행동을 입력 해주세요.");
    int choice = int.Parse(Console.ReadLine());

    if(choice == 1)       State(player);
    else if (choice == 2) Inventory(player);
    else if (choice == 3) Shop(player);
    else if (choice == 4) Inn(player);
    else if (choice == 5) Dungeon(player);
    else if (choice == 6) Save(player);
    else if (choice == 7) Reset(player);
    else
    {
        Console.WriteLine("잘못된 입력입니다.");
        Thread.Sleep(1000);
        Town(player);
    }
}

//상태보기
void State(InfoManager.InfoManagerPlayer player)
{

    Console.Clear();
    Console.WriteLine("Lv." + player.GetLevel());
    Console.WriteLine("직업 :" + player.GetClassName());
    Console.WriteLine("공격력 :" +(player.GetAtk() + player.appendAtk) + " [기본 공격력 : "+ player.GetAtk() + " (+" + player.appendAtk +")]");
    Console.WriteLine("방어력 :" + (player.GetDef() + player.appendDef)+ " [기본 방어력 : " + player.GetDef() + " (+" + player.appendDef + ")]");
    Console.WriteLine("체력 :" + player.GetHp() + "/" + player.GetMaxHp());
    Console.WriteLine("Gold : " + player.GetGold() + " G");
    Console.WriteLine("");
    Console.WriteLine("0. 나가기");
    Console.WriteLine("");
    Console.WriteLine("원하시는 행동을 입력 해주세요.");
    int choice = int.Parse(Console.ReadLine());

    if(choice == 0)Town(player);
    else
    {
        Console.WriteLine("잘못된 입력입니다.");
        Thread.Sleep(1000);
        State(player);
    }
}

//인벤토리
void Inventory(InfoManager.InfoManagerPlayer player)
{
    Console.Clear();
    Console.WriteLine("[보유 골드]");
    Console.WriteLine(player.GetGold() + "G");
    Console.WriteLine("");
    Console.WriteLine("[아이템 목록]");
    Console.WriteLine(player.list.Count+"/"+ player.maxInventory);
    player.GetItemName();
    Console.WriteLine("");
    Console.WriteLine("1.장착 관리");
    Console.WriteLine("0.나가기");
    Console.WriteLine("");
    Console.WriteLine("원하시는 행동을 입력 해주세요.");
    int choice = int.Parse(Console.ReadLine());
    if (choice == 0) Town(player);
    else if (choice == 1) Equipment(player);
    else
    {
        Console.WriteLine("잘못된 입력입니다.");
        Thread.Sleep(1000);
        Inventory(player);
    }
}

void Equipment(InfoManager.InfoManagerPlayer player)
{
    Console.Clear();
    Console.WriteLine("[장착 관리]");
    Console.WriteLine("1.무기 -" + player.equipment[0]);
    Console.WriteLine("2.방어구 -" + player.equipment[1]);
    Console.WriteLine("3.장신구 -" + player.equipment[2]);
    Console.WriteLine("0.나가기");
    Console.WriteLine("");
    Console.WriteLine("원하시는 행동을 입력 해주세요.");
    int choice = int.Parse(Console.ReadLine());
    if (choice == 0) Inventory(player);
    else if (choice == 1) EquipmentItem(player,1);
    else if (choice == 2) EquipmentItem(player,2);
    else if (choice == 3) EquipmentItem(player,3);
    else
    {
        Console.WriteLine("잘못된 입력입니다.");
        Thread.Sleep(1000);
        Equipment(player);
    }
}

//장비 장착
void EquipmentItem(InfoManager.InfoManagerPlayer player, int type) 
{
    //장비 분류
    List<Item> weaponItem = new List<Item>(); //무기 리스트
    List<Item> armorItem = new List<Item>();  //방어구 리스트
    List<Item> accItem = new List<Item>();    //장신구 리스트

    for (int i = 0; i < player.list.Count; i++)
    {
        if (player.list[i].type == "[무기]") weaponItem.Add(player.list[i]);
        if (player.list[i].type == "[방어구]") armorItem.Add(player.list[i]);
        if (player.list[i].type == "[장신구]") accItem.Add(player.list[i]);
    }

    if (type == 1)
    {
        Console.Clear();
        Console.WriteLine("[무기 장착]");
        Console.WriteLine("");
        Console.WriteLine("장착 가능 무기");
        for (int i = 0; i < weaponItem.Count; i++)
        {
            Console.WriteLine((i + 1) + "."+ weaponItem[i].name);
        }
        Console.WriteLine("0.나가기");
        Console.WriteLine("");
        Console.WriteLine("장착을 원하는 무기의 번호를 고르세요");
        Console.WriteLine("");
        Console.WriteLine("원하시는 행동을 입력 해주세요.");
        Console.WriteLine("0 ~ "+ weaponItem.Count);
        int choice = int.Parse(Console.ReadLine());
        if (choice == 0) Equipment(player);
        else if(choice == 1) selectItem(player, 0, weaponItem, 0);
        else if (choice == 2) selectItem(player, 1, weaponItem, 0);
        else if (choice == 3) selectItem(player, 2, weaponItem, 0);
        else if (choice == 4) selectItem(player, 3, weaponItem, 0);
        else if (choice == 5) selectItem(player, 4, weaponItem, 0);
        else
        {
            Console.WriteLine("잘못된 입력입니다.");
            Thread.Sleep(1000);
            Equipment(player);
        }
    }
    else if(type == 2)
    {
        Console.Clear();
        Console.WriteLine("[방어구 장착]");
        Console.WriteLine("");
        Console.WriteLine("장착 가능 방어구");
        for (int i = 0; i < armorItem.Count; i++)
        {
            Console.WriteLine((i + 1) + "." + armorItem[i].name);
        }
        Console.WriteLine("0.나가기");
        Console.WriteLine("");
        Console.WriteLine("장착을 원하는 방어구의 번호를 고르세요");
        Console.WriteLine("");
        Console.WriteLine("원하시는 행동을 입력 해주세요.");
        Console.WriteLine("0 ~ " + armorItem.Count);
        int choice = int.Parse(Console.ReadLine());
        if (choice == 0) Inventory(player);
        else if (choice == 1) selectItem(player, 0, armorItem, 1);
        else if (choice == 2) selectItem(player, 1, armorItem, 1);
        else if (choice == 3) selectItem(player, 2, armorItem, 1);
        else if (choice == 4) selectItem(player, 3, armorItem, 1);
        else if (choice == 5) selectItem(player, 4, armorItem, 1);
        else
        {
            Console.WriteLine("잘못된 입력입니다.");
            Thread.Sleep(1000);
            Equipment(player);
        }
    }
    else
    {
        Console.Clear();
        Console.WriteLine("[장신구 장착]");
        Console.WriteLine("");
        Console.WriteLine("장착 가능 장신구");
        for (int i = 0; i < accItem.Count; i++)
        {
            Console.WriteLine((i + 1) + "." + accItem[i].name);
        }
        Console.WriteLine("0.나가기");
        Console.WriteLine("");
        Console.WriteLine("장착을 원하는 장신구의 번호를 고르세요");
        Console.WriteLine("");
        Console.WriteLine("원하시는 행동을 입력 해주세요.");
        Console.WriteLine("0 ~ " + accItem.Count);
        int choice = int.Parse(Console.ReadLine());
        if (choice == 0) Inventory(player);
        else if (choice == 1) selectItem(player, 0, accItem, 2);
        else if (choice == 2) selectItem(player, 1, accItem, 2);
        else if (choice == 3) selectItem(player, 2, accItem, 2);
        else if (choice == 4) selectItem(player, 3, accItem, 2);
        else if (choice == 5) selectItem(player, 4, accItem, 2);
        else
        {
            Console.WriteLine("잘못된 입력입니다.");
            Thread.Sleep(1000);
            Equipment(player);
        }
    }
}

//아이템 선택
void selectItem(InfoManager.InfoManagerPlayer player, int number, List<Item> list, int count)
{
    player.equipment[count] = list[number].name;
    for (int i = 0; i < player.list.Count; i++)
    {
        if(count == 0)
        {
            if (player.equipment[count] == player.list[i].name)
            {
                player.list[i].isEquip = true;
                player.list[i].name = "[E]" + player.list[i].name;
                player.appendAtk = player.appendAtk + player.list[i].power;
            }
            else if (player.list[i].isEquip == true && player.list[i].type == "[무기]")
            {
                player.appendAtk = player.appendAtk - player.list[i].power;
                string tmp = player.list[i].name;
                string tmp1 = tmp.Substring(3);
                player.list[i].name = tmp1;
            }
            
        }
        else if(count == 1)
        {
            if (player.equipment[count] == player.list[i].name)
            {
                player.list[i].isEquip = true;
                player.list[i].name = "[E]" + player.list[i].name;
                player.appendDef = player.appendDef + player.list[i].power;

            }
            else if (player.list[i].isEquip == true && player.list[i].type == "[방어구]")
            {
                player.appendDef = player.appendDef - player.list[i].power;
                string tmp = player.list[i].name;
                string tmp1 = tmp.Substring(3);
                player.list[i].name = tmp1;
            }
        }
        else if (count == 2)
        {
            if (player.equipment[count] == player.list[i].name)
            {
                player.list[i].isEquip = true;
                player.list[i].name = "[E]" + player.list[i].name;
                player.appendDef = player.appendDef + player.list[i].power;
            }
            else if (player.list[i].isEquip == true && player.list[i].type == "[장신구]")
            {
                player.appendDef = player.appendDef - player.list[i].power;
                string tmp = player.list[i].name;
                string tmp1 = tmp.Substring(3);
                player.list[i].name = tmp1;
            }
        }

    }
    Console.WriteLine(player.equipment[count] + "을 장착하였습니다.");
    Thread.Sleep(1000);
    Equipment(player);
}

void Shop(InfoManager.InfoManagerPlayer player)
{
    string[] itemsList = {
    "1.[무기] 낡은 검 | 공격력 +2 | 쉽게 볼 수 있는 낡은 검 입니다. | ",
    "2.[무기] 청동 도끼 | 공격력 +5 | 무쇠로 만들어져 튼튼한 갑옷입니다. | ",
    "3.[무기] 스파르타의 창 | 공격력 +9 | 스파르타의 전사들이 사용했다는 전설의 창입니다. | ",
    "4.[방어구] 수련자의 갑옷 | 방어력 + 5 | 수련에 도움을 주는 갑옵 입니다. | ",
    "5.[방어구] 무쇠갑옷 | 방어력 +9 | 무쇠로 만들어져 튼튼한 갑옷입니다. | ",
    "6.[방어구] 스파르타의 갑옷 | 방어력 +15 | 스파르타의 전사들이 사용했다는 전설의 갑옷입니다. | ",
    "7.[장신구] 스파르타의 방패 | 방어력 +10| 스파르타의 전사들이 사용했다는 전설의 방패입니다. | ",
    "8.[장신구] 팔목보호대 | 방어력 +3 | 착용자의 팔목을 보호해주는 보호대 | ",
};

    Console.Clear();
    Console.WriteLine("[보유 골드]");
    Console.WriteLine(player.GetGold()+"G");
    Console.WriteLine("");
    Console.WriteLine("[아이템 목록]");
    for(int i = 0; i< itemsList.Length; i++)
    {
        Console.WriteLine(itemsList[i] + player.isbuy[i]);
    }
    Console.WriteLine("");
    Console.WriteLine("");
    Console.WriteLine("1.구매");
    Console.WriteLine("2.판매");
    Console.WriteLine("0.나가기");
    Console.WriteLine("");
    Console.WriteLine("원하시는 행동을 입력 해주세요.");
    int choice = int.Parse(Console.ReadLine());
    if (choice == 0)Town(player);
    else if (choice == 1)Buy(player, player.isbuy);
    else if (choice == 2) Sell(player, player.isbuy);
    else
    {
        Console.WriteLine("잘못된 입력입니다.");
        Thread.Sleep(1000);
        Shop(player);
    }
}

//구매
void Buy(InfoManager.InfoManagerPlayer player, string[] isbuy)
{
    Console.WriteLine("");
    Console.WriteLine("구매하려는 아이탬의 번호를 입력 해주세요.");
    int choice = int.Parse(Console.ReadLine());
    if (choice == 0)Shop(player);
    else if (choice == 1)
    {
        if (isbuy[0] == "구매완료")
        {
            Console.WriteLine("이미 구매한 제품입니다.");
            Console.WriteLine("다른 제품을 골라주세요");
            Thread.Sleep(1000);
            Buy(player, isbuy);
        }
        else
        {
            if (player.GetGold() >= 600)
            {
                player.SetGold(-600);
                player.AddItem(new Item() { type = "[무기]", name = "낡은 검", power = 2, price = 600, info = "쉽게 볼 수 있는 낡은 검 입니다.", number = 1 });
                Console.WriteLine("구매를 완료했습니다.");
                isbuy[0] = "구매완료";
                Thread.Sleep(1000);
                Shop(player);
            }
            else
            {
                Console.WriteLine("Gold가 부족합니다.");
                Thread.Sleep(1000);
                Shop(player);
            }
        }
    }
    else if (choice == 2)
    {
        if (isbuy[1] == "구매완료")
        {
            Console.WriteLine("이미 구매한 제품입니다.");
            Console.WriteLine("다른 제품을 골라주세요");
            Thread.Sleep(1000);
            Buy(player, isbuy);
        }
        else
        {
            if (player.GetGold() >= 1500)
            {
                player.SetGold(-1500);
                player.AddItem(new Item() { type = "[무기]", name = "청동 도끼", power = 5, price = 1500, info = "무쇠로 만들어져 튼튼한 갑옷입니다.", number = 2 });
                Console.WriteLine("구매를 완료했습니다.");
                isbuy[1] = "구매완료";
                Thread.Sleep(1000);
                Shop(player);
            }
            else
            {
                Console.WriteLine("Gold가 부족합니다.");
                Thread.Sleep(1000);
                Shop(player);
            }
        }
    }
    else if (choice == 3)
    {
        if (isbuy[2] == "구매완료")
        {
            Console.WriteLine("이미 구매한 제품입니다.");
            Console.WriteLine("다른 제품을 골라주세요");
            Thread.Sleep(1000);
            Buy(player, isbuy);
        }
        else
        {
            if (player.GetGold() >= 3500)
            {
                player.SetGold(-3500);
                player.AddItem(new Item() { type = "[무기]", name = "스파르타의 창", power = 9, price = 3500, info = "스파르타의 전사들이 사용했다는 전설의 창입니다.", number = 3 });
                Console.WriteLine("구매를 완료했습니다.");
                isbuy[2] = "구매완료";
                Thread.Sleep(1000);
                Shop(player);
            }
            else
            {
                Console.WriteLine("Gold가 부족합니다.");
                Thread.Sleep(1000);
                Shop(player);
            }
        }
    }



    else if (choice == 4)
    {
        if (isbuy[3] == "구매완료")
        {
            Console.WriteLine("이미 구매한 제품입니다.");
            Console.WriteLine("다른 제품을 골라주세요");
            Thread.Sleep(1000);
            Buy(player, isbuy);
        }
        else
        {
            if (player.GetGold() >= 1000)
            {
                player.SetGold(-1000);
                player.AddItem(new Item() { type = "[방어구]", name = "수련자의 갑옷", power = 5, price = 1000, info = "수련에 도움을 주는 갑옵 입니다.", number = 4 });
                Console.WriteLine("구매를 완료했습니다.");
                isbuy[3] = "구매완료";
                Thread.Sleep(1000);
                Shop(player);
            }
            else
            {
                Console.WriteLine("Gold가 부족합니다.");
                Thread.Sleep(1000);
                Shop(player);
            }
        }
    }

    else if (choice == 5)
    {
        if (isbuy[4] == "구매완료")
        {
            Console.WriteLine("이미 구매한 제품입니다.");
            Console.WriteLine("다른 제품을 골라주세요");
            Thread.Sleep(1000);
            Buy(player, isbuy);
        }
        else
        {
            if (player.GetGold() >= 2000)
            {
                player.SetGold(-2000);
                player.AddItem(new Item() { type = "[방어구]", name = "무쇠갑옷 ", power = 9, price = 2000, info = "무쇠로 만들어져 튼튼한 갑옷입니다.", number = 5 });
                Console.WriteLine("구매를 완료했습니다.");
                isbuy[4] = "구매완료";
                Thread.Sleep(1000);
                Shop(player);
            }
            else
            {
                Console.WriteLine("Gold가 부족합니다.");
                Thread.Sleep(1000);
                Shop(player);
            }
        }
    }

    else if (choice == 6)
    {
        if (isbuy[5] == "구매완료")
        {
            Console.WriteLine("이미 구매한 제품입니다.");
            Console.WriteLine("다른 제품을 골라주세요");
            Thread.Sleep(1000);
            Buy(player, isbuy);
        }
        else
        {
            if (player.GetGold() >= 3500)
            {
                player.SetGold(-3500);
                player.AddItem(new Item() { type = "[방어구]", name = "스파르타의 갑옷", power = 15, price = 3500, info = "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", number = 6 });
                Console.WriteLine("구매를 완료했습니다.");
                isbuy[5] = "구매완료";
                Thread.Sleep(1000);
                Shop(player);
            }
            else
            {
                Console.WriteLine("Gold가 부족합니다.");
                Thread.Sleep(1000);
                Shop(player);
            }
        }
    }

    else if (choice == 7)
    {
        if (isbuy[6] == "구매완료")
        {
            Console.WriteLine("이미 구매한 제품입니다.");
            Console.WriteLine("다른 제품을 골라주세요");
            Thread.Sleep(1000);
            Buy(player, isbuy);
        }
        else
        {
            if (player.GetGold() >= 3000)
            {
                player.SetGold(-3000);
                player.AddItem(new Item() { type = "[장신구]", name = "스파르타의 방패", power = 10, price = 3000, info = "스파르타의 전사들이 사용했다는 전설의 방패입니다.", number = 7 });
                Console.WriteLine("구매를 완료했습니다.");
                isbuy[6] = "구매완료";
                Thread.Sleep(1000);
                Shop(player);
            }
            else
            {
                Console.WriteLine("Gold가 부족합니다.");
                Thread.Sleep(1000);
                Shop(player);
            }
        }
    }

    else if (choice == 8)
    {
        if (isbuy[7] == "구매완료")
        {
            Console.WriteLine("이미 구매한 제품입니다.");
            Console.WriteLine("다른 제품을 골라주세요");
            Thread.Sleep(1000);
            Buy(player, isbuy);
        }
        else
        {
            if (player.GetGold() >= 1500)
            {
                player.SetGold(-1500);
                player.AddItem(new Item() { type = "[장신구]", name = "팔목보호대", power = 3, price = 1000, info = "착용자의 팔목을 보호해주는 보호대입니다.", number = 8 });
                Console.WriteLine("구매를 완료했습니다.");
                isbuy[7] = "구매완료";
                Thread.Sleep(1000);
                Shop(player);
            }
            else
            {
                Console.WriteLine("Gold가 부족합니다.");
                Thread.Sleep(1000);
                Shop(player);
            }
        }
    }
    
    else
    {
        Console.WriteLine("잘못된 입력입니다.");
        Thread.Sleep(1000);
        Buy(player, isbuy);
    }
}

//판매
void Sell(InfoManager.InfoManagerPlayer player, string[] isbuy)
{
    Console.Clear();
    Console.WriteLine("");
    Console.WriteLine("[보유 골드]");
    Console.WriteLine(player.GetGold() + "G");
    Console.WriteLine("");
    Console.WriteLine("[아이탬 목록]");
    if(player.list.Count == 0)
    {
        Console.WriteLine("판매할 아이템이 없습니다.");
        Console.WriteLine("");
        Console.WriteLine("0.나가기");
        Console.WriteLine("원하시는 행동을 입력 해주세요.");
    }
    else
    {
        for (int i = 0; i < player.list.Count; i++)
        {
            Console.WriteLine((i + 1) + "." + player.list[i].name + " | " + player.list[i].info +" | " + player.list[i].price + "G");
        }
        Console.WriteLine("");
        Console.WriteLine("판매할 아이템 가능한 번호 1 ~ " + player.list.Count);
        Console.WriteLine("0.나가기");
        Console.WriteLine("원하시는 행동을 입력 해주세요.");
    }
    int choice = int.Parse(Console.ReadLine());
    if (choice == 0) Shop(player);
    else if (choice == 1 && player.list.Count > 0)sellItem(player, 0);
    else if (choice == 2 && player.list.Count > 1)sellItem(player, 1);
    else if (choice == 3 && player.list.Count > 2)sellItem(player, 2);
    else if (choice == 4 && player.list.Count > 3)sellItem(player, 3);
    else if (choice == 5 && player.list.Count > 4)sellItem(player, 4);
    else if (choice == 6 && player.list.Count > 5)sellItem(player, 5);
    else if (choice == 7 && player.list.Count > 6) sellItem(player, 6);
    else if (choice == 8 && player.list.Count > 7) sellItem(player, 7);
    else if (choice == 9 && player.list.Count > 8) sellItem(player, 8);
    else if (choice == 10 && player.list.Count > 9) sellItem(player, 9);
    else
    {
        Console.WriteLine("잘못된 입력입니다.");
        Thread.Sleep(1000);
        Sell(player, player.isbuy);
    }
}

void sellItem(InfoManager.InfoManagerPlayer player, int num)
{
    
    if (player.list[num].isEquip == true)
    {
        //장착시 판매 안됨
        /*
        Console.WriteLine("장착 아이템은 팔수 없습니다.");
        Sell(player);
        */
        //장착한 아이템 이름 제외
        if(player.list[num].type == "[무기]") player.equipment[0] = null;
        else if(player.list[num].type == "[방어구]") player.equipment[1] = null;
        else if (player.list[num].type == "[장신구]") player.equipment[2] = null;
        //장착한 아이템 값 비우기
        player.list[num].isEquip = false;
        player.isbuy[player.list[num].number - 1] = player.list[num].price.ToString() + "G";
        int sellGold = player.list[num].price / 100 * 85;
        player.SetGold(sellGold);
        Console.WriteLine("");
        Console.WriteLine(player.list[num].name + "을 판매하였습니다.");
        Console.WriteLine(sellGold + "G 를 획득하였습니다.");
        player.list.RemoveAt(num);
        Thread.Sleep(1000);
        Shop(player);
    }
    else
    {
        player.isbuy[num] = player.list[num].price.ToString() + "G";
        int sellGold = player.list[num].price / 100 * 85;
        player.SetGold(sellGold);
        Console.WriteLine("");
        Console.WriteLine(player.list[num].name + "을 판매하였습니다.");
        Console.WriteLine(sellGold + "G 를 획득하였습니다.");
        player.list.RemoveAt(num);
        Thread.Sleep(1000);
        Shop(player);
    }
}


void Dungeon(InfoManager.InfoManagerPlayer player)
{
    Console.Clear();
    Console.WriteLine("[주의]");
    Console.WriteLine("던전 내에서 발생하는 모든일에는 책임을 지지 않습니다.");
    Console.WriteLine("");
    Console.WriteLine("[플레이어 정보]");
    Console.WriteLine("플레이어 Lv : " + player.level );
    Console.WriteLine("플레이어 HP : "+ player.currentHp + "/" + player.maxHp);
    Console.WriteLine("플레이어 공격력 : " + (player.atk + player.appendAtk));
    Console.WriteLine("플레이어 방어력 : " + (player.def + player.appendDef));
    Console.WriteLine("");
    Console.WriteLine("1.이지 던전 | 방어력 5 이상 권장");
    Console.WriteLine("2.노말 던전 | 방어력 11 이상 권장");
    Console.WriteLine("3.하드 던전 | 방어력 17 이상 권장");
    Console.WriteLine("0.나가기");
    Console.WriteLine("");
    Console.WriteLine("원하시는 행동을 입력 해주세요.");
    int choice = int.Parse(Console.ReadLine());
    if (choice == 0) Town(player);
    else if (choice == 1) adventureDungeon(player,1,5);
    else if (choice == 2) adventureDungeon(player,2,11);
    else if (choice == 3) adventureDungeon(player,3,17);
    else
    {
        Console.WriteLine("잘못된 입력입니다.");
        Thread.Sleep(1000);
        Dungeon(player);
    }
}

void adventureDungeon(InfoManager.InfoManagerPlayer player, int type, int require)
{
    Random random = new Random();
    int percent = random.Next(0, 101);   // 0~100% 
    Console.Clear();

    int differencePoint = require - (player.def + player.appendDef);
    int damage = random.Next(20 + differencePoint, 35 + differencePoint);
    float playerAtk = player.atk + player.appendAtk;
    int GetGold = random.Next((int)playerAtk, (int)playerAtk *2);
    int gold = 0;

    Console.WriteLine("던전 탐사를 진행중.");
    Thread.Sleep(1000);
    Console.WriteLine("던전 탐사를 진행중..");
    Thread.Sleep(1000);
    Console.WriteLine("던전 탐사를 진행중...");
    Thread.Sleep(1000);
    //필요 방어도가 낮을 경우
    if (differencePoint > 0)
    {
        Console.WriteLine("필요 방어도가 부족합니다.");
        Thread.Sleep(1000);
        Console.WriteLine("던전 클리어율 계산중");
        Thread.Sleep(1000);
        Console.WriteLine("던전 클리어율 계산중.");
        Thread.Sleep(1000);
        Console.WriteLine("던전 클리어율 계산중..");
        Thread.Sleep(1000);
        if (percent < 40)
        {
            Console.Clear();
            Console.WriteLine("던전 탐사에 실패 했습니다.");
            Console.WriteLine("실패 패널티로 체력이 50% 감소합니다.");
            player.currentHp = player.currentHp / 2;
            Console.WriteLine("");
            Console.WriteLine("3초후 마을로 돌아갑니다.");
            Thread.Sleep(1000);
            Console.WriteLine("2초후 마을로 돌아갑니다.");
            Thread.Sleep(1000);
            Console.WriteLine("1초후 마을로 돌아갑니다.");
            Thread.Sleep(1000);
            Console.WriteLine("마을로 이동합니다.");
            Thread.Sleep(100);
            Town(player);
        }
        else
        {
            Console.Clear();
            Console.WriteLine("던전 탐사에 성공 했습니다.");
            Thread.Sleep(500);
            Console.WriteLine("");
            Console.WriteLine(damage+"의 피해를 받았습니다.");
            player.SetHp(-damage);
            Thread.Sleep(500);
            Console.WriteLine("보상을 획득합니다.");
            if (type == 1) gold = 1000;
            else if (type == 2) gold = 1700;
            else if (type == 3) gold = 2500;

            player.SetGold(gold + (gold * GetGold / 100));
            Console.WriteLine((gold + (gold * GetGold / 100)) +"G를 보상으로 획득합니다.");
            Console.WriteLine("");
            player.DungeonClear++;
            LevelUp(player);
            Console.WriteLine("");
            Console.WriteLine("3초후 마을로 돌아갑니다.");
            Thread.Sleep(1000);
            Console.WriteLine("2초후 마을로 돌아갑니다.");
            Thread.Sleep(1000);
            Console.WriteLine("1초후 마을로 돌아갑니다.");
            Thread.Sleep(1000);
            Console.WriteLine("마을로 이동합니다.");
            Thread.Sleep(100);
            Town(player);
        }
    }
    else
    {
        Console.Clear();
        Console.WriteLine("던전 탐사에 성공 했습니다.");
        Thread.Sleep(500);
        Console.WriteLine(damage + "의 피해를 받았습니다.");
        player.SetHp(-damage);
        Thread.Sleep(500);
        Console.WriteLine("보상을 획득합니다.");
        if (type == 1) gold = 1000;
        else if (type == 2) gold = 1700;
        else if (type == 3) gold = 2500;

        player.SetGold(gold + (gold * GetGold / 100));
        Console.WriteLine((gold + (gold * GetGold / 100)) + "G를 보상으로 획득합니다.");
        Console.WriteLine("");
        player.DungeonClear++;
        LevelUp(player);
        Console.WriteLine("");
        Console.WriteLine("3초후 마을로 돌아갑니다.");
        Thread.Sleep(1000);
        Console.WriteLine("2초후 마을로 돌아갑니다.");
        Thread.Sleep(1000);
        Console.WriteLine("1초후 마을로 돌아갑니다.");
        Thread.Sleep(1000);
        Console.WriteLine("마을로 이동합니다.");
        Thread.Sleep(100);
        Town(player);
    }
}

void LevelUp(InfoManager.InfoManagerPlayer player)
{
    if(player.DungeonClear % player.level == 0)
    {
        Console.WriteLine("Level이 올랐습니다.");
        player.DungeonClear = 0;
        player.SetLevel();
        player.atk = player.atk + (((float)player.level - 1) * 0.5f);
        player.def = player.def + (player.level - 1);
        Thread.Sleep(1000);
        Console.WriteLine("HP를 회복합니다.");
        player.currentHp = player.maxHp;
        Thread.Sleep(1000);
    }
}

//여관
void Inn(InfoManager.InfoManagerPlayer player)
{
    Console.Clear();
    Console.WriteLine("[보유 골드]");
    Console.WriteLine(player.GetGold() + "G");
    Console.WriteLine("");
    Console.WriteLine("1박에 500G 입니다. (최대 체력의 100% 회복)");
    Console.WriteLine("대실에 300G 입니다. (최대 체력의 30% 회복)");
    Console.WriteLine("");
    Console.WriteLine("1.1박하기");
    Console.WriteLine("2.대실하기");
    Console.WriteLine("0.나가기");
    Console.WriteLine("");
    Console.WriteLine("원하시는 행동을 입력 해주세요.");
    int choice = int.Parse(Console.ReadLine());
    if (choice == 0) Town(player);
    else if (choice == 1) rest(player,1);
    else if (choice == 2) rest(player,2);
    else
    {
        Console.WriteLine("잘못된 입력입니다.");
        Thread.Sleep(1000);
        Inn(player);
    }
}

//체력 회복
void rest(InfoManager.InfoManagerPlayer player , int type)
{
    //1박
    if(type == 1)
    {
        //1박 비용 500골드
        if(player.GetGold() >= 500)
        {
            int MaxtHp = player.GetMaxHp();
            player.currentHp = player.maxHp;
            Console.WriteLine("회복을 완료 했습니다.");
            Thread.Sleep(1000);
            Inn(player);
        }
        else
        {
            Console.WriteLine("Gold가 부족합니다.");
            Thread.Sleep(1000);
            Inn(player);
        }
    }
    //대실
    else
    {
        //대실 비용 300 골드
        if (player.GetGold() >= 300)
        {
            int MaxtHp = player.GetMaxHp();
            player.currentHp = player.maxHp / 100 * 30;
            Console.WriteLine("대실을 완료 했습니다.");
            Thread.Sleep(1000);
            Inn(player);
        }
        else
        {
            Console.WriteLine("Gold가 부족합니다.");
            Thread.Sleep(1000);
            Inn(player);
        }
       
    }
}

void Save(InfoManager.InfoManagerPlayer player)
{
    string path = Directory.GetCurrentDirectory();
    path += "\\saveData.txt";
    List<string> saveDate = new List<string>();
    saveDate.Add(player.DungeonClear.ToString());
    saveDate.Add("\n");
    saveDate.Add(player.maxHp.ToString());
    saveDate.Add("\n");
    saveDate.Add(player.currentHp.ToString());
    saveDate.Add("\n");
    saveDate.Add(player.level.ToString());
    saveDate.Add("\n");
    saveDate.Add(player.currentExp.ToString());
    saveDate.Add("\n");
    saveDate.Add(player.maxExp.ToString());
    saveDate.Add("\n");
    saveDate.Add(player.className);
    saveDate.Add("\n");
    saveDate.Add(player.atk.ToString());
    saveDate.Add("\n");
    saveDate.Add(player.def.ToString());
    saveDate.Add("\n");
    saveDate.Add(player.gold.ToString());
    saveDate.Add("\n");
    saveDate.Add(player.equipment[0]);
    saveDate.Add("\n");
    saveDate.Add(player.equipment[1]);
    saveDate.Add("\n");
    saveDate.Add(player.equipment[2]);
    saveDate.Add("\n");
    saveDate.Add(player.maxInventory.ToString());
    saveDate.Add("\n");
    saveDate.Add(player.isbuy[0]);
    saveDate.Add("\n");
    saveDate.Add(player.isbuy[1]);
    saveDate.Add("\n");
    saveDate.Add(player.isbuy[2]);
    saveDate.Add("\n");
    saveDate.Add(player.isbuy[3]);
    saveDate.Add("\n");
    saveDate.Add(player.isbuy[4]);
    saveDate.Add("\n");
    saveDate.Add(player.isbuy[5]);
    saveDate.Add("\n");
    saveDate.Add(player.isbuy[6]);
    saveDate.Add("\n");
    saveDate.Add(player.isbuy[7]);
    saveDate.Add("\n");
    saveDate.Add(player.appendAtk.ToString());
    saveDate.Add("\n");
    saveDate.Add(player.appendDef.ToString());
    saveDate.Add("\n");
    saveDate.Add(player.list.Count.ToString());
    saveDate.Add("\n");
    for (int i = 0; i < player.list.Count; i++)
    {
        saveDate.Add(player.list[i].type);
        saveDate.Add("\n");
        saveDate.Add(player.list[i].name);
        saveDate.Add("\n");
        saveDate.Add(player.list[i].power.ToString());
        saveDate.Add("\n");
        saveDate.Add(player.list[i].price.ToString());
        saveDate.Add("\n");
        saveDate.Add(player.list[i].info);
        saveDate.Add("\n");
        saveDate.Add(player.list[i].number.ToString());
        saveDate.Add("\n");
        saveDate.Add(player.list[i].isEquip.ToString());
        saveDate.Add("\n");
    }
    for (int i = 0; i < saveDate.Count; i++)
    {
        if(i == 0) System.IO.File.WriteAllText(path, saveDate[i], Encoding.Default);
        else System.IO.File.AppendAllText(path, saveDate[i], Encoding.Default);
    }
    Console.WriteLine("저장되었습니다.");
    Thread.Sleep(1000);
    Console.Clear();
    Console.WriteLine("게임을 종료하시겠습니까?");
    Console.WriteLine("1.예");
    Console.WriteLine("2.아니오");
    Console.WriteLine("");
    Console.WriteLine("원하시는 행동을 입력 해주세요.");
    int choice = int.Parse(Console.ReadLine());
    if (choice == 0) Town(player);
    else if (choice == 1)
    {

    }
    else if (choice == 2) Town(player); 
    else
    {
        Console.WriteLine("잘못된 입력입니다.");
        Thread.Sleep(1000);
        Town(player);
    }
}

void Reset(InfoManager.InfoManagerPlayer player)
{
    Console.Clear();
    Console.WriteLine("정말 초기화 하시겠습니까?");
    Console.WriteLine("초기화를 하시면 모든 저장된 데이터가 초기화 됩니다.");
    Console.WriteLine("1.예");
    Console.WriteLine("2.아니오");
    Console.WriteLine("");
    Console.WriteLine("원하시는 행동을 입력 해주세요.");
    int choice = int.Parse(Console.ReadLine());
    if (choice == 0) Reset(player);
    else if (choice == 1)
    {
        Console.WriteLine("초기화를 진행합니다.");
        Thread.Sleep(1000);
    }
    else if (choice == 2) Town(player);
    else
    {
        Console.WriteLine("잘못된 입력입니다.");
        Thread.Sleep(1000);
        Reset(player);
    }
    string path = Directory.GetCurrentDirectory();
    path += "\\saveData.txt";

    string[] saveDate = {"0", "\n100", "\n100","\n1","\n0","\n100","\n모험가","\n10","\n5","\n10000","\n ","\n ","\n ","\n10","\n600G","\n1500G","\n3000G","\n1000G","\n2000G","\n3500G","\n3000G","\n1500G","\n0","\n0","\n0"};
    // text file 의 내용을 한줄 씩 읽어와 string 배열에 대입 합니다.
    for (int i = 0; i < saveDate.Length; i++)
    {
        if (i == 0) System.IO.File.WriteAllText(path, saveDate[i], Encoding.Default);
        else System.IO.File.AppendAllText(path, saveDate[i], Encoding.Default);
    }

    Console.WriteLine("초기화가 완료 되었습니다.");
    Console.WriteLine("마을로 돌아갑니다.");
    Thread.Sleep(1000);
    Title();
}

//시작하기
Title();