using System;
using System.Threading;

namespace BinaryClock
{
    class BinaryClock
    {
        int hr,min,sec;
        char[,]clock = new char[4,6]; 
        public static void Main()
        {
            BinaryClock o = new BinaryClock();
            while(true)
                o.Run();
        }

        public void Run()
        {
            hr = (int)DateTime.Now.Hour;                    //Accessing system time
            min = (int)DateTime.Now.Minute;
            sec = (int)DateTime.Now.Second;
            Thread.Sleep(1000);                             //Delay
            Update();
        }
        public String toBinary(int x)                       //Converts int to a string holding binary value of the fed int
        {
            int q=x, r;

            String res="";
            while(q!=0)
            {
                r=q%2;
                res=r.ToString() + res;
                q=q/2;
            }
            int lengthStore = res.Length;
            for(int i=1;i<=(4-lengthStore);i++)
                res ="0"+res;
            return res;
        }
        public void Update()                                //Updates clock every second
        {
            int i;
            String s_last = toBinary(sec%10);
            String s_first = toBinary(sec/10);

            String m_last = toBinary(min%10);
            String m_first = toBinary(min/10);

            String h_last = toBinary(hr%10);
            String h_first = toBinary(hr/10);

            for(i=0;i<4;i++)
            {
                if(s_last[i]=='1')
                    clock[i,5]='X';
                else
                    clock[i,5]=' ';

                if(s_first[i]=='1')
                    clock[i,4]='X';
                else
                    clock[i,4]=' ';

                if(m_last[i]=='1')
                    clock[i,3]='X';
                else
                    clock[i,3]=' ';

                if(m_first[i]=='1')
                    clock[i,2]='X';
                else
                    clock[i,2]=' ';
                
                if(h_last[i]=='1')
                    clock[i,1]='X';
                else
                    clock[i,1]=' ';

                if(h_first[i]=='1')
                    clock[i,0]='X';
                else
                    clock[i,0]=' ';
            }
            Display();
        }

        public void Display()                             //To display the clock
        {
            int i,j;
            Console.Clear();
            for(i=0;i<4;i++)
            {
                for(j=0;j<6;j++)
                {
                    Console.Write("["+clock[i,j]+"]");
                }
                Console.WriteLine();
            }
        }
    }
}