using System;

class Program
{
    static void Main(string[] args) {
        BaldEagle bird1 = new BaldEagle("Joey", "Screeeee!");
        BaldEagle bird2 = new BaldEagle("Dragon", "Rawr! **Fireball**");

        bird1.MakeSound();
        bird2.MakeSound();
    }
}