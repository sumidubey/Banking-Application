using System;
using System.Collections.Generic;
using System.Text;

namespace BankingProject
{
    public class BankApp
    {
        public int act_no;
        public String name;
        public double balance;
        public int getAct_no()
        {
            return this.act_no;
        }
        public void setAct_no(int act_no)
        {
            this.act_no = act_no;
        }
        public String getName()
        {
            return this.name;
        }
        public void setName(String name)
        {
            this.name = name;
        }
        public double getBalance()
        {
            return this.balance;
        }
        public void setBalance(double balance)
        {
            this.balance = balance;
        }
    }
    public class BankWindow : BankApp
    {
        public static void Main(String[] args)
        {
            Console.WriteLine("BANK APPLICATION\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\nEnter Number of accounts:");
            var n = Convert.ToInt32(Console.ReadLine());
            BankApp[] ba = new BankApp[n];
            var i = 0;
            while (i < n)
            {
                Console.WriteLine("#############################\nEnter Details of " + (i + 1).ToString() + (((i + 1) != 1) ? (((i + 1) != 2) ? (((i + 1) != 3) ? "th" : "rd") : "nd") : "st") + " account:\n------------------");
                ba[i] = new BankApp();
                Console.WriteLine("Enter Account Number:");
                ba[i].act_no = Convert.ToInt32(Console.ReadLine());
                ba[i].setAct_no(ba[i].act_no);
                Console.WriteLine("Enter Account Name:");
                ba[i].name = Console.ReadLine();
                ba[i].setName(ba[i].name);
                Console.WriteLine("Enter Account Balance:");
                ba[i].balance = Convert.ToDouble(Console.ReadLine());
                ba[i].setBalance(ba[i].balance);
                i++;
            }
            var c = 'Y';
            do
            {
                Console.WriteLine("Choose the Option: ");
                Console.WriteLine("**************");
                Console.WriteLine("**************");
                Console.WriteLine("1. Display Accounts");
                Console.WriteLine("2. Debit Balance");
                Console.WriteLine("3. Credit Balance");
                Console.WriteLine("4. Transfer Amount");
                Console.WriteLine("**************");
                Console.WriteLine("**************");
                var k = Convert.ToInt32(Console.ReadLine());
                switch (k)
                {
                    case 1:
                        BankWindow.displayAll(ba);
                        Console.WriteLine("*************\nEnter \'Y\' to MAIN-MENU or \'N\' to EXIT");
                        c = Console.ReadLine()[0];
                        break;


                    case 2:
                        Console.WriteLine("Enter the Account number to be debited:");
                        var a_no = Convert.ToInt32(Console.ReadLine());
                        var index = BankWindow.searchAccountNumber(ba, a_no);
                        while (index == -1)
                        {
                            Console.WriteLine("Enter Valid Account Number");
                            a_no = Convert.ToInt32(Console.ReadLine());
                            index = BankWindow.searchAccountNumber(ba, a_no);
                        }
                        Console.WriteLine("Enter the Amount to be Debited:");
                        var d = Convert.ToDouble(Console.ReadLine());
                        BankWindow.debit(ba[index], d);
                        Console.WriteLine("After Debiting, Account summary balance");
                        BankWindow.displayOne(ba[index]);
                        Console.WriteLine("*************\nEnter \'Y\' to MAIN-MENU or \'N\' to EXIT");
                        c = Console.ReadLine()[0];
                        break;


                    case 3:
                        Console.WriteLine("Enter the Account number to be credited:");
                        a_no = Convert.ToInt32(Console.ReadLine());
                        index = BankWindow.searchAccountNumber(ba, a_no);
                        while (index == -1)
                        {
                            Console.WriteLine("Enter Valid Account Number");
                            a_no = Convert.ToInt32(Console.ReadLine());
                            index = BankWindow.searchAccountNumber(ba, a_no);
                        }
                        Console.WriteLine("Enter the Amount to be credited:");
                        d = Convert.ToDouble(Console.ReadLine());
                        BankWindow.credit(ba[index], d);
                        Console.WriteLine("After Crediting, Account summary balance");
                        BankWindow.displayOne(ba[index]);
                        Console.WriteLine("*************\nEnter \'Y\' to MAIN-MENU or \'N\' to EXIT");
                        c = Console.ReadLine()[0];
                        break;


                    case 4:
                        Console.WriteLine("Enter the Debitor Account Number");
                        a_no = Convert.ToInt32(Console.ReadLine());
                        index = BankWindow.searchAccountNumber(ba, a_no);

                        while (index == -1)
                        {
                            Console.WriteLine("Enter Valid Account Number");
                            a_no = Convert.ToInt32(Console.ReadLine());
                            index = BankWindow.searchAccountNumber(ba, a_no);
                        }
                        Console.WriteLine("Enter the Amount to be Transferred:");
                        d = Convert.ToDouble(Console.ReadLine());
                        BankWindow.debit(ba[index], d);
                        Console.WriteLine("After Debiting, Account summary balance");
                        BankWindow.displayOne(ba[index]);
                        Console.WriteLine("Enter the Recipient Account Number ");
                        a_no = Convert.ToInt32(Console.ReadLine());
                        index = BankWindow.searchAccountNumber(ba, a_no);
                        while (index == -1)
                        {
                            Console.WriteLine("Enter Valid Account Number");
                            a_no = Convert.ToInt32(Console.ReadLine());
                            index = BankWindow.searchAccountNumber(ba, a_no);
                        }
                        BankWindow.credit(ba[index], d);
                        Console.WriteLine("After Crediting, Account summary balance");
                        BankWindow.displayOne(ba[index]);
                        Console.WriteLine("*************\nEnter \'Y\' to MAIN-MENU or \'N\' to EXIT");
                        c = Console.ReadLine()[0];
                        break;


                    default:
                        Console.WriteLine("*************\nWrong input......   :(");
                        break;
                }
            } while (c != 'N');
        }
        public static int searchAccountNumber(BankApp[] ba, int a_no)
        {
            var i = 0;
            for (i = 0; i < ba.Length; i++)
            {
                if (a_no == ba[i].getAct_no())
                {
                    return i;
                }
            }
            return -1;
        }
        public static void debit(BankApp b, double d)
        {
            if (d <= b.getBalance())
            {
                var dd = b.getBalance() - d;
                b.setBalance(dd);
            }
            else
            {
                Console.WriteLine("Enter correct debit amount");
            }
        }
        public static void credit(BankApp b, double d)
        {
            if (d > 0)
            {
                var sum = b.getBalance() + d;
                b.setBalance(sum);
            }
            else
            {
                Console.WriteLine("Enter correct credit amout");
            }
        }
        public static void displayAll(BankApp[] ba)
        {
            var i = 0;
            while (i < ba.Length)
            {
                Console.WriteLine("************\nAccount Details:");
                Console.WriteLine("Account Number = " + ba[i].getAct_no().ToString());
                Console.WriteLine("Account Name = " + ba[i].getName());
                Console.WriteLine("Account Balance = " + ba[i].getBalance().ToString());
                i++;
            }
        }
        public static void displayOne(BankApp ba)
        {
            Console.WriteLine("************\nAccount Details:");
            Console.WriteLine("Account Number = " + ba.getAct_no().ToString());
            Console.WriteLine("Account Name = " + ba.getName());
            Console.WriteLine("Account Balance = " + ba.getBalance().ToString());
        }
    }
}
