using System;
using System.IO;
using System.Collections.Generic;
using System.Numerics;
using System.Text;




void init()
{
    // 읽어올 text file 의 경로를 지정 합니다.
    string path = Directory.GetCurrentDirectory();
    path += "\\saveData.txt";
    
    // text file 의 내용을 한줄 씩 읽어와 string 배열에 대입 합니다.
    string[] textValue = System.IO.File.ReadAllLines(path);
    
    /*
    if (textValue.Length > 0)
    {
        for (int i = 0; i < textValue.Length; i++)
        {
            Console.WriteLine("Text File " + (i + 1).ToString() + "번째 줄.");
            // 읽어온 내용을 한줄 씩 출력 합니다.
            Console.WriteLine(textValue[i]);
            Console.WriteLine();
        }
        int choice = int.Parse(Console.ReadLine());
    }
    */
    //플레이어 초기화
    Player player = new Player();
    //메모장 로드
    player.maxHp = Convert.ToInt32(textValue[0]);
    player.currentHp = Convert.ToInt32(textValue[1]);
    player.level = Convert.ToInt32(textValue[2]);
    player.currentExp = Convert.ToInt32(textValue[3]);
    player.maxExp = Convert.ToInt32(textValue[4]);
    player.className = textValue[5];
    player.atk = Convert.ToInt32(textValue[6]);
    player.def = Convert.ToInt32(textValue[7]);
    player.gold = Convert.ToInt32(textValue[8]);
    player.equipment[0] = textValue[9];
    player.equipment[1] = textValue[10];
    player.equipment[2] = textValue[11];
    player.maxInventory = Convert.ToInt32(textValue[12]);


    //게임 시작
    Town(player);
}


//마을
void Town(Player player)
{
    Console.Clear();
    Console.WriteLine("");
    Console.WriteLine("");
    Console.WriteLine("1.상태보기");
    Console.WriteLine("2.인벤토리");
    Console.WriteLine("3.상점");
    Console.WriteLine("4.여관");
    Console.WriteLine("5.전직");
    Console.WriteLine("6.던전");
    Console.WriteLine("7.길드");
    Console.WriteLine("8.저장");
    Console.WriteLine("9.초기화");
    Console.WriteLine("");
    Console.WriteLine("원하시는 행동을 입력 해주세요.");
    int choice = int.Parse(Console.ReadLine());

    if(choice == 1)       State(player);
    else if(choice == 2)  Inventory(player);
    else if (choice == 3) Shop(player);
    else if (choice == 4) Inn(player);
    else if (choice == 5) Shop(player);  
    else if (choice == 6) Shop(player);
    else if (choice == 7) Shop(player);
    else if (choice == 8) Save(player);
    else if (choice == 8) Reset(player);
    else
    {
        Console.WriteLine("잘못된 입력입니다.");
        Thread.Sleep(1000);
        Town(player);
    }
}

