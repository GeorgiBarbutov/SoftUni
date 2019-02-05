using System;
using System.Linq;

namespace Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int prizeOfBullet = int.Parse(Console.ReadLine()); //0-100
            int sizeOfGunBarrel = int.Parse(Console.ReadLine()); //0-5000
            int[] bullets = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Reverse()
                .ToArray();

            int[] locks = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int intelligenceValue = int.Parse(Console.ReadLine());

            int currentBuletIndex = 0;
            int currentLockIndex = 0;
            int locksLeft = locks.Length;
            int bulletsLeft = bullets.Length;

            int bulletsInBarelLeft;

            if (sizeOfGunBarrel > bulletsLeft)
            {
                bulletsInBarelLeft = bulletsLeft;
            }
            else
            {
                bulletsInBarelLeft = sizeOfGunBarrel;
            }

            while (bulletsLeft > 0 && locksLeft > 0)
            {
                if (bullets[currentBuletIndex] <= locks[currentLockIndex])
                {
                    Console.WriteLine("Bang!");

                    locksLeft--;
                    bulletsLeft--;

                    currentBuletIndex++;
                    currentLockIndex++;

                    bulletsInBarelLeft--;
                }
                else
                {
                    Console.WriteLine("Ping!");

                    bulletsLeft--;
                    currentBuletIndex++;

                    bulletsInBarelLeft--;
                }

                if (bulletsInBarelLeft == 0)
                {
                    if (bulletsLeft > 0)
                    {
                        Console.WriteLine("Reloading!");
                    }

                    if (sizeOfGunBarrel > bulletsLeft)
                    {
                        bulletsInBarelLeft = bulletsLeft;
                    }
                    else
                    {
                        bulletsInBarelLeft = sizeOfGunBarrel;
                    }
                }
            }

            int bulletsUsed = bullets.Length - bulletsLeft;
            int bulletCost = bulletsUsed * prizeOfBullet;
            int totalEarnings = intelligenceValue - bulletCost;

            if (locksLeft == 0)
            {
                Console.WriteLine($"{bulletsLeft} bullets left. Earned ${totalEarnings}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksLeft}");
            }
        }
    }
}

