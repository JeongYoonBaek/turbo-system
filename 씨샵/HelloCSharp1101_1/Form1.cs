﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloCSharp1101_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Animal a = new Animal();
            a.Age = 10;
            label1.Text = "나이 :" + a.Age + "살";
            a.Eat();
            a.Sleep();
            // a.Born(); // protected이므로 바깥에선 호출이 불가능
            // 바깥이란? Animal을 상속받지 않은 클래스를 의미
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cat c = new Cat();   // Born이 호출됨
            c.Age = 5;  // Animal에 있는 Age를 상속받았음
            label2.Text = "고양이 나이 : " + c.Age + "살";
            c.Eat();        // Animal에 있는 메서드 상속받음
            c.Sleep();   // Animal에 있는 메서드 상속받음
            c.Meow();   // 고양이의 고유 메소드
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Dog d = new Dog();  // 생성자 안에서 자동으로 Born 호출됨 
            d.Age = 17;
            d.Color = "White";
            label3.Text = "개의 나이 :" + d.Age + "살" + "\n";
            label3.Text += "개의 털 색깔 :" + d.Color;  // +=를 하면 나이를 알려주고 개의 털 색깔도 라벨에서 출력됨
            d.Eat();
            d.Sleep();
            d.Bark();   // 개의 고유 메소드
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<Animal> zoo = new List<Animal>();
            zoo.Add(new Animal());
            zoo.Add(new Animal());
            zoo.Add(new Dog());
            zoo.Add(new Dog());
            zoo.Add(new Cat());
            zoo.Add(new Cat());
            Animal a = new Animal();
            Animal b = new Cat();
            
            // 무작정 형변환
            ((Cat)b).Meow();
            (b as Cat).Meow();

           
            if (b is Dog) // 오른쪽에 있는 클래스가 도그 클래스가 맞니? 해서 맞으면 출력  
                (b as Dog).Bark(); // 위에 if문을 작성하기전 여기서 에러가 난다. 


            //  삼항 연산자를 이용한 방법 (무작정 형변환을 하면 var라는 키워드를 변수 선언후 그 녀석이 null값인지 체크하고 
            //  null 값이 아니면  출력
            var t = b as Dog;
            // t가 null이 아니다의 의미 : 형변환(as) 성공
            // null이 된건 형변환 실패 
            if (b as Cat == null)
                t.Bark();


            Animal c = new Dog();
            zoo.Add(a);
            zoo.Add(b);
            zoo.Add(c);
            Cat d = new Cat();
            Dog d2 = new Dog();
            zoo.Add(d);
            zoo.Add(d2);
            //foreach(Animal item in zoo)
            foreach (var item in zoo)
            {
                item.Eat();
                item.Sleep();
                if (item is Cat)   // 타입 체크 : is
                    (item as Cat).Meow(); // 형변환 : as0
                if (item is Dog)
                    (item as Dog).Bark();

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // 다형성 
            // 왼쪽 = 오른쪽의 관계가
            // 오른쪽 is 왼쪽 
            // ex) 핸드폰 s = new 스마트폰();
            // 스마트폰 is 핸드폰 (o)
            // 핸드폰 is 스마트폰 (x), 누군가는 아직 피쳐폰을 쓴다!
            Cat cat = new Cat();
            Dog dog = new Dog();    

            // 코드의 중복을 제거하기 위해 이런 형태로 만듦 (코드를 묶고 간소화 시키기 위해 다형성이 생겨남)
            Animal a = new Dog();   // Dog is Animal
            Animal b = new Cat();   // Cat is Animal


            a.Age = 1;
            a.Eat();
            a.Sleep();
            ((Dog)a).Bark();    // OK
            //((Dog)b).Bark();   // b는 Cat이므로 무작정 형변환시 오류가 난다
            // 캐스팅 : 타입을 바꾸는 것 
            if (b is Dog)  // 타입체크도 is로 가능하다
                ((Dog)b).Bark();
            if (b is Dog)
                (b as Dog).Bark(); // as를 이용하여 형변환이 가능하다
            var test = b as Dog; // b를 Dog로 형변환해서 테스트에 넘겨봄
            Console.WriteLine(test == null);
            if (test != null)   // test가 null값이 아니라면 true 
            test.Bark();
            
                List<Animal> animals = new List<Animal>()
            {
                new Dog(), new Cat(), new Dog()
            };
            animals.Add(cat);
            animals.Add(dog);
            animals.Add(a);
            animals.Add(b);
            foreach (var item in animals)
            {
                item.Eat();
                item.Sleep();
                if(item is Dog)
                    (item as Dog).Bark();
                if (item is Cat)
                    (item as Cat).Meow();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Age는 인스턴스 별로 다들 각자 다름
            // count는 Age, Dog, Cat이 공유하고 있음
            Cat cat = new Cat();    
            Dog dog = new Dog();    
            Animal animal = new Animal();
            cat.Age = 5;
            dog.Age = 7;
            animal.Age = 50; 
            Cat.count++; // 조상, 자손 모든 클래스가 공유하고 있음.
            Dog.count++; // age는 상속이 되는데 count는 상속보단 공유가 됨.
            Animal.count++;
            MessageBox.Show("count값 : " + Animal.count);
            MessageBox.Show("count값 : " + Cat.count);
            MessageBox.Show("count값 : " + Dog.count);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            new Animal().Wash();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Cat c = new Cat();
            c.Wash();
            (c as Animal).Wash(); // 오버라이드 
        }

        private void button9_Click(object sender, EventArgs e)
        {
            new Dog().Wash();   
        }
    }
}