//상태보기
void State(Player player)
{
    
    Console.Clear();
    Console.WriteLine("Lv." + player.GetLevel());
    Console.WriteLine("직업 :" + player.GetClassName());
    Console.WriteLine("공격력 :" + player.GetAtk());
    Console.WriteLine("방어력 :" + player.GetDef());
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
void Inventory(Player player)
{
    Console.Clear();
    Console.WriteLine("[보유 골드]");
    Console.WriteLine(player.GetGold() + "G");
    Console.WriteLine("");
    Console.WriteLine("[아이템 목록]");
    player.GetItemName();
    Console.WriteLine("");
    Console.WriteLine("1.장착 관리");
    Console.WriteLine("0.나가기");
    Console.WriteLine("");
    Console.WriteLine("원하시는 행동을 입력 해주세요.");
    int choice = int.Parse(Console.ReadLine());
    if (choice == 0)
    {
        Town(player);
    }
    else if (choice == 1)
    {
        Equipment(player);
    }
    else
    {
        Console.WriteLine("잘못된 입력입니다.");
        Thread.Sleep(1000);
        Inventory(player);
    }
}

void Equipment(Player player)
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
void EquipmentItem(Player player, int type) 
{
    //장비 분류
    List<Item> weaponItem = new List<Item>(); //무기 리스트
    List<Item> armorItem = new List<Item>();  //방어구 리스트
    List<Item> accItem = new List<Item>();    //장신구 리스트

    for (int i = 0; i < player.list.Count; i++)
    {
        if (player.list[i].type == "[무기]")weaponItem.Add(player.list[i]);
        if (player.list[i].type == "[방어구]")armorItem.Add(player.list[i]);
        if (player.list[i].type == "[장신구]")accItem.Add(player.list[i]);
    }

    if (type == 1)
    {
        Console.Clear();
        Console.WriteLine("[무기 장착]");
        Console.WriteLine("");
        Console.WriteLine("장착 가능 무기");
        for (int i = 0; i < weaponItem.Count; i++)
        {
            Console.WriteLine((i+1)+ weaponItem[i].name);
        }
        Console.WriteLine("0.나가기");
        Console.WriteLine("");
        Console.WriteLine("장착을 원하는 무기의 번호를 고르세요");
        Console.WriteLine("");
        Console.WriteLine("원하시는 행동을 입력 해주세요.");
        Console.WriteLine("0 ~ "+ weaponItem.Count);
        int choice = int.Parse(Console.ReadLine());
        if (choice == 0) Inventory(player);
        else if(choice == 1 && weaponItem[0].type == "[무기]")
        {
            player.equipment[0] = weaponItem[0].name;
            for (int i = 0; i < player.list.Count; i++)
            {
                if (weaponItem[0].name == player.list[i].name)
                {
                    player.list[i].isEquip = true;
                    player.list[i].name = "[E]" + player.list[i].name;
                }
                else if(player.list[i].isEquip == true && player.list[i].type == "[무기]")
                {
                    string tmp = player.list[i].name;
                    string tmp1 = tmp.Substring(3, -1);
                    player.list[i].name = tmp1;
                }
            }
            Console.WriteLine(player.equipment[0] + "을 장착하였습니다.");
            Thread.Sleep(1000);
            Equipment(player);
        }
        else if (choice == 2 && weaponItem[1].type == "[무기]")
        {
            player.equipment[0] = weaponItem[1].name;
            for (int i = 0; i < player.list.Count; i++)
            {
                if (weaponItem[0].name == player.list[i].name)
                {
                    player.list[i].isEquip = true;
                    player.list[i].name = "[E]" + player.list[i].name;
                }
                else if (player.list[i].isEquip == true && player.list[i].type == "[무기]")
                {
                    string tmp = player.list[i].name;
                    string tmp1 = tmp.Substring(3, -1);
                    player.list[i].name = tmp1;
                }
            }
            Console.WriteLine(player.equipment[0] + "을 장착하였습니다.");
            Thread.Sleep(1000);
            Equipment(player);
        }
        else if (choice == 3 && weaponItem[2].type == "[무기]")
        {
            player.equipment[0] = weaponItem[2].name;
            for (int i = 0; i < player.list.Count; i++)
            {
                if (weaponItem[2].name == player.list[i].name)
                {
                    player.list[i].isEquip = true;
                    player.list[i].name = "[E]" + player.list[i].name;
                }
                else if (player.list[i].isEquip == true && player.list[i].type == "[무기]")
                {
                    string tmp = player.list[i].name;
                    string tmp1 = tmp.Substring(3, -1);
                    player.list[i].name = tmp1;
                }
            }
            Console.WriteLine(player.equipment[0] + "을 장착하였습니다.");
            Thread.Sleep(1000);
            Equipment(player);
        }
        else if (choice == 4 && weaponItem[3].type == "[무기]")
        {
            player.equipment[0] = weaponItem[3].name;
            for (int i = 0; i < player.list.Count; i++)
            {
                if (weaponItem[3].name == player.list[i].name)
                {
                    player.list[i].isEquip = true;
                    player.list[i].name = "[E]" + player.list[i].name;
                }
                else if (player.list[i].isEquip == true && player.list[i].type == "[무기]")
                {
                    string tmp = player.list[i].name;
                    string tmp1 = tmp.Substring(3, -1);
                    player.list[i].name = tmp1;
                }
            }
            Console.WriteLine(player.equipment[0] + "을 장착하였습니다.");
            Thread.Sleep(1000);
            Equipment(player);
        }
        else if (choice == 5 && weaponItem[4].type == "[무기]")
        {
            player.equipment[0] = weaponItem[4].name;
            for (int i = 0; i < player.list.Count; i++)
            {
                if (weaponItem[4].name == player.list[i].name)
                {
                    player.list[i].isEquip = true;
                    player.list[i].name = "[E]" + player.list[i].name;
                }
                else if (player.list[i].isEquip == true && player.list[i].type == "[무기]")
                {
                    string tmp = player.list[i].name;
                    string tmp1 = tmp.Substring(3, -1);
                    player.list[i].name = tmp1;
                }
            }
            Console.WriteLine(player.equipment[0] + "을 장착하였습니다.");
            Thread.Sleep(1000);
            Equipment(player);
        }
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
            Console.WriteLine((i + 1) + armorItem[i].name);
        }
        Console.WriteLine("0.나가기");
        Console.WriteLine("");
        Console.WriteLine("장착을 원하는 방어구의 번호를 고르세요");
        Console.WriteLine("");
        Console.WriteLine("원하시는 행동을 입력 해주세요.");
        Console.WriteLine("0 ~ " + armorItem.Count);
        int choice = int.Parse(Console.ReadLine());
        if (choice == 0) Inventory(player);
        else if (choice == 1 && armorItem[0].type == "[방어구]")
        {
            player.equipment[1] = armorItem[0].name;
            for (int i = 0; i < player.list.Count; i++)
            {
                if (armorItem[0].name == player.list[i].name)
                {
                    player.list[i].isEquip = true;
                    player.list[i].name = "[E]" + player.list[i].name;
                }
                else if (player.list[i].isEquip == true && player.list[i].type == "[방어구]")
                {
                    string tmp = player.list[i].name;
                    string tmp1 = tmp.Substring(3, -1);
                    player.list[i].name = tmp1;
                }
            }
            Console.WriteLine(player.equipment[1] + "을 장착하였습니다.");
            Thread.Sleep(1000);
            Equipment(player);
        }
        else if (choice == 2 && armorItem[1].type == "[방어구]")
        {
            player.equipment[1] = armorItem[1].name;
            for (int i = 0; i < player.list.Count; i++)
            {
                if (armorItem[1].name == player.list[i].name)
                {
                    player.list[i].isEquip = true;
                    player.list[i].name = "[E]" + player.list[i].name;
                }
                else if (player.list[i].isEquip == true && player.list[i].type == "[방어구]")
                {
                    string tmp = player.list[i].name;
                    string tmp1 = tmp.Substring(3, -1);
                    player.list[i].name = tmp1;
                }
            }
            Console.WriteLine(player.equipment[1] + "을 장착하였습니다.");
            Thread.Sleep(1000);
            Equipment(player);
        }
        else if (choice == 3 && armorItem[2].type == "[방어구]")
        {
            player.equipment[1] = armorItem[2].name;
            for (int i = 0; i < player.list.Count; i++)
            {
                if (armorItem[2].name == player.list[i].name)
                {
                    player.list[i].isEquip = true;
                    player.list[i].name = "[E]" + player.list[i].name;
                }
                else if (player.list[i].isEquip == true && player.list[i].type == "[방어구]")
                {
                    string tmp = player.list[i].name;
                    string tmp1 = tmp.Substring(3, -1);
                    player.list[i].name = tmp1;
                }
            }
            Console.WriteLine(player.equipment[1] + "을 장착하였습니다.");
            Thread.Sleep(1000);
            Equipment(player);
        }
        else if (choice == 4 && armorItem[3].type == "[방어구]")
        {
            player.equipment[1] = armorItem[3].name;
            for (int i = 0; i < player.list.Count; i++)
            {
                if (armorItem[3].name == player.list[i].name)
                {
                    player.list[i].isEquip = true;
                    player.list[i].name = "[E]" + player.list[i].name;
                }
                else if (player.list[i].isEquip == true && player.list[i].type == "[방어구]")
                {
                    string tmp = player.list[i].name;
                    string tmp1 = tmp.Substring(3, -1);
                    player.list[i].name = tmp1;
                }
            }
            Console.WriteLine(player.equipment[1] + "을 장착하였습니다.");
            Thread.Sleep(1000);
            Equipment(player);
        }
        else if (choice == 5 && armorItem[4].type == "[방어구]")
        {
            player.equipment[1] = armorItem[4].name;
            for (int i = 0; i < player.list.Count; i++)
            {
                if (armorItem[4].name == player.list[i].name)
                {
                    player.list[i].isEquip = true;
                    player.list[i].name = "[E]" + player.list[i].name;
                }
                else if (player.list[i].isEquip == true && player.list[i].type == "[방어구]")
                {
                    string tmp = player.list[i].name;
                    string tmp1 = tmp.Substring(3, -1);
                    player.list[i].name = tmp1;
                }
            }
            Console.WriteLine(player.equipment[1] + "을 장착하였습니다.");
            Thread.Sleep(1000);
            Equipment(player);
        }
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
            Console.WriteLine((i + 1) + accItem[i].name);
        }
        Console.WriteLine("0.나가기");
        Console.WriteLine("");
        Console.WriteLine("장착을 원하는 장신구의 번호를 고르세요");
        Console.WriteLine("");
        Console.WriteLine("원하시는 행동을 입력 해주세요.");
        Console.WriteLine("0 ~ " + accItem.Count);
        int choice = int.Parse(Console.ReadLine());
        if (choice == 0) Inventory(player);
        else if (choice == 1 && armorItem[0].type == "[장신구]")
        {
            player.equipment[2] = accItem[0].name;
            for (int i = 0; i < player.list.Count; i++)
            {
                if (accItem[0].name == player.list[i].name)
                {
                    player.list[i].isEquip = true;
                    player.list[i].name = "[E]" + player.list[i].name;
                }
                else if (player.list[i].isEquip == true && player.list[i].type == "[장신구]")
                {
                    string tmp = player.list[i].name;
                    string tmp1 = tmp.Substring(3, -1);
                    player.list[i].name = tmp1;
                }
            }
            Console.WriteLine(player.equipment[2] + "을 장착하였습니다.");
            Thread.Sleep(1000);
            Equipment(player);
        }
        else if (choice == 2 && armorItem[1].type == "[장신구]")
        {
            player.equipment[2] = accItem[1].name;
            for (int i = 0; i < player.list.Count; i++)
            {
                if (accItem[1].name == player.list[i].name)
                {
                    player.list[i].isEquip = true;
                    player.list[i].name = "[E]" + player.list[i].name;
                }
                else if (player.list[i].isEquip == true && player.list[i].type == "[장신구]")
                {
                    string tmp = player.list[i].name;
                    string tmp1 = tmp.Substring(3, -1);
                    player.list[i].name = tmp1;
                }
            }
            Console.WriteLine(player.equipment[2] + "을 장착하였습니다.");
            Thread.Sleep(1000);
            Equipment(player);
        }
        else if (choice == 3 && armorItem[2].type == "[방어구]")
        {
            player.equipment[1] = armorItem[2].name;
            for (int i = 0; i < player.list.Count; i++)
            {
                if (armorItem[2].name == player.list[i].name)
                {
                    player.list[i].isEquip = true;
                    player.list[i].name = "[E]" + player.list[i].name;
                }
                else if (player.list[i].isEquip == true && player.list[i].type == "[방어구]")
                {
                    string tmp = player.list[i].name;
                    string tmp1 = tmp.Substring(3, -1);
                    player.list[i].name = tmp1;
                }
            }
            Console.WriteLine(player.equipment[2] + "을 장착하였습니다.");
            Thread.Sleep(1000);
            Equipment(player);
        }
        else if (choice == 4 && armorItem[3].type == "[방어구]")
        {
            player.equipment[1] = armorItem[3].name;
            for (int i = 0; i < player.list.Count; i++)
            {
                if (armorItem[3].name == player.list[i].name)
                {
                    player.list[i].isEquip = true;
                    player.list[i].name = "[E]" + player.list[i].name;
                }
                else if (player.list[i].isEquip == true && player.list[i].type == "[방어구]")
                {
                    string tmp = player.list[i].name;
                    string tmp1 = tmp.Substring(3, -1);
                    player.list[i].name = tmp1;
                }
            }
            Console.WriteLine(player.equipment[2] + "을 장착하였습니다.");
            Thread.Sleep(1000);
            Equipment(player);
        }
        else if (choice == 5 && armorItem[4].type == "[방어구]")
        {
            player.equipment[1] = armorItem[4].name;
            for (int i = 0; i < player.list.Count; i++)
            {
                if (armorItem[4].name == player.list[i].name)
                {
                    player.list[i].isEquip = true;
                    player.list[i].name = "[E]" + player.list[i].name;
                }
                else if (player.list[i].isEquip == true && player.list[i].type == "[방어구]")
                {
                    string tmp = player.list[i].name;
                    string tmp1 = tmp.Substring(3, -1);
                    player.list[i].name = tmp1;
                }
            }
            Console.WriteLine(player.equipment[2] + "을 장착하였습니다.");
            Thread.Sleep(1000);
            Equipment(player);
        }
        else
        {
            Console.WriteLine("잘못된 입력입니다.");
            Thread.Sleep(1000);
            Equipment(player);
        }
    }
}

