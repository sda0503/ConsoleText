using System.Numerics;



void Town()
{
    Console.Clear();
    Console.WriteLine("");
    Console.WriteLine("");
    Console.WriteLine("1.상태 보기");
    Console.WriteLine("2.인벤토리");
    Console.WriteLine("3.상점");
    Console.WriteLine("");
    Console.WriteLine("원하시는 행동을 입력 해주세요.");
    int choice = int.Parse(Console.ReadLine());

    if(choice == 1)
    {
        State();
    }
    else if(choice == 2)
    {
        Inventory();
    }
    else if (choice == 3)
    {
        Shop();
    }
    else
    {
        Console.WriteLine("잘못된 입력입니다.");
        Town();
    }
}

void State()
{
    Player player = new Player();
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

    if(choice == 0)
    {
        Town();
    }
    else
    {
        Console.WriteLine("잘못된 입력입니다.");
        State();
    }
}

void Inventory()
{
    Console.Clear();
    Console.WriteLine("[아이템 목록]");
    Console.WriteLine("1.장착 관리");
    Console.WriteLine("0.나가기");
    Console.WriteLine("");
    Console.WriteLine("원하시는 행동을 입력 해주세요.");
    int choice = int.Parse(Console.ReadLine());
    if (choice == 0)
    {
        Town();
    }
    else if (choice == 1)
    {
        Equipment();
    }
    else
    {
        Console.WriteLine("잘못된 입력입니다.");
        Inventory();
    }
}

void Equipment()
{
    Console.Clear();
    Console.WriteLine("[장착 관리]");
    Console.WriteLine("1.무기 -");
    Console.WriteLine("2.방어구 -");
    Console.WriteLine("3.장신구 -");
    Console.WriteLine("0.나가기");
    Console.WriteLine("");
    Console.WriteLine("원하시는 행동을 입력 해주세요.");
    int choice = int.Parse(Console.ReadLine());
    if (choice == 0)
    {
        Inventory();
    }
    else if (choice == 1)
    {
        Equipment();
    }
    else if (choice == 2)
    {
        Equipment();
    }
    else if (choice == 3)
    {
        Equipment();
    }
    else
    {
        Console.WriteLine("잘못된 입력입니다.");
        Equipment();
    }
}

void Shop()
{
    Player player = new Player();

    string[] itemsList = {
    "1.[방어구] 수련자의 갑옷 | 방어력 + 5 | 수련에 도움을 주는 갑옵 입니다. | 1000G",
    "2.[방어구] 무쇠갑옷 | 방어력 +9 | 무쇠로 만들어져 튼튼한 갑옷입니다. | 2000G",
    "3.[방어구] 스파르타의 갑옷 | 방어력 +15 | 스파르타의 전사들이 사용했다는 전설의 갑옷입니다. | 3500G",
    "4.[무기] 낡은 검 | 공격력 +2 | 쉽게 볼 수 있는 낡은 검 입니다. | 600G",
    "5.[무기] 청동 도끼 | 공격력 +5 | 무쇠로 만들어져 튼튼한 갑옷입니다. | 1500G",
    "6.[무기] 스파르타의 창 | 공격력 +9 | 스파르타의 전사들이 사용했다는 전설의 창입니다. | 3500G",
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
    if (choice == 0)
    {
        Town();
    }
    else if (choice == 1)
    {
        Buy();
    }
    else
    {
        Console.WriteLine("잘못된 입력입니다.");
        Shop();
    }
}

void Buy()
{
    Console.WriteLine("");
    Console.WriteLine("구매하려는 아이탬의 번호를 입력 해주세요.");
    int choice = int.Parse(Console.ReadLine());
    if (choice == 0)
    {
        Shop();
    }
    else if (choice == 1)
    {
        Buy();
    }
    else if (choice == 2)
    {
        Buy();
    }
    else if (choice == 3)
    {
        Buy();
    }
    else if (choice == 4)
    {
        Buy();
    }
    else if (choice == 5)
    {
        Buy();
    }
    else if (choice == 6)
    {
        Buy();
    }
    else if (choice == 7)
    {
        Buy();
    }
    else if (choice == 8)
    {
        Buy();
    }
    else
    {
        Console.WriteLine("잘못된 입력입니다.");
        Buy();
    }
}





Town();


class Player
{
    private int maxHp = 100;
    private int currentHp = 100;
    private int level =1;
    private int currenyExp = 0;
    private int maxExp = 100;
    private string className = "모험가";
    private int atk = 10;
    private int def = 5;
    private int gold = 100;

    public int SetMaxHp(int add)
    {
        maxHp += add;
        return maxHp;
    }

    public int GetMaxHp()
    {
        return maxHp;
    }

    public int SetHp(int add)
    {
        currentHp += add;
        return currentHp;
    }

    public int GetHp()
    {
        return currentHp;
    }

    public int SetAtk(int add)
    {
        atk += add;
        return atk;
    }

    public int GetAtk()
    {
        return atk;
    }

    public int SetDef(int add)
    {
        def += add;
        return def;
    }

    public int GetDef()
    {
        return def;
    }

    public string SetClassName(string jobname)
    {
        className = jobname;
        return className;
    }
    public string GetClassName()
    {
        return className;
    }


    public int SetLevel()
    {
        return level++;
    }

    public int GetLevel()
    {
        return level;
    }

    public int GetGold()
    {
        return gold;
    }

    public int SetGold(int addGold)
    {
        gold += addGold;
        return gold;
    }
}
