using System;
using System.Collections;
using System.Collections.Generic;

namespace csharp_mianshi
{
    class Program
    {
        static void Main(string[] args)
        {
             MyGame g=new MyGame(); 
            string win =g.start();
            Console.WriteLine(win);
        }

    }
}

/*

作者:明永成
时间:2021/8/21
功能:取火柴游戏


*/
public class MyGame{
    //存放盒子列表
    public Dictionary<int,Stack> Boxes=new Dictionary<int,Stack>();
    public MyGame(){            
        // 创建3个盒子,编号1,2,3
        Boxes.Add(1,new Stack());
        Boxes.Add(2,new Stack());
        Boxes.Add(3,new Stack());

        //盒子分别装入3,5,7根火柴
        Load(Boxes[1],3);
        Load(Boxes[2],5);
        Load(Boxes[3],7);
    }
        //指定盒子装入指定数目的火柴
        private void Load(Stack box,int count)
        {
            while (count>0)
            {
                box.Push("1根火柴");
                count--;   
            }
        }

        //从指定盒子取指定数目的火柴
        private void Take(Stack box,int count)
        {
            if (box.Count<count)//盒子里面的火柴不够,直接返回
            {
                throw new Exception("取出盒子的数量有误");
            }
            while (count>0)
            {
                box.Pop();
                count--;   
            }
        }

        
        //获得火柴数目
        private int get_box_count(Stack box)
        {
            int count=box.Count;
            return count;
        }
        //获得火柴数目
        public int count()
        {
           int count1= this.get_box_count(this.Boxes[1]);
           int count2= this.get_box_count(this.Boxes[2]);
            int count3 = this.get_box_count(this.Boxes[3]);
            int cnt=0;
            cnt+=count1;
            cnt+=count2;
            cnt+=count3;
            return cnt;
        }

        //显示火柴剩余信息
        public void ShowInfo(){
            Console.WriteLine("盒子1: 火柴: "+this.get_box_count(this.Boxes[1]).ToString());
            Console.WriteLine("盒子2: 火柴: "+this.get_box_count(this.Boxes[2]).ToString());
            Console.WriteLine("盒子3: 火柴: "+this.get_box_count(this.Boxes[3]).ToString());
            // Console.WriteLine("合计: 火柴: "+this.count().ToString());
        }

        //取一次火柴
        //取出成功返回True
        public bool play_take(int take_count){
            try
            {
                int player=take_count%2+1;
                string player_str=player.ToString();
                Console.WriteLine("请玩家"+player_str+"输入(编号+空格+数量):");
                string line =Console.ReadLine();
                string[] info = line.Split(" ");
                Console.WriteLine("玩家"+player_str+"从盒子"+info[0]+"取出"+info[1]+"根火柴");
                var num = int.Parse(info[0]);
                var cnt = int.Parse(info[1]);
                int cnt_g=this.get_box_count(this.Boxes[num]);
                this.Take(this.Boxes[num],cnt);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("您的输入有误,提示如下:");
                Console.WriteLine(ex.Message);
                return false;
            }
            
        }

        //游戏开始
        public string start(){
            int take_count=0;
            while(this.count()>0){
                Console.WriteLine("\r\n---------------------------------\r\n");
                ShowInfo();
                Console.WriteLine("次数:"+(take_count+1).ToString());
                if(play_take(take_count))
                {
                    take_count=take_count+1 ;   
                }         
            }
            string player_win="玩家1 胜";
            if (take_count%2==1)
            {
                player_win="玩家2 胜";                
            }
            return player_win;
        }
}