void Shop(Player player)
{
    string[] itemsList = {
    "1.[무기] 낡은 검 | 공격력 +2 | 쉽게 볼 수 있는 낡은 검 입니다. | 600G",
    "2.[무기] 청동 도끼 | 공격력 +5 | 무쇠로 만들어져 튼튼한 갑옷입니다. | 1500G",
    "3.[무기] 스파르타의 창 | 공격력 +9 | 스파르타의 전사들이 사용했다는 전설의 창입니다. | 3500G",
    "4.[방어구] 수련자의 갑옷 | 방어력 + 5 | 수련에 도움을 주는 갑옵 입니다. | 1000G",
    "5.[방어구] 무쇠갑옷 | 방어력 +9 | 무쇠로 만들어져 튼튼한 갑옷입니다. | 2000G",
    "6.[방어구] 스파르타의 갑옷 | 방어력 +15 | 스파르타의 전사들이 사용했다는 전설의 갑옷입니다. | 3500G",
    "7.[장신구] 스파르타의 방패 | 방어력 +10| 스파르타의 전사들이 사용했다는 전설의 방패입니다. | 3000G",
    "8.[장신구] 팔목보호대 | 방어력 +3 | 착용자의 팔목을 보호해주는 보호대 | 1000G",
};



    Console.Clear();
    Console.WriteLine("[보유 골드]");
    Console.WriteLine(player.GetGold()+"G");
    Console.WriteLine("");
    Console.WriteLine("[아이템 목록]");
    for(int i = 0; i< itemsList.Length; i++)
    {
        Console.WriteLine(itemsList[i]);
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
    else if (choice == 1)Buy(player);
    else if (choice == 2) Sell(player);
    else
    {
        Console.WriteLine("잘못된 입력입니다.");
        Thread.Sleep(1000);
        Shop(player);
    }
}

//구매
void Buy(Player player)
{
    Console.WriteLine("");
    Console.WriteLine("구매하려는 아이탬의 번호를 입력 해주세요.");
    int choice = int.Parse(Console.ReadLine());
    if (choice == 0)Shop(player);
    else if (choice == 1)
    {
        if(player.GetGold() >= 600)
        {
            player.SetGold(-600);
            player.AddItem(new Item() {type = "[무기]", name ="낡은 검", power=2, price=600, info= "쉽게 볼 수 있는 낡은 검 입니다." });
            Console.WriteLine("구매를 완료했습니다.");
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
    else if (choice == 2)
    {
        if (player.GetGold() >= 1500)
        {
            player.SetGold(-1500);
            player.AddItem(new Item() { type = "[무기]", name = "청동 도끼", power = 5, price = 1500, info = "무쇠로 만들어져 튼튼한 갑옷입니다." });
            Console.WriteLine("구매를 완료했습니다.");
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
    else if (choice == 3)
    {
        if (player.GetGold() >= 3500)
        {
            player.SetGold(-3500);
            player.AddItem(new Item() { type = "[무기]", name = "스파르타의 창", power = 9, price = 3500, info = "스파르타의 전사들이 사용했다는 전설의 창입니다." });
            Console.WriteLine("구매를 완료했습니다.");
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



    else if (choice == 4)
    {
        if (player.GetGold() >= 1000)
        {
            player.SetGold(-1000);
            player.AddItem(new Item() { type = "[방어구]", name = "수련자의 갑옷", power = 5, price = 1000, info = "수련에 도움을 주는 갑옵 입니다." });
            Console.WriteLine("구매를 완료했습니다.");
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

    else if (choice == 5)
    {
        if (player.GetGold() >= 2000)
        {
            player.SetGold(-2000);
            player.AddItem(new Item() { type = "[방어구]", name = "무쇠갑옷 ", power = 9, price = 2000, info = "무쇠로 만들어져 튼튼한 갑옷입니다." });
            Console.WriteLine("구매를 완료했습니다.");
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

    else if (choice == 6)
    {
        if (player.GetGold() >= 3500)
        {
            player.SetGold(-3500);
            player.AddItem(new Item() { type = "[방어구]", name = "스파르타의 갑옷", power = 15, price = 3500, info = "스파르타의 전사들이 사용했다는 전설의 갑옷입니다." });
            Console.WriteLine("구매를 완료했습니다.");
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

    else if (choice == 7)
    {
        if (player.GetGold() >= 3000)
        {
            player.SetGold(-3000);
            player.AddItem(new Item() { type = "[장신구]", name = "스파르타의 방패", power = 10, price = 3000, info = "스파르타의 전사들이 사용했다는 전설의 방패입니다." });
            Console.WriteLine("구매를 완료했습니다.");
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

    else if (choice == 8)
    {
        if (player.GetGold() >= 1000)
        {
            player.SetGold(-1000);
            player.AddItem(new Item() { type = "[장신구]", name = "팔목보호대", power = 3, price = 1000, info = "착용자의 팔목을 보호해주는 보호대입니다." });
            Console.WriteLine("구매를 완료했습니다.");
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
    
    else
    {
        Console.WriteLine("잘못된 입력입니다.");
        Thread.Sleep(1000);
        Buy(player);
    }
}

//판매
void Sell(Player player)
{
    Console.Clear();
    Console.WriteLine("");
    Console.WriteLine("[보유 골드]");
    Console.WriteLine(player.GetGold() + "G");
    Console.WriteLine("");
    Console.WriteLine("[아이탬 목록]");
    for (int i = 0; i < player.list.Count; i++)
    {
        Console.WriteLine((i + 1)+"."+ player.list[i].name);
    }
    Console.WriteLine("");
    Console.WriteLine("원하시는 행동을 입력 해주세요.");

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
        Sell(player);
    }
}

void sellItem(Player player, int num)
{
    
    if (player.list[num].isEquip == true)
    {

        //장착시 판매 안됨
        /*
        Console.WriteLine("장착 아이템은 팔수 없습니다.");
        Sell(player);
        */

        if(player.list[num].type == "[무기]")
        {
            player.equipment[0] = null;
        }
        else if(player.list[num].type == "[방어구]")
        {
            player.equipment[1] = null;
        }
        else if (player.list[num].type == "[장신구]")
        {
            player.equipment[2] = null;
        }
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

//여관
void Inn(Player player)
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
void rest(Player player , int type)
{
    //1박
    if(type == 1)
    {
        //1박 비용 500골드
        if(player.GetGold() >= 500)
        {
            int MaxtHp = player.GetMaxHp();
            player.SetHp(MaxtHp);
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
            player.SetHp(MaxtHp / 100 * 30);
        }
        else
        {
            Console.WriteLine("Gold가 부족합니다.");
            Thread.Sleep(1000);
            Inn(player);
        }
       
    }
}

void Save(Player player)
{
    string path = Directory.GetCurrentDirectory();
    path += "\\saveData.txt";

    string[] saveDate = {
         player.maxHp.ToString(),
        "\n"+player.currentHp.ToString(),
        "\n"+player.level.ToString(),
        "\n"+player.currentExp.ToString(),
        "\n"+player.maxExp.ToString(),
        "\n"+player.className,
        "\n"+player.atk.ToString(),
        "\n"+player.def.ToString(),
        "\n"+player.gold.ToString(),
        "\n"+player.equipment[0],
        "\n"+player.equipment[1],
        "\n"+player.equipment[2],
        "\n"+player.maxInventory.ToString()
    };
    // text file 의 내용을 한줄 씩 읽어와 string 배열에 대입 합니다.
    for(int i = 0; i < saveDate.Length; i++)
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

void Reset(Player player)
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

    string[] saveDate = {
        "100",
        "\n100",
        "\n1",
        "\n0",
        "\n100",
        "\n모험가",
        "\n10",
        "\n5",
        "\n10000",
        "\n ",
        "\n ",
        "\n ",
        "\n10"
    };
    // text file 의 내용을 한줄 씩 읽어와 string 배열에 대입 합니다.
    for (int i = 0; i < saveDate.Length; i++)
    {
        if (i == 0) System.IO.File.WriteAllText(path, saveDate[i], Encoding.Default);
        else System.IO.File.AppendAllText(path, saveDate[i], Encoding.Default);
    }

    Console.WriteLine("초기화가 완료 되었습니다.");
    Console.WriteLine("마을로 돌아갑니다.");
    Thread.Sleep(1000);
    Town(player);
}

//시작하기
init();


//캐릭터 설정
class Player
{
    public int maxHp = 100;
    public int currentHp = 100;
    public int level =1;
    public int currentExp = 0;
    public int maxExp = 100;
    public string className = "모험가";
    public int atk = 10;
    public int def = 5;
    public int gold = 10000;
    public string[] equipment = {"","",""};    //차례 대로 무기, 방어구, 장신구


    public int maxInventory = 10;
    public List<Item> list = new List<Item>();

    public void AddItem(Item ItemName)
    {
        if(list.Count <= maxInventory)
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
        if(list.Count == 0)
        {
            Console.WriteLine("보유중인 아이템이 없습니다.");
        }
        else{
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list.ElementAt(i).name);
            }
        }
    }

    public int SetMaxHp(int add){maxHp += add; return maxHp;}
    public int GetMaxHp(){return maxHp;}
    public int SetHp(int add){currentHp += add; return currentHp;}
    public int GetHp(){return currentHp;}
    public int SetAtk(int add){atk += add; return atk;}
    public int GetAtk(){return atk;}
    public int SetDef(int add){def += add; return def;}
    public int GetDef(){return def;}
    public string SetClassName(string jobname){className = jobname; return className;}
    public string GetClassName(){return className;}
    public int SetLevel(){return level++;}
    public int GetLevel(){return level;}
    public int GetGold(){return gold;}
    public int SetGold(int addGold){gold += addGold; return gold;}
}

class Item
{
    public string type;
    public string name;
    public int power;
    public int price;
    public string info;
    public bool isEquip = false;
}