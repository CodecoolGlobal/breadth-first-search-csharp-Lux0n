using BFS_c_sharp.Model;
using System;
using System.Collections.Generic;

namespace BFS_c_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomDataGenerator generator = new RandomDataGenerator();
            List<UserNode> users = generator.Generate();

            foreach (var user in users)
            {
                Console.WriteLine(user + " " + user.Id);
            }

            Console.WriteLine("Done");
            Console.ReadLine();

            BreadthFirstSearch search = new BreadthFirstSearch(users);
            int distance = search.MinDistance(users[0], users[6]);
            Console.WriteLine(distance);
            Console.ReadLine();

            //Console.WriteLine(search.FriendsOfFriends(users[0], 3));
            HashSet<UserNode> result = search.FriendsOfFriends(users[12], 2);
            foreach(var user in result)
            {
                Console.WriteLine(user);
            }
            Console.ReadLine();
        }
    }
}
