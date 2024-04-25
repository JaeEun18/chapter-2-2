using System.Diagnostics;
using System.Numerics;

namespace Chapter2_k
{
    internal class Program
    {
        static Player player;

        // Player 관련 값 const 변수
        const int PLAYER_LEVEL = 100;
        const int PLAYER_HP = 100;
        const int PLAYER_POWER = 30;
        const int PLAYER_SHIELD = 5;
        const int PLAYER_MONEY = 800;

        static int playState = 0;

        static List<Item> storeItemList = new List<Item>();


        static void Main(string[] args)
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine("\n1.상태 보기\t 2.인벤 토리 \t 3.상점");
            Console.WriteLine("\n\n원하시는 행동을 입력해주세요.");
            Console.WriteLine(">>");
            string start = Console.ReadLine();

            bool GameOver = false;

            //while (!GameOver)
            //{
            //    Console.Clear();
            //    ReStart();
            //    //1,2,3번 선택 후 다음으로 넘어가지면 초기 화면으로 다시 돌아오는 방법을 모르겠다..

                switch (start)
            {
                case "1":
                    SelectPlaystatus();
                    break;
                case "2":
                    SelectInventory();
                    break;
                case "3":
                    SelectShop();
                    break;
                default:
                    EndGame();
                    GameOver = true;
                    break;
            }
                //}


        }

        static void SelectPlaystatus()
        {
            Console.Write("Player 닉네임을 입력해주세요 : ");
            string playerName = Console.ReadLine();
            Console.WriteLine(
                "Lv." + PLAYER_LEVEL +
                "\n Chad ( " + playerName + " )" +
                "\n 공격력: " + PLAYER_POWER +
                "\n 방어력: " + PLAYER_SHIELD +
                "\n 체력: " + PLAYER_HP +
                "\n Gold: " + PLAYER_MONEY +
                "\n원하시는 행동을 입력해주세요." +
                "\n>>");
            // 여기서 어떻게해야 처음 선택 초기화 창으로 넘어가는 가는거지..?
            // 또 새로운 switch문을 똑같이 달아서 초기 화면 처럼 만들어야 하는지..아니면 처음으로 돌리는 명령어가 뭔지..
            // 장착한 아이템에 따라 수치 변경 미구현

        }

        static void SelectInventory()
        {
            //Console.ForegroundColor = ConsoleColor.Cyan;
            //Console.Write("인벤토리");
            //Console.ResetColor();

            //Console.WriteLine(
            //    "\n보유 중인 아이템을 관리할 수 있습니다." +
            //    "\n\n[아이템 목록]" +
            //    "\n\n1. 장착 관리" +
            //    "\n0. 나가기" +
            //    "\n0. 원하시는 행동을 입력해주세요." +
            //    "\n>>");
            // 상점에서 아이템을 구매했을 경우만 아이템 목록 밑에 구매한 아이템이 보이게끔 해야하는데..

            while (playState == 2)
            {
                if (player.GetItemCount() == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("보유하고 있는 아이템이 없습니다!");
                    Console.WriteLine("인벤토리를 닫습니다");
                    playState = 0;
                    break;
                }

                Console.WriteLine();
                Console.WriteLine("{0}의 아이템 인벤토리", player.Name);
                player.OpenItemInventory();

                Console.WriteLine();
                Console.WriteLine("1: 아이템 사용\t0: 인벤토리 닫기");
                Console.Write("선택: ");
                int select = getPlayerSelect(0, 1);
                if (select == 0)
                {
                    playState = 0;
                }
                else
                {
                    Console.WriteLine();
                    Console.Write("아이템 번호 선택: ");
                    int itemIdx = getPlayerSelect(1, player.GetItemCount()) - 1;
                    player.UseItem(itemIdx);
                    Console.Clear();
                    ReStart();
                }

            }

        }

            static void SelectShop()
            {
            //Console.ForegroundColor = ConsoleColor.Green;
            //Console.Write("상점");
            //Console.ResetColor();

            //Console.WriteLine(
            //    "\n필요한 아이템을 얻을 수 있는 상점 입니다." +
            //    "\n\n[보유 골드]" +
            //    "\n800G" +
            //    "\n\n[아이템 목록]" +
            //    "\n- 수련자 갑옷    | 방어력 +5  | 수련에 도움을 주는 갑옷입니다. |  1000 G" +
            //    "\n- 무쇠갑옷       | 방어력 +9  | 무쇠로 만들어져 튼튼한 갑옷입니다. |  3500 G" +
            //    "\n- 스파르타의 갑옷 | 방어력 +15 | 스파르타의 전사들이 사용했다는 전설의 갑옷입니다. |  5500 G" +
            //    "\n- 낡은 검      | 공격력 +2  | 쉽게 볼 수 있는 낡은 검 입니다. |  500 G" +
            //    "\n- 청동 도끼     | 공격력 +5  |  어디선가 사용됐던거 같은 도끼입니다. |  1500 G" +
            //    "\n- 스파르타의 창  | 공격력 +7  | 스파르타의 전사들이 사용했다는 전설의 창입니다. |  2500 G" +
            //    "\n\n1. 아이템 구매" +
            //    "\n0. 나가기" +
            //    "\n\n원하시는 행동을 입력해주세요." +
            //    "\n>>");

            while (playState == 3)
            {
                if (storeItemList.Count == 0)
                {
                    UpdateStore();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("상점 아이템 목록");
                    int idx = 1;
                    foreach (Item item in storeItemList)
                    {
                        Console.WriteLine("{0}. 종류 {1}\t효능 +{2}\t가격 {3}", idx, item.Name, item.Value, item.Price);
                        idx++;
                    }

                    Console.WriteLine();
                    Console.WriteLine("1: 아이템 구매\t2: 상점 업데이트\t0: 상점 나가기");
                    Console.Write("선택: ");
                    int select = getPlayerSelect(0, 2);
                    switch (select)
                    {
                        case 0:
                            playState = 0;
                            break;
                        case 1:
                            BuyItem();
                            Thread.Sleep(1000);
                            Console.Clear();
                            ReStart();
                            break;
                        case 2:
                            storeItemList = new List<Item>();
                            break;
                    }
                }
            }
        }

            static void EndGame()
            {
                Console.WriteLine();
                Console.WriteLine("잘못 된 입력입니다.");
                Console.WriteLine("게임을 종료합니다!");
            }

            static void ReStart() //n번 선택 후 > ReStart > 다시 start switch문이 동작되는게 아닌가보다... ㅜㅜ
            {
                Console.WriteLine(
                    player.Name,
                    player.HP,
                    player.Shield,
                    player.Power,
                    player.Money
                    );
            }

            static int getPlayerSelect(int start, int end)
            {
                int select = 0;
                bool isNum = false;
                while (true)
                {
                    isNum = int.TryParse(Console.ReadLine(), out select);
                    if (!isNum || (select < start || select > end))
                    {
                        Console.WriteLine("잘못된 선택입니다. 다시 고르세요");
                    }
                    else break;
                }
                return select;
            }

            static void UpdateStore()
            {
                Console.Clear();
                ReStart();
                Console.WriteLine();
                Console.WriteLine("처음 상점 화면으로 돌아갑니다!");
            }

            static void BuyItem()
            {
                Console.WriteLine();
                Console.Write("구매할 아이템 번호를 입력하세요: ");

            }
    }
}
