using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands
{
    class Program
    {
       public  enum PokerHandEnum
        {
            None,
            High,
            One_Pair,
            Two_Pair,
            Three_of_a_Kind,
            Straight,
            Flush,
            Full_House,
            Four_of_a_Kind,
            Straight_Flush
        };
        static void Main(string[] args)
        {
            string[] players = new string[2];
            string[] player1 = new String[5];
            string[] player2 = new string[5];
            for (int i = 0; i < 2; i++)
            {
                string Player = Console.ReadLine();
                players[i] = Player;
            }

            player1 = players[0].Split(',').ToArray();
            player2 = players[1].Split(',').ToArray();
            Program program = new Program();
            Console.WriteLine(program.ValidatePokerCards(player1).ToString());
            Console.WriteLine(program.ValidatePokerCards(player2).ToString());
            Console.ReadLine();


        }
        
        public PokerHandEnum ValidatePokerCards(string[] pokerhand)
        {
            PokerHandEnum p=PokerHandEnum.High;
            int[] sequence = new int[13];
            //List<KeyValuePair<char, int>> sequence = new List<KeyValuePair<char, int>>()
            //{
            //    new KeyValuePair<char, int>('A',0),
            //    new KeyValuePair<char, int>('2',0),
            //    new KeyValuePair<char, int>('3',0),
            //    new KeyValuePair<char, int>('4',0),
            //    new KeyValuePair<char, int>('5',0),
            //    new KeyValuePair<char, int>('6',0),
            //    new KeyValuePair<char, int>('7',0),
            //    new KeyValuePair<char, int>('8',0),
            //    new KeyValuePair<char, int>('9',0),
            //    new KeyValuePair<char, int>('1',0),
            //    new KeyValuePair<char, int>('J',0),
            //    new KeyValuePair<char, int>('Q',0),
            //    new KeyValuePair<char, int>('K',0),
            //};

            int hashCount = 0;
            Dictionary<char, int> ValueCount = new Dictionary<char, int>();
            Dictionary<char, int> SuitCount = new Dictionary<char, int>();

            int maxSuit = 0;
            int maxValue = 0;
            bool isFlush = false;
            for (int i = 0; i < 5; i++)
            {
                Program.insertSequence(sequence,pokerhand[i][1]);   
                if (ValueCount.ContainsKey(pokerhand[i][1]))
                {

                    ValueCount[pokerhand[i][1]]++;
                    //if (ValueCount[pokerhand[i][1]] > maxValue)
                    //{
                    //    maxValue = ValueCount[pokerhand[i][1]];
                    //}
                }
                else
                {
                    ValueCount.Add(pokerhand[i][1], 1);
                }
                if (SuitCount.ContainsKey(pokerhand[i][0]))
                {
                    SuitCount[pokerhand[i][0]]++;
                    if (SuitCount[pokerhand[i][0]] > maxSuit)
                    {
                        maxSuit = SuitCount[pokerhand[i][0]];
                    }
                }
                else
                {
                    SuitCount.Add(pokerhand[i][0], 1);
                }
            }

            if (maxSuit == 5)
            {
                isFlush = true;
            }
            hashCount = ValueCount.Count;

            if (hashCount == 2)
            {
                foreach (var element in ValueCount)
                {
                    if (element.Value == 2 || element.Value == 3)
                    {
                        p = PokerHandEnum.Full_House;
                        return p;
                    }
                    else
                    {
                        p = PokerHandEnum.Four_of_a_Kind;
                        return p;
                    }
                }
            }
            else if (hashCount == 3)
            {
                foreach (var element in ValueCount)
                {
                    if (element.Value == 2)
                    {
                        p = PokerHandEnum.Two_Pair;
                        return p;
                    }
                    else if (element.Value == 3)
                    {
                        p = PokerHandEnum.Three_of_a_Kind;
                        return p;
                    }
                }
            }
            else if (hashCount == 4)
            {
                p = PokerHandEnum.One_Pair;
                return p;
            }
            else if(hashCount == 5)
            {
                p = PokerHandEnum.High;
                int c = 0;
                for(int j=1;j<13;j++)
                {
                    if(sequence[j]==1)
                    {
                        int pointer = -1;
                        c = 0;
                        for(int i= j;i<j+5 && i<13;i++)
                        {
                            if(sequence[i]==1)
                            {
                                if (pointer==-1 || pointer==i-1)
                                {
                                    pointer = i;
                                    c++;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                        if((sequence[0]==1 && c==4 && ((sequence[12]==1 && sequence[1] == 0)
                            || (sequence[1]==1 && sequence[4]==1 && sequence[12]==0)))|| c==5)
                        {
                            if(isFlush == true)
                            {
                                p = PokerHandEnum.Straight_Flush;
                                return p;
                            }
                            else
                            {
                                p = PokerHandEnum.Straight;
                                return p;
                            }
                        }
                        else if(isFlush == true)
                        {
                            p = PokerHandEnum.Flush;
                            return p;
                        }
                    }
                }

            }
            return p;
        }
        public static void insertSequence(int[] input, char val)
        {
            switch (val)
            {
                case 'A':
                    {
                        input[0]++;
                        break;
                    }
                case '2':
                    {
                        input[1]++;
                        break;
                    }
                case '3':
                    {
                        input[2]++;
                        break;
                    }
                case '4':
                    {
                        input[3]++;
                        break;
                    }
                case '5':
                    {
                        input[4]++;
                        break;
                    }
                case '6':
                    {
                        input[5]++;
                        break;
                    }
                case '7':
                    {
                        input[6]++;
                        break;
                    }
                case '8':
                    {
                        input[7]++;
                        break;
                    }
                case '9':
                    {
                        input[8]++;
                        break;
                    }
                case '1':
                    {
                        input[9]++;
                        break;
                    }
                case 'J':
                    {
                        input[10]++;
                        break;
                    }
                case 'Q':
                    {
                        input[11]++;
                        break;
                    }
                case 'K':
                    {
                        input[12]++;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }

}
