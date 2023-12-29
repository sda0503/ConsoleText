void init()
{
    Player player = new Player();
    Town(player);
}


void Town(Player player)
{
    Console.Clear();
    Console.WriteLine("");
    Console.WriteLine("");
    Console.WriteLine("1.상태 보기");
    Console.WriteLine("2.인벤토리");
    Console.WriteLine("3.상점");
    Console.WriteLine("4.여관");
    Console.WriteLine("5.전직");
    Console.WriteLine("6.던전");
    Console.WriteLine("7.길드");
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
    else
    {
        Console.WriteLine("잘못된 입력입니다.");
        Thread.Sleep(1000);
        Town(player);
    }
}

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

    if(choice == 0)
    {
        Town(player);
    }
    else
    {
        Console.WriteLine("잘못된 입력입니다.");
        Thread.Sleep(1000);
        State(player);
    }
}

void Inventory(Player player)
{
    Console.Clear();
    Console.WriteLine("[아이템 목록]");
    player.GetItem();
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
    Console.WriteLine("1.무기 -");
    Console.WriteLine("2.방어구 -");
    Console.WriteLine("3.장신구 -");
    Console.WriteLine("0.나가기");
    Console.WriteLine("");
    Console.WriteLine("원하시는 행동을 입력 해주세요.");
    int choice = int.Parse(Console.ReadLine());
    if (choice == 0)
    {
        Inventory(player);
    }
    else if (choice == 1)
    {
        Equipment(player);
    }
    else if (choice == 2)
    {
        Equipment(player);
    }
    else if (choice == 3)
    {
        Equipment(player);
    }
    else
    {
        Console.WriteLine("잘못된 입력입니다.");
        Thread.Sleep(1000);
        Equipment(player);
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
    else
    {
        Console.WriteLine("잘못된 입력입니다.");
        Thread.Sleep(1000);
        Shop(player);
    }
}

void Buy(Player player)
{
    Console.WriteLine("");
    Console.WriteLine("구매하려는 아이탬의 번호를 입력 해주세요.");
    int choice = int.Parse(Console.ReadLine());
    if (choice == 0)
    {
        Shop(player);
    }
    else if (choice == 1)
    {
        if(player.GetGold() >= 600)
        {
            player.SetGold(-600);
            player.AddItem("낡은 검");
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
            player.AddItem("청동 도끼");
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
            player.AddItem("스파르타의 창");
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
            player.AddItem("수련자의 갑옷");
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
            player.AddItem("무쇠갑옷 ");
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
            player.AddItem("스파르타의 갑옷");
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
            player.AddItem("스파르타의 방패");
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
            player.AddItem("팔목보호대");
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


//시작하기
init();


//캐릭터 설정
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
    private int gold = 10000;

    private List<string> list = new List<string>();
    private int maxInventory = 20;

    public void AddItem(string ItemName)
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

    public void GetItem()
    {
        for(int i = 0; i < list.Count; i++)
        {
            Console.WriteLine(list.ElementAt(i));
        }
    }

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
